using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ImageProcess
{
    class clsGrayScaleFilter : AclsColorFilters
    {
        //properties

        //constructor
        public clsGrayScaleFilter(Bitmap i)
        {
            image = i;
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
                        int gray;
                        Color pixel = image.GetPixel(j, i);
                        gray=((pixel.R + pixel .G + pixel .B )/3);
                        image.SetPixel(j, i, Color.FromArgb(gray, gray, gray));
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
