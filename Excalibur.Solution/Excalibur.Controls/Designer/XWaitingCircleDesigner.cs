using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Forms.Design.Behavior;

namespace Excalibur.Controls.Designer
{
    public class XWaitingCircleDesigner : ControlDesigner
    {

        private DesignerVerbCollection _verbs;
        private ISelectionService _iss;
        static DesignerVerb _dvAntialias;

        private DesignerActionListCollection _actionlist;
        private BehaviorService _bs;
        private Adorner _adorner;

        public XWaitingCircleDesigner()
            : base()
        {

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                _dvAntialias = null;
                if (_iss != null)
                    _iss.SelectionChanged -= new EventHandler(OnComponentSelectionChanged);
                _iss = null;
                _verbs = null;
                _bs.Adorners.Remove(_adorner);
                _bs = null;
                _adorner = null;
            }
        }

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            _iss = (ISelectionService)GetService(typeof(ISelectionService));
            _iss.SelectionChanged += new EventHandler(OnComponentSelectionChanged);
            _bs = (BehaviorService)GetService(typeof(BehaviorService));
            _adorner = new Adorner();
            _bs.Adorners.Add(_adorner);
            _adorner.Glyphs.Add(new WaitingCircleGlyph(_bs, (XWaitingCircle)Control, _adorner));
        }

        public override DesignerVerbCollection Verbs
        {
            get
            {
                if (_verbs == null)
                {
                    _verbs = new DesignerVerbCollection();
                    _verbs.Add(new DesignerVerb("Active/Deactive", new EventHandler(OnActivateCircle)));
                    _verbs.Add(new DesignerVerb("XWaitingCircle Editor", new EventHandler(OnShowDesigner)));
                }
                return _verbs;
            }
        }

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (_actionlist == null)
                {
                    _actionlist = new DesignerActionListCollection();
                    _actionlist.Add(new WaitingCircleActionList(Component));
                }
                return _actionlist;
            }
        }

        private void OnComponentSelectionChanged(object sender, EventArgs e)
        {
            if (_dvAntialias == null)
                _dvAntialias = new DesignerVerb("WaitingCircle Antialias", new EventHandler(OnAntialias));
            IMenuCommandService imcs = (IMenuCommandService)GetService(typeof(IMenuCommandService));
            if (!imcs.Verbs.Contains(_dvAntialias)) imcs.AddVerb(_dvAntialias);
            bool all = _iss.SelectionCount > 0;//选择控件都是WaitingCircle
            foreach (IComponent comp in _iss.GetSelectedComponents())
            {
                if (!(comp is XWaitingCircle))
                {
                    all = false;
                    break;
                }
            }
            if (all)
            {
                _dvAntialias.Visible = true;
                _dvAntialias.Checked = ((XWaitingCircle)_iss.PrimarySelection).Antialias;
            }
            else
                _dvAntialias.Visible = false;
            if (object.ReferenceEquals(_iss.PrimarySelection, Component))
                _adorner.Enabled = true;
            else
                _adorner.Enabled = false;
        }

        private void OnActivateCircle(object sender, System.EventArgs e)
        {
            XWaitingCircle wc = Control as XWaitingCircle;
            GetPropertyByName("Activate").SetValue(wc, !wc.Activate);
            //if (wc != null) wc.Activate = !wc.Activate;
        }

        private PropertyDescriptor GetPropertyByName(String propName)
        {
            PropertyDescriptor prop;
            prop = TypeDescriptor.GetProperties(Control)[propName];
            if (null == prop)
                throw new ArgumentException("组件未定义该属性。", propName);
            else
                return prop;
        }


        private void OnShowDesigner(object sender, System.EventArgs e)
        {
            XWaitingCircleDesignForm wcdf = new XWaitingCircleDesignForm();
            XWaitingCircle wc = Control as XWaitingCircle;
            if (wc != null)
            {
                wcdf.waitingCircle1.Activate = wc.Activate;
                wcdf.waitingCircle1.Speed = wc.Speed;
                wcdf.waitingCircle1.ColockWise = wc.ColockWise;
                wcdf.waitingCircle1.NumberOfSpokes = wc.NumberOfSpokes;
            }
            if (wcdf.ShowDialog() == DialogResult.OK)
            {
                GetPropertyByName("Activate").SetValue(Control, wcdf.waitingCircle1.Activate);
                GetPropertyByName("Speed").SetValue(Control, wcdf.waitingCircle1.Speed);
                GetPropertyByName("ColockWise").SetValue(Control, wcdf.waitingCircle1.ColockWise);
                GetPropertyByName("NumberOfSpokes").SetValue(Control, wcdf.waitingCircle1.NumberOfSpokes);
            }
        }

        private void OnAntialias(object sender, EventArgs e)
        {
            XWaitingCircle wc = (XWaitingCircle)_iss.PrimarySelection;
            TypeDescriptor.GetProperties(wc)["Antialias"].SetValue(wc, !wc.Antialias);
            _dvAntialias.Checked = wc.Antialias;
            foreach (IComponent comp in _iss.GetSelectedComponents())
            {
                if (comp != wc)
                    TypeDescriptor.GetProperties(comp)["Antialias"].SetValue(comp, wc.Antialias);
            }
        }



        public override IList SnapLines
        {
            get
            {
                IList lines = new ArrayList();
                CircleF bounds = new CircleF(Control.ClientRectangle);
                bounds.Inflate(-5);
                SnapLine left = new SnapLine(SnapLineType.Left, (int)bounds.GetBounds().Left);
                SnapLine right = new SnapLine(SnapLineType.Right, (int)bounds.GetBounds().Right);
                SnapLine top = new SnapLine(SnapLineType.Top, (int)bounds.GetBounds().Top);
                SnapLine bot = new SnapLine(SnapLineType.Bottom, (int)bounds.GetBounds().Bottom);
                lines.Add(left);
                lines.Add(right);
                lines.Add(top);
                lines.Add(bot);
                CircleF inner = new CircleF(bounds.Pivot, ((XWaitingCircle)Control).InnerRadius);
                left = new SnapLine(SnapLineType.Left, (int)inner.GetBounds().Left);
                right = new SnapLine(SnapLineType.Right, (int)inner.GetBounds().Right);
                top = new SnapLine(SnapLineType.Top, (int)inner.GetBounds().Top);
                bot = new SnapLine(SnapLineType.Bottom, (int)inner.GetBounds().Bottom);
                lines.Add(left);
                lines.Add(right);
                lines.Add(top);
                lines.Add(bot);
                foreach (object o in base.SnapLines)
                {
                    lines.Add(o);
                }
                return lines;
            }
        }

        public override SelectionRules SelectionRules
        {
            get
            {
                SelectionRules sr = base.SelectionRules;
                if (!((XWaitingCircle)Control).Activate)
                    sr |= SelectionRules.Moveable;
                else
                    sr &= ~SelectionRules.Moveable;
                return sr;
            }
        }
    }



    public class WaitingCircleActionList : DesignerActionList
    {
        XWaitingCircle _wc;

        public WaitingCircleActionList(IComponent comp)
            : base(comp)
        {
            _wc = (XWaitingCircle)comp;
        }

        public Color SpokeColor
        {
            get { return _wc.SpokeColor; }
            set { TypeDescriptor.GetProperties(_wc)["SpokeColor"].SetValue(_wc, value); }
        }

        public Color HotSpokeColor
        {
            get { return _wc.HotSpokeColor; }
            set { TypeDescriptor.GetProperties(_wc)["HotSpokeColor"].SetValue(_wc, value); }
        }

        public LineCap StartCap
        {
            get { return _wc.StartCap; }
            set { TypeDescriptor.GetProperties(_wc)["StartCap"].SetValue(_wc, value); }
        }

        public LineCap EndCap
        {
            get { return _wc.EndCap; }
            set { TypeDescriptor.GetProperties(_wc)["EndCap"].SetValue(_wc, value); }
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection();
            items.Add(new DesignerActionHeaderItem("Spoke Color"));
            items.Add(new DesignerActionPropertyItem("SpokeColor", "Spoke Color", "Spoke Color"));
            items.Add(new DesignerActionPropertyItem("HotSpokeColor", "Hot Spoke Color", "Spoke Color"));

            items.Add(new DesignerActionHeaderItem("Spoke Style"));
            items.Add(new DesignerActionPropertyItem("StartCap", "Start Cap", "Spoke Style"));
            items.Add(new DesignerActionPropertyItem("EndCap", "End Cap", "Spoke Style"));

            items.Add(new DesignerActionHeaderItem("About"));
            items.Add(new DesignerActionMethodItem(this, "OnSendMail", "Send Mail:jello_chen@live.com", "About"));
            items.Add(new DesignerActionTextItem("Copyright(C)", "About"));

            return items;
        }

        private void OnSendMail()
        {
            System.Diagnostics.Process.Start("mailto:jello_chen@live.com");
        }
    }

    public class WaitingCircleGlyph : Glyph
    {
        internal BehaviorService _bsService;
        internal XWaitingCircle _waitCircle;
        internal Adorner _adorner;
        internal bool _fill = true;

        public WaitingCircleGlyph(BehaviorService service, XWaitingCircle control, Adorner adorner)
            : base(new WaitingCircleBehavior())
        {
            _bsService = service;
            _waitCircle = control;
            _adorner = adorner;
        }

        public new CircleF Bounds
        {
            get
            {
                Point loc = _bsService.ControlToAdornerWindow(_waitCircle);
                CircleF c = new CircleF(_waitCircle.ClientRectangle);
                c.Radius = _waitCircle.InnerRadius;
                c.Pivot = new PointF(c.Pivot.X + loc.X, c.Pivot.Y + loc.Y);
                return c;
            }
        }

        public override void Paint(PaintEventArgs pe)
        {
            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            if (_fill)
            {
                using (SolidBrush sb = new SolidBrush(Color.FromArgb(255 - _waitCircle.SpokeColor.R, 255 - _waitCircle.SpokeColor.G, 255 - _waitCircle.SpokeColor.B)))
                {
                    pe.Graphics.FillEllipse(sb, Bounds);
                }
            }
            else
                using (Pen p = new Pen(Color.FromArgb(255 - _waitCircle.SpokeColor.R, 255 - _waitCircle.SpokeColor.G, 255 - _waitCircle.SpokeColor.B), 3.0f))
                {
                    pe.Graphics.DrawEllipse(p, Bounds);
                }

        }

        public override Cursor GetHitTest(Point p)
        {
            if (Bounds.Contains(p))
                return Cursors.Hand;
            else
                return null;
        }

        internal class WaitingCircleBehavior : Behavior
        {
            public override bool OnMouseDown(Glyph g, MouseButtons button, Point mouseLoc)
            {
                WaitingCircleGlyph wcg = g as WaitingCircleGlyph;
                if (null != wcg && button == MouseButtons.Left)
                {
                    wcg._fill = !wcg._fill;
                    wcg._adorner.Invalidate();
                }
                return true;
            }
        }
    }
}
