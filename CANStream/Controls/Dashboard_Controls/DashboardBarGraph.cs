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

        private const int CTRL_SIZE_BAR_OFFSET = 10;
        private const int BAR_LEFT_BASE = 5;
        private const int BAR_TOP_BASE = 5;
        private const int PIC_SCALE_POS_OFFSET = 5;
        private const int LBL_VALUE_POS_OFFSET = 5;
        private const int LBL_VALUE_BASE_POS = 5;
        private const int LBL_VALUE_BASE_WIDTH = 71;
        private const int LBL_VALUE_BASE_HEIGHT = 33;
        private const int LBL_TITLE_POS_OFFSET = 5;
        private const int LBL_TILTE_BASE_POS = 5;

        #endregion

        #region Properties

        //TODO: Set category & description for each properties

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
                int CtrlWidthBarDelta = (CTRL_SIZE_BAR_OFFSET * 2);
                int CtrlHeightBarDelta = (CTRL_SIZE_BAR_OFFSET * 2);

                int BarWidth = Pic_BarGraph.Height;
                int BarHeigth = Pic_BarGraph.Width;
                int BarLeft = BAR_LEFT_BASE;
                int BarTop = BAR_TOP_BASE;

                int ScaleWidth = Pic_Scale.Height;
                int ScaleHeigth = Pic_Scale.Width;
                int ScaleLeft = BAR_LEFT_BASE;
                int ScaleTop = BAR_TOP_BASE;

                int LblValueWidth = 0;
                int LblValueHeight = 0;
                int LblValueLeft = 0;
                int LblValueTop = 0;

                int LblMinWidth = 0;
                int LblMinHeight = 0;
                int LblMinLeft = 0;
                int LblMinTop = 0;

                mDirection = BarDirection;

                switch (mDirection)
                {
                    case BarGraphDirection.Horizontal: //Current direction is horizontal => switch to vertical

                        //Scale
                        if (Pic_Scale.Visible)
                        {
                            CtrlHeightBarDelta += (ScaleHeigth + PIC_SCALE_POS_OFFSET);
                            BarTop += (ScaleHeigth + PIC_SCALE_POS_OFFSET);
                        }

                        //Value label
                        if (Lbl_Value.Visible)
                        {
                            if (!(Pic_Scale.Visible))
                            {
                                CtrlHeightBarDelta += (LBL_VALUE_BASE_HEIGHT + LBL_VALUE_BASE_POS);
                                BarTop += (LBL_VALUE_BASE_HEIGHT + LBL_VALUE_BASE_POS);

                                LblValueHeight = LBL_VALUE_BASE_HEIGHT;
                            }
                            else
                            {
                                LblValueHeight = ScaleHeigth;
                            }
                           
                            LblValueWidth = LBL_VALUE_BASE_WIDTH;
                            LblValueLeft = LBL_VALUE_BASE_POS;
                            LblValueTop = LBL_VALUE_BASE_POS;

                            BarLeft += (LblValueWidth + LBL_VALUE_POS_OFFSET);
                            ScaleLeft += (LblValueWidth + LBL_VALUE_POS_OFFSET);

                            CtrlWidthBarDelta += (LblValueWidth + LBL_VALUE_POS_OFFSET);
                        }

                        //Min & Max lablels
                        if (Lbl_MinValue.Visible)
                        {
                            LblMinWidth = LBL_VALUE_BASE_WIDTH;
                            LblMinHeight = BarHeigth / 2;
                            LblMinLeft = LBL_VALUE_POS_OFFSET;
                            LblMinTop = BarTop;

                            if (!(Lbl_Value.Visible))
                            {
                                CtrlWidthBarDelta += (LblMinWidth + LBL_VALUE_POS_OFFSET);
                                BarLeft += (LblMinWidth + LBL_VALUE_POS_OFFSET);
                                ScaleLeft += (LblMinWidth + LBL_VALUE_POS_OFFSET);
                            }
                        }

                        //Title label
                        if (Lbl_Title.Visible)
                        {
                            CtrlHeightBarDelta += (Lbl_Title.Height + (LBL_TITLE_POS_OFFSET * 2));
                        }

                        break;

                    case BarGraphDirection.Vertical: //Current direction is vertical => switch to horizontal

                        //Scale
                        if(Pic_Scale.Visible)
                        {
                            CtrlWidthBarDelta += (ScaleWidth + PIC_SCALE_POS_OFFSET);
                            BarLeft += (ScaleWidth + PIC_SCALE_POS_OFFSET);
                        }

                        //Value label
                        if (Lbl_Value.Visible)
                        {
                            if (Pic_Scale.Visible)
                            {
                                LblValueWidth = ScaleWidth + PIC_SCALE_POS_OFFSET + BarWidth;
                            }
                            else
                            {
                                LblValueWidth = LBL_VALUE_BASE_WIDTH;

                                if ((BarWidth + CtrlWidthBarDelta) < LblValueWidth)
                                {
                                    int WidthInc = LblValueWidth - (BarWidth + CtrlWidthBarDelta);

                                    CtrlWidthBarDelta += WidthInc;
                                    BarLeft += (WidthInc / 2);
                                }
                            }
                            
                            LblValueHeight = LBL_VALUE_BASE_HEIGHT;
                            LblValueLeft = LBL_VALUE_POS_OFFSET;
                            LblValueTop = BarTop + BarHeigth + LBL_VALUE_POS_OFFSET;

                            CtrlHeightBarDelta += (LblValueHeight + LBL_VALUE_POS_OFFSET);
                        }

                        //Min & Max lablels
                        if (Lbl_MinValue.Visible)
                        {
                            if(Pic_Scale.Visible)
                            {
                                LblMinWidth = ScaleWidth + PIC_SCALE_POS_OFFSET + BarWidth;
                            }
                            else
                            {
                                LblMinWidth = LBL_VALUE_BASE_WIDTH;

                                if ((BarWidth + CtrlWidthBarDelta) < LblMinWidth)
                                {
                                    int WidthInc = LblMinWidth - (BarWidth + CtrlWidthBarDelta);

                                    CtrlWidthBarDelta += WidthInc;
                                    BarLeft += (WidthInc / 2);
                                }
                            }

                            if(Lbl_Value.Visible)
                            {
                                LblMinTop = LblValueTop + LblValueHeight + LBL_VALUE_POS_OFFSET;
                            }
                            else
                            {
                                LblMinTop = BarTop + BarHeigth + LBL_VALUE_POS_OFFSET;
                            }

                            LblMinHeight = LBL_VALUE_BASE_HEIGHT / 2;
                            LblMinLeft = LBL_VALUE_BASE_POS;

                            CtrlHeightBarDelta += ((LblMinHeight * 2) + LBL_VALUE_POS_OFFSET);
                        }

                        //Title label
                        if (Lbl_Title.Visible)
                        {
                            CtrlHeightBarDelta += (Lbl_Title.Height + (LBL_TITLE_POS_OFFSET * 2));
                        }

                        break;
                }

                this.Width = BarWidth + CtrlWidthBarDelta;
                this.Height = BarHeigth + CtrlHeightBarDelta;

                Pic_BarGraph.Width = BarWidth;
                Pic_BarGraph.Height = BarHeigth;
                Pic_BarGraph.Left = BarLeft;
                Pic_BarGraph.Top = BarTop;

                if (Pic_Scale.Visible)
                {
                    Pic_Scale.Width = ScaleWidth;
                    Pic_Scale.Height = ScaleHeigth;
                    Pic_Scale.Left = ScaleLeft;
                    Pic_Scale.Top = ScaleTop;
                }

                if (Lbl_Value.Visible)
                {
                    Lbl_Value.Width = LblValueWidth;
                    Lbl_Value.Height = LblValueHeight;
                    Lbl_Value.Left = LblValueLeft;
                    Lbl_Value.Top = LblValueTop;
                }

                if(Lbl_MinValue.Visible)
                {
                    Lbl_MinValue.Width = LblMinWidth;
                    Lbl_MinValue.Height = LblMinHeight;
                    Lbl_MinValue.Left = LblMinLeft;
                    Lbl_MinValue.Top = LblMinTop;

                    Lbl_MaxValue.Size = Lbl_MinValue.Size;
                    Lbl_MaxValue.Left = LblMinLeft;
                    Lbl_MaxValue.Top = LblMinTop + LblMinHeight;
                }

                if (Lbl_Title.Visible)
                {
                    Lbl_Title.Left = LBL_TILTE_BASE_POS;
                    Lbl_Title.Top = this.Height - Lbl_Title.Height - (LBL_TITLE_POS_OFFSET * 2);
                }
            }

            DrawBarGraph();

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
                            ptScale.Y -= (float)((ptStart.Y - ptEnd.Y) / mScaleDivisionCount);
                            ptScale2.Y = ptScale.Y;
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
