using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excalibur.Controls
{
    [Description("Application container")]
    [ToolboxBitmap(typeof(XAppContainer), "Resources.XAppContainer.bmp")]
    public partial class XAppContainer : Panel
    {
        #region Fields
        private string mAppFilename;
        private bool mAutoStart;
        private Process mAppProcess;
        private IntPtr mWindowHandle;
        private bool mAutoHide;
        private long mSavedWindowStyle;
        #endregion

        #region Properties
        /// <summary>
        /// File name of the executable to embed
        /// </summary>
        [Category("Data"), Description("File name of the executable to embed")]
        public string AppFilename
        {
            get { return this.mAppFilename; }
            set
            {
                if (value == null || value == mAppFilename) return;
                if (value.ToLower() == Application.ExecutablePath.ToLower())
                {
                    MessageBox.Show("Don't embed itself");
                }
                if (!value.ToLower().EndsWith(".exe"))
                {
                    MessageBox.Show("Not a executable file");
                }
                mAppFilename = value;
            }
        }

        [Category("Behavior"), Description("Start the embed app automatically")]
        public bool AutoStart
        {
            get
            {
                return this.mAutoStart;
            }
            set
            {
                this.mAutoStart = value;
            }
        }
        /// <summary>
        /// whether the embed app is started
        /// </summary>
        [Description("whether the embed app is started")]
        public bool IsStarted
        {
            get
            {
                return this.mAppProcess != null;
            }
        }

        /// <summary>
        /// The handle of the embed window
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IntPtr EmbedWindowHandle
        {
            get
            {
                return this.mWindowHandle;
            }
        }
        #endregion

        #region Constructors
        public XAppContainer()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Override OnHandleCreated to determine whether to start to embed
        /// </summary>
        /// <param name="e"></param>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (this.mAutoStart)
            {
                this.Start();
            }
        }

        /// <summary>
        /// Override OnHandleDestroyed to stop to embed
        /// </summary>
        /// <param name="e"></param>
        protected override void OnHandleDestroyed(EventArgs e)
        {
            Stop();
            base.OnHandleDestroyed(e);
        }

        /// <summary>
        /// Override OnSizeChanged to redraw
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            Invalidate();
            base.OnSizeChanged(e);
        }

        /// <summary>
        /// Override OnResize to Move Window
        /// </summary>
        /// <param name="eventargs"></param>
        protected override void OnResize(EventArgs eventargs)
        {
            if (this.mWindowHandle != IntPtr.Zero)
            {
                NativeMethods.MoveWindow(this.mWindowHandle, 0, 0, this.Width, this.Height, true);
            }
            base.OnResize(eventargs);
        }

        /// <summary>
        /// Embed the window
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="autoHide"></param>
        /// <param name="noStop"></param>
        public void EmbedWindow(IntPtr handle, bool autoHide = false, bool noStop = false)
        {
            if (!noStop && (this.mAppProcess != null || this.mWindowHandle != IntPtr.Zero))
            {
                this.Stop();
            }
            this.mAutoHide = autoHide;
            this.mWindowHandle = handle;
            this.EmbedProcess(this, this.mWindowHandle);
        }

        /// <summary>
        /// Start embedding
        /// </summary>
        public void Start()
        {
            if (this.mAppProcess != null)
            {
                this.Stop();
            }
            try
            {
                this.mAppProcess = Process.Start(new ProcessStartInfo(this.mAppFilename)
                    {
                        UseShellExecute = true,
                        WindowStyle = ProcessWindowStyle.Minimized
                    });
                this.mAppProcess.WaitForInputIdle();
                Application.Idle += Application_Idle;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("{1}{0}{2}{0}{3}", new object[]
				{
					Environment.NewLine,
					"*" + ex.ToString(),
					"*StackTrace:" + ex.StackTrace,
					"*Source:" + ex.Source
				}), "Embed app failed");
                if (this.mAppProcess != null)
                {
                    if (!this.mAppProcess.HasExited)
                    {
                        this.mAppProcess.Kill();
                    }
                    this.mAppProcess = null;
                }
            }
        }

        /// <summary>
        /// Application idle event handle 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Application_Idle(object sender, EventArgs e)
        {
            if (this.mAppProcess == null || this.mAppProcess.HasExited)
            {
                this.mAppProcess = null;
                Application.Idle -= Application_Idle;
                return;
            }
            if (this.mAppProcess.MainWindowHandle != IntPtr.Zero)
            {
                Application.Idle -= Application_Idle;
                this.mWindowHandle = this.mAppProcess.MainWindowHandle;
                this.EmbedProcess(this, this.mWindowHandle);
            }
        }

        /// <summary>
        /// Embed Process
        /// </summary>
        /// <param name="control"></param>
        /// <param name="hwnd"></param>
        private void EmbedProcess(Control control, IntPtr hwnd)
        {
            if (hwnd == IntPtr.Zero || control == null) return;
            this.mWindowHandle = hwnd;
            try
            {
                this.mSavedWindowStyle = NativeMethods.GetWindowLong(this.mWindowHandle, -16);
                NativeMethods.SetParent(this.mWindowHandle, control.Handle);
                NativeMethods.SetWindowLong(new HandleRef(this, this.mWindowHandle), -16, NativeMethods.WS_VISIBLE | NativeMethods.WS_CHILD);
                NativeMethods.MoveWindow(this.mWindowHandle, 0, 0, control.Width, control.Height, true);
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Stop embedding
        /// </summary>
        public void Stop()
        {
            if (this.mAppProcess != null)
            {
                try
                {
                    if (!this.mAppProcess.HasExited)
                    {
                        this.mAppProcess.Kill();
                    }
                }
                catch
                {

                }
                this.mAppProcess = null;
            }
            else if (this.mWindowHandle != IntPtr.Zero)
            {
                NativeMethods.SetParent(mWindowHandle, IntPtr.Zero);
                if (this.mAutoHide)
                {
                    NativeMethods.ShowWindow(this.mWindowHandle, 0);
                }
                else
                {
                    NativeMethods.SetWindowLong(new HandleRef(this, mWindowHandle), -16, (int)this.mSavedWindowStyle);//Restore window Style
                }
            }
            this.mWindowHandle = IntPtr.Zero;
        }
        #endregion
    }
}
