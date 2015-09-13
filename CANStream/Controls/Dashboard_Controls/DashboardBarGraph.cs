using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CANStream
{
    #region Enums

    public enum BarGraphDirection
    {
        Horizontal = 0,
        Vertical = 1,
    }

    #endregion

    public partial class DashboardBarGraph : UserControl
    {
        #region Private constants

        private const float SCALE_POS_OFFSET = 5;
        private const float SCALE_DIV_SIZE = 5;
        private const float SCALE_TXT_POS_OFFSET = 3;

        #endregion

        #region Properties

        [Browsable(true)]
        [CategoryAttribute("Settings")]
        [DescriptionAttribute("Name of the object")]
        public string Title
        {
            get
            {
                return (Lbl_Title.Text);
            }

            set
            {
                Lbl_Title.Text = value;
            }
        }

        [Browsable(true)]
        [CategoryAttribute("Settings")]
        [DescriptionAttribute("Name of the object")]
        public double Value
        {
            get
            {
                return (mValue);
            }

            set
            {
                mValue = value;

                if (mValue < MinValue)
                {
                    MinValue = mValue;
                    bNewMinMax = true;
                }

                if (mValue > MaxValue)
                {
                    MaxValue = mValue;
                    bNewMinMax = true;
                }

                DrawBarGraph();
            }
        }

        [Browsable(true)]
        [CategoryAttribute("Settings")]
        [DescriptionAttribute("Name of the object")]
        public BarGraphDirection Direction
        {
            get
            {
                return (mDirection);
            }

            set
            {
                SetBarGraph(value);
                DrawBarGraph();
            }
        }

        [Browsable(true)]
        [CategoryAttribute("Settings")]
        [DescriptionAttribute("Name of the object")]
        public Color ControlBackColor
        {
            get
            {
                return (this.BackColor);
            }

            set
            {
                this.BackColor = value;
            }
        }

        [Browsable(true)]
        [CategoryAttribute("Settings")]
        [DescriptionAttribute("Name of the object")]
        public double Min
        {
            get
            {
                return (mMin);
            }

            set
            {
                mMin = value;
                DrawBarGraph();
            }
        }

        [Browsable(true)]
        [CategoryAttribute("Settings")]
        [DescriptionAttribute("Name of the object")]
        public double Max
        {
            get
            {
                return (mMax);
            }

            set
            {
                mMax = value;
                DrawBarGraph();
            }
        }

        [Browsable(true)]
        [CategoryAttribute("Settings")]
        [DescriptionAttribute("Name of the object")]
        public double AlarmMin
        {
            get
            {
                return (mAlarmMin);
            }

            set
            {
                mAlarmMin = value;
                DrawBarGraph();
            }
        }

        [Browsable(true)]
        [CategoryAttribute("Settings")]
        [DescriptionAttribute("Name of the object")]
        public double AlarmMax
        {
            get
            {
                return (mAlarmMax);
            }

            set
            {
                mAlarmMax = value;
                DrawBarGraph();
            }
        }

        [Browsable(true)]
        [CategoryAttribute("Settings")]
        [DescriptionAttribute("Name of the object")]
        public bool ShowValue
        {
            get
            {
                return (Lbl_Value.Visible);
            }

            set
            {
                Lbl_Value.Visible = value;
                SetBarGraph(mDirection);
            }
        }

        [Browsable(true)]
        [CategoryAttribute("Settings")]
        [DescriptionAttribute("Name of the object")]
        public bool ShowMinMaxValues
        {
            get
            {
                return (Lbl_MinValue.Visible);
            }

            set
            {
                Lbl_MinValue.Visible = value;
                Lbl_MaxValue.Visible = value;
                SetBarGraph(mDirection);
            }
        }

        [Browsable(true)]
        [CategoryAttribute("Settings")]
        [DescriptionAttribute("Name of the object")]
        public bool ScaleVisible
        {
            get
            {
                return (Pic_Scale.Visible);
            }

            set
            {
                Pic_Scale.Visible = value;
                DrawBarGraph();
            }
        }

        [Browsable(true)]
        [CategoryAttribute("Settings")]
        [DescriptionAttribute("Name of the object")]
        public int ScaleDivisionCount
        {
            get
            {
                return (mScaleDivisionCount);
            }

            set
            {
                mScaleDivisionCount = value;
                DrawBarGraph();
            }
        }

        [Browsable(true)]
        [CategoryAttribute("Settings")]
        [DescriptionAttribute("Name of the object")]
        public bool ShowScaleValues
        {
            get
            {
                return (mShowScaleValues);
            }

            set
            {
                mShowScaleValues = value;
                DrawBarGraph();
            }
        }

        [Browsable(true)]
        [CategoryAttribute("Settings")]
        [DescriptionAttribute("Name of the object")]
        public Font ScaleFont
        {
            get
            {
                return (mScaleFont);
            }

            set
            {
                mScaleFont = value;
                DrawBarGraph();
            }
        }

        [Browsable(true)]
        [CategoryAttribute("Settings")]
        [DescriptionAttribute("Name of the object")]
        public bool ShowMinMaxIndicators
        {
            get
            {
                return (mShowMinMaxIndicators);
            }

            set
            {
                mShowMinMaxIndicators = value;
            }
        }

        [Browsable(true)]
        [CategoryAttribute("Settings")]
        [DescriptionAttribute("Name of the object")]
        public Color BarBackColor
        {
            get
            {
                return (Pic_BarGraph.BackColor);
            }

            set
            {
                Pic_BarGraph.BackColor = value;
            }
        }

        [Browsable(true)]
        [CategoryAttribute("Settings")]
        [DescriptionAttribute("Name of the object")]
        public Color BarColor
        {
            get
            {
                return (mBarColor);
            }

            set
            {
                mBarColor = value;
                DrawBarGraph();
            }
        }

        [Browsable(true)]
        [CategoryAttribute("Settings")]
        [DescriptionAttribute("Name of the object")]
        public Color AlarmMinColor
        {
            get
            {
                return (mAlarmMinColor);
            }

            set
            {
                mAlarmMinColor = value;
                DrawBarGraph();
            }
        }

        [Browsable(true)]
        [CategoryAttribute("Settings")]
        [DescriptionAttribute("Name of the object")]
        public Color AlarmMaxColor
        {
            get
            {
                return (mAlarmMaxColor);
            }

            set
            {
                mAlarmMaxColor = value;
                DrawBarGraph();
            }
        }

        [Browsable(true)]
        [CategoryAttribute("Settings")]
        [DescriptionAttribute("Name of the object")]
        public Color ScaleColor
        {
            get
            {
                return (mScaleColor);
            }

            set
            {
                mScaleColor = value;
                DrawBarGraph();
            }
        }

        #endregion

        #region Private members

        private double mValue;
        private BarGraphDirection mDirection;
        private double mMin;
        private double mMax;
        private double mAlarmMin;
        private double mAlarmMax;
        private int mScaleDivisionCount;
        private bool mShowScaleValues;
        private Font mScaleFont;
        private bool mShowMinMaxIndicators;
        private Color mBarColor;
        private Color mAlarmMinColor;
        private Color mAlarmMaxColor;
        private Color mScaleColor;

        private bool bNewMinMax;
        private double MinValue;
        private double MaxValue;

        #endregion

        public DashboardBarGraph()
        {
            InitializeComponent();

            PropertyDescriptor descriptor = TypeDescriptor.GetProperties(this.GetType())["Anchor"];
            BrowsableAttribute attrib = (BrowsableAttribute)descriptor.Attributes[typeof(BrowsableAttribute)];
            FieldInfo isBrow = attrib.GetType().GetField("browsable", BindingFlags.NonPublic | BindingFlags.Instance);
            isBrow.SetValue(attrib, false);

            //Members init
            mValue = 0;
            mDirection = BarGraphDirection.Horizontal;
            mMin = 0;
            mMax = 100;
            mAlarmMin = 0;
            mAlarmMax = 0;
            mScaleDivisionCount = 10;
            mShowScaleValues = true;
            mScaleFont = new Font("Microsoft Sans Serif", (float)(8.25), new FontStyle());
            mBarColor = Color.Green;
            mAlarmMinColor = Color.Red;
            mAlarmMaxColor = Color.Red;
            mScaleColor = Color.Black;

            bNewMinMax = false;

            DrawBarGraph();
        }

        #region Private methodes

        private void SetBarGraph(BarGraphDirection BarDirection)
        {
            this.SuspendLayout();

            if (BarDirection!=mDirection) //Control bar graph direction change
            {
                switch(mDirection)
                {
                    case BarGraphDirection.Horizontal: //Current direction is horizontal => switch to vertical

                        int NewWidth = Pic_BarGraph.Height + 20;
                        if (Pic_Scale.Visible) NewWidth += (Pic_Scale.Height + 10);

                        int NewHeigth = Pic_BarGraph.Width + 20;
                        if (Lbl_Value.Visible) NewHeigth += (Lbl_Value.Height + 5);
                        if (Lbl_MinValue.Visible) NewHeigth += (Lbl_MinValue.Height + Lbl_MaxValue.Height + 5);

                        this.Height = NewHeigth;
                        this.Width = NewWidth;

                        int NewLeft = 10;
                        int NewTop = 10;

                        if (Pic_Scale.Visible)
                        {
                            NewWidth = Pic_Scale.Height;
                            NewHeigth = Pic_Scale.Width;

                            Pic_Scale.Height = NewHeigth;
                            Pic_Scale.Width = NewWidth;
                            Pic_Scale.Top = NewTop;
                            Pic_Scale.Left = NewLeft;

                            NewLeft += Pic_Scale.Width + 10;
                        }

                        NewWidth = Pic_BarGraph.Height;
                        NewHeigth = Pic_BarGraph.Width;

                        Pic_BarGraph.Height = NewHeigth;
                        Pic_BarGraph.Width = NewWidth;
                        Pic_BarGraph.Top = NewTop;
                        Pic_BarGraph.Left = NewLeft;

                        NewTop += Pic_BarGraph.Height + 10;

                        //TODO: Ici
                        //Dimensionner & placer les labels value, MinValue & MaxValue 

                        break;

                    case BarGraphDirection.Vertical: //Current direction is vertical => switch to horizontal

                        //TODO: Coder le changement vertical vers horizontal

                        break;
                }

                mDirection = BarDirection;
            }

            this.ResumeLayout(true);
        }

        private void DrawBarGraph()
        {
            this.SuspendLayout();

            #region  Scale drawing

            if (Pic_Scale.Visible)
            {
                Image ScaleImage = new Bitmap(Pic_Scale.Width, Pic_Scale.Height);

                Graphics gScale = Graphics.FromImage(ScaleImage);
                gScale.Clear(this.BackColor);

                PointF ptStart = PointF.Empty;
                PointF ptEnd = PointF.Empty;
                PointF ptScale = PointF.Empty;
                PointF ptScale2 = PointF.Empty;

                if (mDirection.Equals(BarGraphDirection.Horizontal))
                {
                    ptStart.X = (float)0;
                    ptStart.Y = (float)(Pic_Scale.Height - 1);

                    ptEnd.X = (float)Pic_Scale.Width - 1;
                    ptEnd.Y = ptStart.Y;
                }
                else
                {
                    ptStart.X = (float)(Pic_Scale.Width - 1);
                    ptStart.Y = (float)Pic_Scale.Height - 1;

                    ptEnd.X = ptStart.X;
                    ptEnd.Y = (float)0;
                }

                Pen p = new Pen(mScaleColor, 1);

                gScale.DrawLine(p, ptStart, ptEnd); //Scale line

                if (mDirection.Equals(BarGraphDirection.Horizontal))
                {
                    ptScale = new PointF(ptEnd.X, ptEnd.Y - SCALE_DIV_SIZE);
                }
                else
                {
                    ptScale = new PointF(ptEnd.X - SCALE_DIV_SIZE, ptEnd.Y);
                }

                gScale.DrawLine(p, ptEnd, ptScale);

                if (mDirection.Equals(BarGraphDirection.Horizontal))
                {
                    ptScale = new PointF(ptStart.X, ptStart.Y - SCALE_DIV_SIZE);
                }
                else
                {
                    ptScale = new PointF(ptStart.X - SCALE_DIV_SIZE, ptStart.Y);
                }

                gScale.DrawLine(p, ptStart, ptScale);

                if (mShowScaleValues)
                {
                    DrawScaleValue(mMin, ptStart, gScale);
                    DrawScaleValue(mMax, ptEnd, gScale);
                }

                if (mScaleDivisionCount > 0)
                {
                    if (mDirection.Equals(BarGraphDirection.Horizontal))
                    {
                        ptScale.Y = ptStart.Y;
                        ptScale2.Y = ptScale.Y - SCALE_DIV_SIZE;
                    }
                    else
                    {
                        ptScale.X = ptStart.X;
                        ptScale2.X = ptScale.X - SCALE_DIV_SIZE;
                    }

                    for (int iDiv = 0; iDiv < mScaleDivisionCount - 1; iDiv++)
                    {
                        if (mDirection.Equals(BarGraphDirection.Horizontal))
                        {
                            ptScale.X += (float)((ptEnd.X - ptStart.X) / mScaleDivisionCount);
                            ptScale2.X = ptScale.X;
                        }
                        else
                        {
                            ptScale.Y += (float)((ptStart.Y - ptEnd.Y) / mScaleDivisionCount);
                            ptScale.Y = ptScale.Y;
                        }

                        gScale.DrawLine(p, ptScale, ptScale2);

                        if (mShowScaleValues)
                        {
                            double DivValue = (double)(((mMax - mMin) / mScaleDivisionCount) * (iDiv + 1));
                            DrawScaleValue(DivValue, ptScale, gScale);
                        }
                    }
                }

                Pic_Scale.Image = ScaleImage;

                p.Dispose();
                gScale.Dispose();
            }

            #endregion

            //Value labels updating
            if(Lbl_Value.Visible)
            {
                Lbl_Value.Text = mValue.ToString();
            }

            if (Lbl_MinValue.Visible && bNewMinMax)
            {
                Lbl_MinValue.Text = MinValue.ToString();
                Lbl_MaxValue.Text = MaxValue.ToString();
            }

            //Bar drawing
            Image BarImage = new Bitmap(Pic_BarGraph.Width, Pic_BarGraph.Height);

            Graphics gBar = Graphics.FromImage(BarImage);
            gBar.Clear(Pic_BarGraph.BackColor);


            if(mValue>mMin)
            {
                //Bar size
                RectangleF rBar = new RectangleF();

                if (Direction.Equals(BarGraphDirection.Horizontal))
                {
                    rBar.Height = (float)Pic_BarGraph.Height;

                    if (mValue>=mMax)
                    {
                        rBar.Width = (float)Pic_BarGraph.Width;
                    }
                    else
                    {
                        rBar.Width = (float)((mValue * (double)Pic_BarGraph.Width) / (mMax - mMin));
                    }

                    rBar.Location = new PointF(0, 0);
                }
                else
                {
                    rBar.Width = (float)Pic_BarGraph.Width;

                    if (mValue >= mMax)
                    {
                        rBar.Height = (float)Pic_BarGraph.Height;
                    }
                    else
                    {
                        rBar.Height = (float)((mValue * (double)Pic_BarGraph.Height) / (mMax - mMin));
                    }

                    rBar.Location = new PointF(0, ((float)Pic_BarGraph.Height - rBar.Height));
                }

                //Bar color
                Color cBar = mBarColor;

                if ((mValue <= mAlarmMin) && (mAlarmMax != mAlarmMin))
                {
                    cBar = mAlarmMinColor;
                }

                if ((mValue >= mAlarmMax) && (mAlarmMax != mAlarmMin))
                {
                    cBar = mAlarmMaxColor;
                }

                SolidBrush b = new SolidBrush(cBar);
                gBar.FillRectangle(b, rBar);

                b.Dispose();
            }

            Pic_BarGraph.Image = BarImage;
            gBar.Dispose();

            //Min/Max indicators
            if (mShowMinMaxIndicators && bNewMinMax)
            {
                bNewMinMax = false;

                Image CtrlImage = new Bitmap(this.Width, this.Height);

                Graphics gCtrl = Graphics.FromImage(CtrlImage);
                gCtrl.Clear(this.BackColor);

                SetMarker(MinValue, gCtrl);
                SetMarker(MaxValue, gCtrl);

                this.BackgroundImage = CtrlImage;
                gCtrl.Dispose();
            }

            this.ResumeLayout(true);
        }

        private void DrawScaleValue(double Value, PointF OriginPoint, Graphics oGraph)
        {
            SolidBrush b = new SolidBrush(mScaleColor);
            string sVal = Value.ToString();
            SizeF TxtSize = oGraph.MeasureString(sVal, mScaleFont);

            switch(mDirection)
            {
                case BarGraphDirection.Horizontal:

                    OriginPoint.X -= (TxtSize.Width / 2);
                    OriginPoint.Y -= (TxtSize.Height + (SCALE_DIV_SIZE + SCALE_TXT_POS_OFFSET));
                    break;

                case BarGraphDirection.Vertical:

                    OriginPoint.X -= (TxtSize.Width + (SCALE_DIV_SIZE + SCALE_TXT_POS_OFFSET));
                    OriginPoint.Y -= (TxtSize.Height / 2);
                    break;
            }

            if (OriginPoint.X < 0)
            {
                OriginPoint.X = 0;
            }
            else if (OriginPoint.X + TxtSize.Width > (float)Pic_Scale.Width)
            {
                OriginPoint.X = (float)Pic_Scale.Width - TxtSize.Width;
            }

            if (OriginPoint.Y < 0)
            {
                OriginPoint.Y = 0;
            }
            else if (OriginPoint.Y + TxtSize.Height > (float)Pic_Scale.Height)
            {
                OriginPoint.Y = (float)Pic_Scale.Height - TxtSize.Height;
            }

            oGraph.DrawString(sVal, mScaleFont, b, OriginPoint);

            b.Dispose();
        }

        private void SetMarker(Double Value, Graphics oGraph)
        {
            PointF[] ptMarker = new PointF[3];

            if ((Value > mMin) && (Value < mMax))
            {
                ptMarker[0] = new PointF(0, 0);

                if (mDirection.Equals(BarGraphDirection.Horizontal))
                {
                    ptMarker[0].Y = (float)Pic_BarGraph.Top;
                    ptMarker[0].X = (float)(((Value * (double)Pic_BarGraph.Width) / (mMax - mMin)) + (float)Pic_BarGraph.Left);

                    ptMarker[1] = new PointF(ptMarker[0].X - 5, ptMarker[0].Y - 5);
                    ptMarker[2] = new PointF(ptMarker[0].X + 5, ptMarker[0].Y - 5);
                }
                else
                {
                    ptMarker[0].X = (float)Pic_BarGraph.Left;
                    ptMarker[0].Y = (float)(((float)(Pic_BarGraph.Height + Pic_Scale.Top)) - ((float)(Value * (double)Pic_BarGraph.Width) / (mMax - mMin)));

                    ptMarker[1] = new PointF(ptMarker[0].X - 5, ptMarker[0].Y + 5);
                    ptMarker[2] = new PointF(ptMarker[0].X - 5, ptMarker[0].Y - 5);
                }

                Color cMark = mBarColor;

                if ((Value <= mAlarmMin) && (mAlarmMax != mAlarmMin))
                {
                    cMark = mAlarmMinColor;
                }

                if ((Value >= mAlarmMax) && (mAlarmMax != mAlarmMin))
                {
                    cMark = mAlarmMaxColor;
                }

                SolidBrush b = new SolidBrush(cMark);

                oGraph.FillPolygon(b, ptMarker);
                b.Dispose();

            }
        }

        #endregion
    }
}
