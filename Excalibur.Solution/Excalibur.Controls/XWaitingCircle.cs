using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excalibur.Controls.Designer;

namespace Excalibur.Controls
{
    [Description("Waiting Circle Control"),Designer(typeof(XWaitingCircleDesigner))]
    public partial class XWaitingCircle : Control
    {
        private int _numberofspokes = 20;
        private int _hotspokes = 5;
        private float _innerRadius;
        private Color _spokeColor = Color.LightGray;
        private Color _hotSpokeColor = Color.Gray;

        private float _thickness = 3;
        private bool _antialias = true;
        private bool _colockWise = true;

        private List<PointF[]> _spokes;
        protected Color[] _palette;
        private Timer _timer;
        private Pen _pen;
        private int _offset = 0;

        [DefaultValue(100)]
        public int Speed
        {
            get { return _timer.Interval; }
            set { _timer.Interval = value; }
        }

        [DefaultValue(false)]
        public bool Activate
        {
            get { return _timer.Enabled; }
            set
            {
                _timer.Enabled = value;
                Invalidate();
            }
        }

        [DefaultValue(true)]
        public bool Antialias
        {
            get { return _antialias; }
            set
            {
                _antialias = value;
                Invalidate();
            }
        }

        public float InnerRadius
        {
            get { return _innerRadius; }
            set
            {
                if (_innerRadius != value && value > 0)
                {
                    _innerRadius = value;
                    CircleF c = new CircleF(ClientRectangle);
                    c.Inflate(-5.0f);
                    _spokes = ExtendedShapes.CreateWaitCircleSpokes(c.Pivot, c.Radius, _innerRadius, _numberofspokes);
                    Invalidate();
                }
            }
        }

        [DefaultValue(true)]
        public bool ColockWise
        {
            get { return _colockWise; }
            set { _colockWise = value; }
        }

        public Color SpokeColor
        {
            get { return _spokeColor; }
            set
            {
                _spokeColor = value;
                GeneratePalette();
                Invalidate();
            }
        }

        public Color HotSpokeColor
        {
            get { return _hotSpokeColor; }
            set
            {
                _hotSpokeColor = value;
                GeneratePalette();
            }
        }

        [DefaultValue(20)]
        public int NumberOfSpokes
        {
            get { return _numberofspokes; }
            set
            {
                _numberofspokes = Math.Max(2, Math.Max(_hotspokes, value));
                CircleF c = new CircleF(ClientRectangle);
                c.Inflate(-5.0f);
                _spokes = ExtendedShapes.CreateWaitCircleSpokes(c.Pivot, c.Radius, _innerRadius, _numberofspokes);
                Invalidate();
            }
        }

        [DefaultValue(5)]
        public int HotSpokes
        {
            get { return _hotspokes; }
            set
            {
                _hotspokes = Math.Max(1, Math.Min(_numberofspokes, value));
                GeneratePalette();
            }
        }

        public LineCap StartCap
        {
            get { return _pen.StartCap; }
            set { _pen.StartCap = value; Invalidate(); }
        }

        public LineCap EndCap
        {
            get { return _pen.EndCap; }
            set { _pen.EndCap = value; Invalidate(); }
        }

        [DefaultValue(3)]
        public float Thickness
        {
            get { return _thickness; }
            set
            {
                if (value > 0)
                    _thickness = value;
                _pen.Width = _thickness;
                Invalidate();
            }
        }

        public XWaitingCircle()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            this.Disposed += XWaitingCircle_Disposed;
            _timer = new Timer();
            _timer.Tick += new EventHandler(_timer_Tick);
            _pen = new Pen(_spokeColor, _thickness);
            GeneratePalette();
        }

        void XWaitingCircle_Disposed(object sender, EventArgs e)
        {
            _pen.Dispose();
            _timer.Dispose();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            CircleF c = new CircleF(ClientRectangle);
            c.Inflate(-5.0f);
            _innerRadius = c.Radius / 2.0f;
            _spokes = ExtendedShapes.CreateWaitCircleSpokes(c.Pivot, c.Radius, _innerRadius, _numberofspokes);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawSpokes(e.Graphics);
        }

        protected void DrawSpokes(Graphics g)
        {
            g.SmoothingMode = _antialias ? SmoothingMode.AntiAlias : SmoothingMode.Default;
            if (!Activate)
            {
                _pen.Color = _spokeColor;
                foreach (PointF[] spoke in _spokes)
                {
                    g.DrawLines(_pen, spoke);
                }
            }
            else
            {
                List<int> hot = new List<int>();//存储活动辐条的索引；
                for (int i = 0; i < _hotspokes; i++)
                {
                    int index = ((_colockWise ? _offset - i : _offset + i) + _numberofspokes) % _numberofspokes;
                    hot.Add(index);
                }
                _pen.Color = _spokeColor;
                for (int i = 0; i < _numberofspokes; i++)//首先绘制非活动辐条
                {
                    if (!hot.Contains(i)) g.DrawLines(_pen, _spokes[i]);
                }
                for (int i = 0; i < _hotspokes; i++)//绘制活动辐条
                {
                    _pen.Color = _palette[_hotspokes - 1 - i];
                    g.DrawLines(_pen, _spokes[hot[i]]);
                }
            }
        }

        protected virtual void GeneratePalette()
        {
            _palette = new Color[_hotspokes];
            float a = (float)(_hotSpokeColor.A - _spokeColor.A) / (float)_hotspokes;
            float r = (float)(_hotSpokeColor.R - _spokeColor.R) / (float)_hotspokes;
            float g = (float)(_hotSpokeColor.G - _spokeColor.G) / (float)_hotspokes;
            float b = (float)(_hotSpokeColor.B - _spokeColor.B) / (float)_hotspokes;
            for (int i = 0; i < _hotspokes; i++)
            {
                _palette[i] = Color.FromArgb(_hotSpokeColor.A - (int)(i * a), _hotSpokeColor.R - (int)(i * r), _hotSpokeColor.G - (int)(i * g), _hotSpokeColor.B - (int)(i * b));
            }
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            Invalidate();
            _offset = ((_colockWise ? --_offset : ++_offset) + _numberofspokes) % _numberofspokes;
        }
    }

    /// <summary>
    /// Circle Shape
    /// </summary>
    /// <remarks>
    ///     
    /// </remarks>
    [Serializable, StructLayout(LayoutKind.Sequential), TypeConverter(typeof(CircleFConvertor))]
    public sealed class CircleF : ICloneable
    {
        public static CircleF Empty = new CircleF();

        PointF _pivot;
        float _radius;

        public CircleF(RectangleF rectf)
        {
            _pivot = GetCirclePivot(rectf);
            _radius = GetCircleRadius(rectf);
        }

        public CircleF(PointF pivot, float radius)
        {
            _pivot = pivot;
            _radius = radius;
        }

        public CircleF()
            : this(default(PointF), 0)
        {
        }

        public CircleF FromRectangle(RectangleF rect)
        {
            _pivot = GetCirclePivot(rect);
            _radius = GetCircleRadius(rect);
            return this;
        }

        public static PointF GetCirclePivot(RectangleF rect)
        {
            return new PointF(rect.X + rect.Width / 2.0f, rect.Y + rect.Height / 2.0f);
        }

        public static float GetCircleRadius(RectangleF rect)
        {
            return Math.Min(rect.Width / 2.0f, rect.Height / 2.0f);
        }

        public RectangleF GetBounds()
        {
            return new RectangleF(_pivot.X - _radius, _pivot.Y - _radius, _radius * 2.0f, _radius * 2.0f);
        }

        public static RectangleF GetBounds(RectangleF rect)
        {
            PointF p = GetCirclePivot(rect);
            float d = GetCircleRadius(rect);
            return new RectangleF(p.X - d, p.Y - d, d * 2.0f, d * 2.0f);
        }

        public bool Contains(float x, float y)
        {
            return Contains(new PointF(x, y));
        }

        public bool Contains(PointF p)
        {
            return Distance(p) <= _radius;
        }

        /// <summary>
        /// Calculate the distance of the piviot
        /// </summary>
        public float Distance(CircleF c)
        {
            return Distance(c.Pivot);
        }

        /// <summary>
        /// Calculate the distance between the point and the piviot
        /// </summary>
        public float Distance(PointF p)
        {
            return (float)Math.Sqrt((p.X - _pivot.X) * (p.X - _pivot.X) + (p.Y - _pivot.Y) * (p.Y - _pivot.Y));
        }

        public float Area()
        {
            return (float)Math.PI * _radius * _radius;
        }

        /// <summary>
        /// Calculate the point coordinate of the polar coordinate
        /// </summary>
        /// <param name="sweepAngle" type="float">
        ///     <para>
        ///         the angle in polar coordinate
        ///     </para>
        /// </param>
        /// <returns>
        ///     A System.Drawing.PointF value...
        /// </returns>
        public PointF PointOnPath(double sweepAngle)
        {
            return new PointF(_pivot.X + _radius * (float)Math.Cos(sweepAngle * (Math.PI / 180.0d)),
                                             _pivot.Y - _radius * (float)Math.Sin(sweepAngle * (Math.PI / 180.0d)));
        }

        /// <summary>
        /// 将此圆形的位置调整指定的量。
        /// </summary>
        /// <param name="x">垂直偏移该位置的量。</param>
        /// <param name="y">水平偏移该位置的量。</param>
        public void Offset(float x, float y)
        {
            _pivot.X += x;
            _pivot.Y += y;
        }

        /// <summary>
        /// 将此圆形的位置调整指定的量。
        /// </summary>
        /// <param name="pos"> 偏移该位置的量。 </param>
        public void Offset(System.Drawing.PointF pos)
        {
            Offset(pos.X, pos.Y);
        }

        /// <summary>
        /// 将此 Gemini.Component.Drawing.CircleF 结构放大指定量。
        /// </summary>
        /// <param name="d">半径的放大量</param>
        public void Inflate(float d)
        {
            Radius += d;
        }

        /// <summary>
        /// 测试两个  Gemini.Component.Drawing.CircleF 结构的位置或大小是否不同。
        /// </summary>
        /// <param name="left">不等运算符右侧的  Gemini.Component.Drawing.CircleF 结构。</param>
        /// <param name="right">不等运算符左侧的  Gemini.Component.Drawing.CircleF 结构。 </param>
        /// <returns>如果两个 Gemini.Component.Drawing.CircleF 结构的  Gemini.Component.Drawing.CircleF.Pivot、 Gemini.Component.Drawing.CircleF.Diameter 属性值中有任何一个不相等，此运算符将返回 true；否则将返回 false。</returns>
        public static bool operator !=(CircleF left, CircleF right)
        {
            return left._pivot == right._pivot && left._radius == right._radius;
        }

        /// <summary>
        /// 测试两个  Gemini.Component.Drawing.CircleF 结构的位置或大小是否相等。
        /// </summary>
        /// <param name="left">相等运算符右侧的  Gemini.Component.Drawing.CircleF 结构。</param>
        /// <param name="right">相等运算符左侧的  Gemini.Component.Drawing.CircleF 结构。 </param>
        /// <returns>如果两个 Gemini.Component.Drawing.CircleF 结构的  Gemini.Component.Drawing.CircleF.Pivot、 Gemini.Component.Drawing.CircleF.Diameter 属性值中有任何一个不相等，此运算符将返回 false；否则将返回 true。</returns>
        public static bool operator ==(CircleF left, CircleF right)
        {
            return !(left != right);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public static implicit operator RectangleF(CircleF c)
        {
            return c.GetBounds();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{{Pivot={0},Radius={1}}}", _pivot, _radius);
        }

        #region ICloneable 成员

        public object Clone()
        {
            return new CircleF(_pivot, _radius);
        }

        #endregion

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public PointF Pivot
        {
            get { return _pivot; }
            set { _pivot = value; }
        }
        public float Radius
        {
            get { return _radius; }
            set
            {
                if (value >= 0)
                    _radius = value;
            }
        }
    }


    /// <summary>
    ///Circle Shape
    /// </summary>
    /// <remarks>
    ///     
    /// </remarks>
    [Serializable, StructLayout(LayoutKind.Sequential), ComVisible(true)]
    public struct Circle : ICloneable
    {


        Point _pivot;//the center of the circle
        int _radius;//radius

        public Circle(Rectangle rect)
        {
            _pivot = GetCirclePivot(rect);
            _radius = GetCircleDiameter(rect);
        }

        public Circle(Point Pivot, int radius)
        {
            _pivot = Pivot;
            _radius = radius;
        }

        public Circle FromRectangle(Rectangle rect)
        {
            _pivot = GetCirclePivot(rect);
            _radius = GetCircleDiameter(rect);
            return this;
        }

        public static Point GetCirclePivot(Rectangle rect)
        {
            return new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
        }

        public static int GetCircleDiameter(Rectangle rect)
        {
            return Math.Min(rect.Width / 2, rect.Height / 2);
        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)(_pivot.X - _radius), (int)(_pivot.Y - _radius), (int)_radius * 2, (int)_radius * 2);
        }

        public static Rectangle GetBounds(Rectangle rect)
        {
            Point p = GetCirclePivot(rect);
            int d = GetCircleDiameter(rect);
            return new Rectangle(p.X - d, p.Y - d, d * 2, d * 2);
        }

        /// <summary>
        /// 求取两圆的圆心距
        /// </summary>
        public float Distance(Circle c)
        {
            return Distance(c.Pivot);
        }

        /// <summary>
        /// 求取指定点与该圆圆心的距离
        /// </summary>
        public float Distance(Point p)
        {
            return (float)Math.Sqrt((p.X - _pivot.X) * (p.X - _pivot.X) + (p.Y - _pivot.Y) * (p.Y - _pivot.Y));
        }

        /// <summary>
        ///     计算路径上的点坐标。
        /// </summary>
        /// <param name="sweepAngle" type="float">
        ///     <para>
        ///         极坐标下的角度。（以度为单位。）
        ///     </para>
        /// </param>
        /// <returns>
        ///     A System.Drawing.PointF value...
        /// </returns>
        public Point PointOnPath(double sweepAngle)
        {
            return new Point(_pivot.X + (int)(_radius * (float)Math.Cos(sweepAngle * (Math.PI / 180.0d))), _pivot.Y + (int)(_radius * (float)Math.Sin(sweepAngle * (Math.PI / 180.0d))));
        }

        /// <summary>
        /// 将此圆形的位置调整指定的量。
        /// </summary>
        /// <param name="x">垂直偏移该位置的量。</param>
        /// <param name="y">水平偏移该位置的量。</param>
        public void Offset(int x, int y)
        {
            _pivot.X += x;
            _pivot.Y += y;
        }

        /// <summary>
        /// 将此圆形的位置调整指定的量。
        /// </summary>
        /// <param name="pos"> 偏移该位置的量。 </param>
        public void Offset(System.Drawing.Point pos)
        {
            Offset(pos.X, pos.Y);
        }

        /// <summary>
        /// 将此 Gemini.Component.Drawing.Circle 结构放大指定量。
        /// </summary>
        /// <param name="d">半径的放大量</param>
        public void Inflate(int d)
        {
            _radius += d;
        }

        /// <summary>
        /// 测试两个  Gemini.Component.Drawing.Circle 结构的位置或大小是否不同。
        /// </summary>
        /// <param name="left">不等运算符右侧的  Gemini.Component.Drawing.Circle 结构。</param>
        /// <param name="right">不等运算符左侧的  Gemini.Component.Drawing.Circle 结构。 </param>
        /// <returns>如果两个 Gemini.Component.Drawing.Circle 结构的  Gemini.Component.Drawing.Circle.Pivot、 Gemini.Component.Drawing.Circle.Diameter 属性值中有任何一个不相等，此运算符将返回 true；否则将返回 false。</returns>
        public static bool operator !=(Circle left, Circle right)
        {
            return left._pivot == right._pivot && left._radius == right._radius;
        }

        /// <summary>
        /// 测试两个  Gemini.Component.Drawing.Circle 结构的位置或大小是否相等。
        /// </summary>
        /// <param name="left">相等运算符右侧的  Gemini.Component.Drawing.Circle 结构。</param>
        /// <param name="right">相等运算符左侧的  Gemini.Component.Drawing.Circle 结构。 </param>
        /// <returns>如果两个 Gemini.Component.Drawing.Circle 结构的  Gemini.Component.Drawing.Circle.Pivot、 Gemini.Component.Drawing.Circle.Diameter 属性值中有任何一个不相等，此运算符将返回 false；否则将返回 true。</returns>
        public static bool operator ==(Circle left, Circle right)
        {
            return !(left != right);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public static implicit operator Rectangle(Circle c)
        {
            return c.GetBounds();
        }

        public static implicit operator RectangleF(Circle c)
        {
            return (Rectangle)c;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{Pivot={0},Radius={1}}", _pivot, _radius);
        }

        #region ICloneable 成员

        public object Clone()
        {
            return new Circle(_pivot, _radius);
        }

        #endregion

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Point Pivot
        {
            get { return _pivot; }
            set { _pivot = value; }
        }
        public int Diameter
        {
            get { return _radius; }
            set { _radius = value; }
        }
    }

    public class CircleFConvertor : TypeConverter
    {
        public CircleFConvertor()
            : base()
        { }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(typeof(CircleF), attributes).Sort(new string[] { "Radius", "Pivot" });
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;
            else
                return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string)
            {
                string[] ti = ((string)value).Split(',');
                float x = float.Parse(ti[0].Substring(1));
                float y = float.Parse(ti[1].Substring(0, ti[1].Length - 1));
                float r = float.Parse(ti[2]);
                return new CircleF(new PointF(x, y), r);
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
                return true;
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (value is CircleF)
            {
                if (destinationType == typeof(string))
                {
                    CircleF c = value as CircleF;
                    return string.Format("({0},{1}),{2}", c.Pivot.X, c.Pivot.Y, c.Radius);
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    /// <summary>
    /// 封装生成高级衍生图形的各种静态方法
    /// </summary>
    public static class ExtendedShapes
    {

        /// <summary>
        /// 创建正多边形的顶点数组。
        ///  </summary>
        /// <param name="pivot">正多边形的几何中心坐标。</param>
        /// <param name="outterRadius">多边形的外接圆半径。</param>
        /// <param name="points">多边形的边数。</param>
        /// <param name="angleOffset">X轴顶角坐标偏移度数。</param>
        /// <returns>正多边形的顶点数组。</returns>
        public static PointF[] CreateRegularPolygon(PointF pivot, float outterRadius, int points, float angleOffset)
        {
            if (outterRadius < 0) throw new ArgumentOutOfRangeException("outterRadius", "多边形的外接圆半径必须大于0");
            if (points < 3) throw new ArgumentOutOfRangeException("points", "多边形的边数必须大于等于3");
            PointF[] ret = new PointF[points];
            CircleF c = new CircleF(pivot, outterRadius);
            float ang = 360.0f / points;
            for (int i = 0; i < points; i++)
            {
                ret[i] = c.PointOnPath(angleOffset + i * ang);
            }
            return ret;
        }

        /// <summary>
        /// 创建正多边形的顶点数组。
        ///  </summary>
        /// <param name="pivot">星形的几何中心坐标。</param>
        /// <param name="outterRadius">多边形的外接圆半径。</param>
        /// <param name="points">多边形的边数。</param>
        /// <returns>正多边形的顶点数组。</returns>
        public static PointF[] CreateRegularPolygon(PointF pivot, float outterRadius, int points)
        {
            return CreateRegularPolygon(pivot, outterRadius, points, 0.0f);
        }

        /// <summary>
        /// 创建一个几何规则的星形
        /// </summary>
        /// <param name="pivot">星形的几何中心坐标</param>
        /// <param name="outterRadius">星形的外环半径</param>
        /// <param name="innerRadius">星形的内环半径</param>
        /// <param name="points">星形的顶角数</param>
        /// <param name="angleOffset">X轴顶角坐标偏移度数。</param>
        /// <returns>星形的GraphicsPath对象</returns>
        public static GraphicsPath CreateStar(PointF pivot, float outterRadius, float innerRadius, int points, float angleOffset)
        {
            if (outterRadius <= innerRadius) throw new ArgumentException("参数outterRadius必须大于innerRadius。");
            if (points < 2) throw new ArgumentOutOfRangeException("points");
            GraphicsPath gp = new GraphicsPath();
            CircleF outter = new CircleF(pivot, outterRadius);
            CircleF inner = new CircleF(pivot, innerRadius);
            float ang = 360.0f / points;
            for (int i = 0; i < points; i++)
            {
                gp.AddLine(outter.PointOnPath(angleOffset + i * ang), inner.PointOnPath(angleOffset + i * ang + ang / 2.0f));
            }
            gp.CloseFigure();
            return gp;
        }

        /// <summary>
        /// 创建一个几何规则的星形
        /// </summary>
        /// <param name="pivot">星形的几何中心坐标</param>
        /// <param name="outterRadius">星形的外环半径</param>
        /// <param name="innerRadius">星形的内环半径</param>
        /// <param name="points">星形的顶角数</param>
        /// <returns>星形的GraphicsPath对象</returns>
        public static GraphicsPath CreateStar(PointF pivot, float outterRadius, float innerRadius, int points)
        {
            return CreateStar(pivot, outterRadius, innerRadius, points, 0.0f);
        }

        /// <summary>
        /// 创建进度圆环的各个叶瓣的轮廓线
        /// </summary>
        /// <param name="pivot">进度圆环的几何中心坐标</param>
        /// <param name="outterRadius">进度圆环的外边界半径</param>
        /// <param name="innerRadius">进度圆环的内边界半径</param>
        /// <param name="spokes">进度圆环的叶瓣数量</param>
        /// <param name="angleOffset">X轴顶角坐标偏移度数</param>
        /// <returns>组成进度圆环的各个叶瓣的轮廓线坐标链表</returns>
        public static List<PointF[]> CreateWaitCircleSpokes(PointF pivot, float outterRadius, float innerRadius, int spokes, float angleOffset)
        {
            if (spokes < 1) throw new ArgumentException("参数spokes必须大于等于1。");
            List<PointF[]> lst = new List<PointF[]>();
            CircleF outter = new CircleF(pivot, outterRadius);
            CircleF inner = new CircleF(pivot, innerRadius);
            float ang = 360.0f / spokes;
            for (int i = 0; i < spokes; i++)
            {
                lst.Add(new PointF[2] { outter.PointOnPath(angleOffset + i * ang), inner.PointOnPath(angleOffset + i * ang) });
            }
            return lst;
        }

        /// <summary>
        /// 创建进度圆环的各个叶瓣的轮廓线
        /// </summary>
        /// <param name="pivot">进度圆环的几何中心坐标</param>
        /// <param name="outterRadius">进度圆环的外边界半径</param>
        /// <param name="innerRadius">进度圆环的内边界半径</param>
        /// <param name="spokes">进度圆环的叶瓣数量</param>
        /// <returns>组成进度圆环的各个叶瓣的轮廓线坐标链表</returns>
        public static List<PointF[]> CreateWaitCircleSpokes(PointF pivot, float outterRadius, float innerRadius, int spokes)
        {
            return CreateWaitCircleSpokes(pivot, outterRadius, innerRadius, spokes, 0.0f);
        }

        /// <summary>
        /// 创建一个钝角矩形
        /// </summary>
        /// <param name="rect">矩形边框</param>
        /// <param name="radius">钝角半径</param>
        /// <returns>一个GraphicsPath对象,表示创建的钝角矩形</returns>
        public static GraphicsPath CreateChamferBox(RectangleF rect, float radius)
        {
            GraphicsPath gp = new GraphicsPath();
            if (radius <= 0) { gp.AddRectangle(rect); return gp; }
            gp.AddArc(rect.Right - 2 * radius, rect.Top, radius * 2, radius * 2, 270, 90);
            gp.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
            gp.AddArc(rect.Left, rect.Bottom - 2 * radius, 2 * radius, 2 * radius, 90, 90);
            gp.AddArc(rect.Left, rect.Top, 2 * radius, 2 * radius, 180, 90);
            gp.CloseFigure();
            return gp;
        }
    }
}
