using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcess
{
    class clsZooming : AclsAffineTrans
    {
        public clsZooming()
        {
        }

        override public void applyTransformation()
        {

            //zoom in
            if (lastPoint.Y < (initPoint.Y ) && resizedSize.Width < originalResizedSize.Width * 10 && resizedSize.Height < originalResizedSize.Height * 10)
            {
                resizedSize.Width = resizedSize.Width + (imageSize.Width / 20);
                resizedSize.Height = resizedSize.Height + (imageSize.Height / 20);
                zoomCenteringPoint.X = zoomCenteringPoint.X - ((imageSize.Width / 20) / 2);
                zoomCenteringPoint.Y = zoomCenteringPoint .Y- ((imageSize.Height / 20) / 2);

            }
            //zoom out
            else if ((lastPoint.Y > (initPoint.Y)) && resizedSize.Width > originalResizedSize.Width && resizedSize.Height > originalResizedSize.Height)
            {
                resizedSize.Width = resizedSize.Width - (imageSize.Width / 20);
                resizedSize.Height = resizedSize.Height - (imageSize.Height / 20);
                zoomCenteringPoint.X = zoomCenteringPoint.X + ((imageSize.Width / 20) / 2);
                zoomCenteringPoint.Y = zoomCenteringPoint.Y + ((imageSize.Height / 20) / 2);

            }
        }
    }
}
