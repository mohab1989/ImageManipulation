using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ImageProcess
{
    class clsInvertFilter : AclsColorFilters
    {
        //properties
     
        //constructor
        public clsInvertFilter(Bitmap i)
        {
            image =i;
        }
        // methods
         public override Bitmap applyFilter()
        {
            try
            {
                for (int i = 0; i < image.Height; i++)
                {
                    for (int j = 0; j < image.Width; j++)
                    {
                        int r, g, b;
                        Color pixel = image.GetPixel(j, i);
                        r = 255 - pixel.R;
                        g = 255 - pixel.G;
                        b = 255 - pixel.B;
                        image.SetPixel(j, i, Color.FromArgb(r, g, b));
                    }
                }
            }
            catch
            {

            }
         
            return image;
        }

    }
}
