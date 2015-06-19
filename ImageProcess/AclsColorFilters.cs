using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;




namespace ImageProcess
{
   abstract class AclsColorFilters
    {

       // properties
       protected Bitmap image;
       //public abstract Bitmap myImage { get; set; }

       //Methods
       public abstract Bitmap applyFilter();
                  
    }
}
