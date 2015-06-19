using System.Drawing;
using System.Windows.Forms;

namespace ImageProcess
{
    public partial class customLine : Control
    {
        public Point initPoint, lastPoint;

        public customLine()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            using (Pen pen = new Pen(Color.Red))
            {


                pe.Graphics.DrawLine(pen, initPoint.X, initPoint.Y, lastPoint.X, lastPoint.Y);
            }
        }
    }
}
