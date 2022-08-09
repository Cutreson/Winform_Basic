using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace Zed_Graph
{
    public partial class GUI : Form
    {
        private int tickStart = 0;
        public GUI()
        {
            InitializeComponent();
        }

        private void GUI_Load(object sender, EventArgs e)
        {
            GraphPane myPane = zedGraphControl.GraphPane;
            myPane.Title.Text = "ZedGraph Demo";
            myPane.XAxis.Title.Text = "Time(s)";
            myPane.YAxis.Title.Text = "Value";
            RollingPointPairList list = new RollingPointPairList(1000);
            LineItem curve = myPane.AddCurve("y = f(x)", list, Color.Blue, SymbolType.None);

            timer.Interval = 50;   //100ms

            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 50;
            myPane.XAxis.Scale.MinorStep = 1;
            myPane.XAxis.Scale.MajorStep = 5;

            zedGraphControl.AxisChange();

            tickStart = Environment.TickCount;

        }

        private void draw(double setpoint)
        {
            if (zedGraphControl.GraphPane.CurveList.Count <= 0) return;
            LineItem curve = zedGraphControl.GraphPane.CurveList[0] as LineItem;
            if(curve == null) return;

            IPointListEdit list = curve.Points as IPointListEdit;

            if(list == null) return;

            double time = (Environment.TickCount - tickStart) / 1000.0;

            list.Add(time, Math.Sin(2.0 * Math.PI * time / 3.0));

            Scale xScale = zedGraphControl.GraphPane.XAxis.Scale;
            if( time > xScale.Max - xScale.MajorStep)
            {
                xScale.Max = time + xScale.MajorStep;
                xScale.Min = xScale.Max - 30.0;
                //xScale.Min = 0;
            }
            zedGraphControl.AxisChange();
            zedGraphControl.Invalidate();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            draw(10);
        }

        private int check = 0;
        private void btnStart_Click(object sender, EventArgs e)
        {
            if(btnStart.Text == "Start")
            {
                timer.Enabled = true;
                btnStart.Text = "Stop";
            }
            if(check == 0)
            {
                tickStart = Environment.TickCount;
                check = 1;
            }
            else
            {
                timer.Enabled = false;
                btnStart.Text = "Start";
            }
        }
    }
}
