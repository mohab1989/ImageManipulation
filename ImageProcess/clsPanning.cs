using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcess
{
    class clsPanning: AclsAffineTrans
    {
        public clsPanning() 
        {
        }

        override public void applyTransformation()
        {

            int deltaX = lastPoint.X - initPoint.X;
            int deltaY = lastPoint.Y - initPoint.Y;

            pannedPoint.X = pBox.X + deltaX;
            pannedPoint.Y = pBox.Y + deltaY;

        }
    }
}
