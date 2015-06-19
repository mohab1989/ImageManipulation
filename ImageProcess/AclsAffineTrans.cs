using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcess
{
    abstract class AclsAffineTrans
    {
       public Size imageSize, resizedSize, originalResizedSize;
       public Point initPoint, lastPoint ,pBox , pannedPoint, zoomCenteringPoint;

       abstract public void applyTransformation();

    }
}
