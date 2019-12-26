/*
 * Oliver Blaser
 * 
 * c:   03.09.2018
 * e:   03.09.2018
 * 
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomNETlib
{
    namespace Controls
    {
        namespace CustomProgressBar
        {
            public class CustomProgressBar : System.Windows.Forms.Control
            {
                //
                // private attributes without public
                //
                private PictureBox PBcontent;
                private int _relativeZero;
                private double _calc_a;
                private double _calc_b;

                //
                // private attributes with public
                //
                private Direction _Direction;
                private Perspective _Perspective;
                private int _Maximum;
                private int _Minimum;
                private int _Value;
                private int _Step;
                private int _BorderWidth;
                private Brush _BorderColor;
                private Brush _ForeColor;
                private Brush _BackColor;

                //
                // public attributes
                //
                #region public attributes
                public Direction Direction
                {
                    get { return _Direction; }
                    set { _Direction = value; this.Invalidate(); }
                }

                public Perspective Perspective
                {
                    get { return _Perspective; }
                    set { _Perspective = value; this.Invalidate(); }
                }

                public int Maximum
                {
                    get { return _Maximum; }
                    set { _Maximum = value; _Recalc_calc(); OnMaximumChanged(EventArgs.Empty); this.Invalidate(); }
                }

                public int Minimum
                {
                    get { return _Minimum; }
                    set { _Minimum = value; _Recalc_calc(); OnMinimumChanged(EventArgs.Empty); this.Invalidate(); }
                }

                public int Value
                {
                    get { return _Value; }
                    set { _Value = value; OnValueChanged(EventArgs.Empty); this.Invalidate(); }
                }

                public int Step
                {
                    get { return _Step; }
                    set { _Step = value; }
                }

                public int BorderWidth
                {
                    get { return _BorderWidth; }
                    set { _BorderWidth = value; this.Invalidate(); }
                }

                public Brush BorderColor
                {
                    get { return _BorderColor; }
                    set { _BorderColor = value; this.Invalidate(); }
                }

                public Brush ForeColor
                {
                    get { return _ForeColor; }
                    set { _ForeColor = value; base.OnForeColorChanged(EventArgs.Empty); this.Invalidate(); }
                }

                public Brush BackColor
                {
                    get { return _BackColor; }
                    set { _BackColor = value; base.OnBackColorChanged(EventArgs.Empty); this.Invalidate(); }
                }
                #endregion // public attributes

                //
                // private methods
                //
                private void _Recalc_calc()
                {
                    if (this.Direction == Direction.Right || this.Direction == Direction.Left)
                    {
                        _calc_a = (-(Convert.ToDouble(this.Size.Width))) / (Convert.ToDouble(this.Minimum) - Convert.ToDouble(this.Maximum));
                        _calc_b = (Convert.ToDouble(this.Size.Width) * Convert.ToDouble(this.Minimum)) / (Convert.ToDouble(this.Minimum) - Convert.ToDouble(this.Maximum));
                    }

                    else
                    {
                        _calc_a = (-(Convert.ToDouble(this.Size.Height))) / (Convert.ToDouble(this.Minimum) - Convert.ToDouble(this.Maximum));
                        _calc_b = (Convert.ToDouble(this.Size.Height) * Convert.ToDouble(this.Minimum)) / (Convert.ToDouble(this.Minimum) - Convert.ToDouble(this.Maximum));

                    }
                }

                private void _Resize(object sender, EventArgs e)
                {
                    PBcontent.Size = this.Size;
                    PBcontent.Invalidate();
                }

                private void _PBcontent_PaintHorizontal(PaintEventArgs e)
                {
                    if (Perspective == Perspective.Normal) // fill over background
                    {
                        // background
                        e.Graphics.FillRectangle(this.BackColor, new Rectangle(new Point(0, 0), this.Size));

                        // fill
                        double Width = _calc_a * this.Value + _calc_b;

                        if (this.Value < Convert.ToDouble(this.Minimum)) Width = 0;
                        else if (this.Value > Convert.ToDouble(this.Maximum)) Width = Convert.ToDouble(this.Size.Width);

                        Width = Math.Round(Width, 0, MidpointRounding.AwayFromZero);

                        if (Direction == Direction.Left) _relativeZero = (this.Size.Width - Convert.ToInt32(Width));
                        else _relativeZero = 0;

                        Rectangle RectFill = new Rectangle(new Point(_relativeZero, 0), new Size(Convert.ToInt32(Width), this.Size.Height));
                        e.Graphics.FillRectangle(this.ForeColor, RectFill);
                    }

                    else // background over fill
                    {
                        // fill
                        e.Graphics.FillRectangle(this.ForeColor, new Rectangle(new Point(0, 0), this.Size));

                        // background
                        double Width = _calc_a * this.Value + _calc_b;

                        if (this.Value < Convert.ToDouble(this.Minimum)) Width = 0;
                        else if (this.Value > Convert.ToDouble(this.Maximum)) Width = Convert.ToDouble(this.Size.Width);

                        Width = Convert.ToDouble(this.Size.Width) - Math.Round(Width, 0, MidpointRounding.AwayFromZero);

                        if (Direction == Direction.Left) _relativeZero = 0;
                        else _relativeZero = (this.Size.Width - Convert.ToInt32(Width));

                        Rectangle RectFill = new Rectangle(new Point(_relativeZero, 0), new Size(Convert.ToInt32(Width), this.Size.Height));
                        e.Graphics.FillRectangle(this.BackColor, RectFill);
                    }
                }

                private void _PBcontent_PaintVertical(PaintEventArgs e)
                {
                    if (Perspective == Perspective.Normal) // fill over background
                    {
                        // background
                        e.Graphics.FillRectangle(this.BackColor, new Rectangle(new Point(0, 0), this.Size));

                        // fill
                        double height = _calc_a * this.Value + _calc_b;

                        if (this.Value < Convert.ToDouble(this.Minimum)) height = 0;
                        else if (this.Value > Convert.ToDouble(this.Maximum)) height = Convert.ToDouble(this.Size.Height);

                        height = Math.Round(height, 0, MidpointRounding.AwayFromZero);

                        if (Direction == Direction.Up) _relativeZero = (this.Size.Height - Convert.ToInt32(height));
                        else _relativeZero = 0;

                        Rectangle RectFill = new Rectangle(new Point(0, _relativeZero), new Size(this.Size.Width, Convert.ToInt32(height)));
                        e.Graphics.FillRectangle(this.ForeColor, RectFill);
                    }

                    else // background over fill
                    {
                        // fill
                        e.Graphics.FillRectangle(this.ForeColor, new Rectangle(new Point(0, 0), this.Size));

                        // background
                        double height = _calc_a * this.Value + _calc_b;

                        if (this.Value < Convert.ToDouble(this.Minimum)) height = 0;
                        else if (this.Value > Convert.ToDouble(this.Maximum)) height = Convert.ToDouble(this.Size.Height);

                        height = Convert.ToDouble(this.Size.Height) - Math.Round(height, 0, MidpointRounding.AwayFromZero);

                        if (Direction == Direction.Up) _relativeZero = 0;
                        else _relativeZero = (this.Size.Height - Convert.ToInt32(height));

                        Rectangle RectFill = new Rectangle(new Point(0, _relativeZero), new Size(this.Size.Width, Convert.ToInt32(height)));
                        e.Graphics.FillRectangle(this.BackColor, RectFill);
                    }
                }

                private void _PBcontent_Paint(object sender, PaintEventArgs e)
                {
                    // fill and background
                    if (this.Direction == Direction.Right || this.Direction == Direction.Left) _PBcontent_PaintHorizontal(e);
                    else _PBcontent_PaintVertical(e);

                    // border
                    e.Graphics.DrawRectangle(new Pen(this.BorderColor, BorderWidth), new Rectangle(new Point(0, 0), this.Size));
                }

                //
                // public methods
                //
                public void PerformStep()
                {
                    Value += Step;
                }

                /// <summary>
                /// Returns the Point, where the Value would be.
                /// </summary>
                /// <param name="value">Value</param>
                /// <returns>Position in the PictureBox</returns>
                public int getPositionOfValue(int value)
                {
                    double result = (_calc_a * Convert.ToDouble(value) + _calc_b);

                    result = Math.Round(result, MidpointRounding.AwayFromZero);

                    return Convert.ToInt32(result);
                }

                //
                // constructor
                //
                public CustomProgressBar()
                {
                    this.Size = new Size(100, 23);
                    this._Direction = Direction.Right;
                    this._Perspective = Perspective.Normal;
                    _Maximum = 100;
                    _Minimum = 0;
                    _Value = 0;
                    _Step = 1;
                    _BorderWidth = 2;
                    _BorderColor = new SolidBrush(Color.FromKnownColor(KnownColor.ControlDarkDark));
                    _ForeColor = new SolidBrush(Color.FromKnownColor(KnownColor.Highlight));
                    _BackColor = new SolidBrush(Color.FromKnownColor(KnownColor.ControlLight));

                    this.SizeChanged += new EventHandler(_Resize);

                    PBcontent = new PictureBox();
                    PBcontent.Size = this.Size;
                    PBcontent.Location = new Point(0, 0);
                    PBcontent.Paint += new PaintEventHandler(_PBcontent_Paint);
                    this.Controls.Add(PBcontent);
                }

                //
                // overrided base class events
                //
                protected override void OnPaint(PaintEventArgs pe)
                {
                    base.OnPaint(pe);

                    PBcontent.Invalidate();
                }


                //
                // events
                //
                public event EventHandler MaximumChanged;
                public event EventHandler MinimumChanged;
                public event EventHandler ValueChanged;

                //
                // event rise methods
                //
                protected virtual void OnValueChanged(EventArgs e)
                {
                    if (ValueChanged != null) ValueChanged(this, e);
                }

                protected virtual void OnMaximumChanged(EventArgs e)
                {
                    if (MaximumChanged != null) MaximumChanged(this, e);
                }

                protected virtual void OnMinimumChanged(EventArgs e)
                {
                    if (MinimumChanged != null) MinimumChanged(this, e);
                }
            }

            public enum Perspective
            {
                Normal,
                Reversed
            }

            public enum Direction
            {
                Right,
                Left,
                Up,
                Down
            }
        }
    }
}
