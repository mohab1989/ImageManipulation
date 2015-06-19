using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Collections;


namespace ImageProcess
{
    public partial class frmMain : Form
    {
        private Bitmap myImage;
        Size originalResized , resized;
        Point mouseDown, mouseLocationNow ,imageULcorner , mouseDownAnimation , mouseLocationNowAnimation;
        Boolean middleClicked = false;
        Boolean imageLoaded = false;
        Boolean draw = false;


        public frmMain()
        {
            InitializeComponent();
            pictureBox.Size = new Size(650, 650);
            gbColorFilters.Enabled=false;
            btnSave.Enabled = false;
            lbImageInfo.Enabled = false;
        }


        // add button event handelr
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                string ImagePath = openFileDialog.FileName;
                try
                {
                    lbImageInfo.Items.Clear();
                    //myImage = new Bitmap(ImagePath);
                    Bitmap temp;
                    temp = new Bitmap(ImagePath);
                    metaData(temp);
                    // make sure that the bitmap is 24 bits
                    ConvTo24(temp);
               
                    resized = myImage.Size;
                    imageResize();
                    pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
                    pictureBox.Invalidate();
                    // enabling  controls
                    imageLoaded = true;
                    gbColorFilters.Enabled = true;
                    btnApplyFilter.Enabled=false;
                    btnSave.Enabled = true;
                    lbImageInfo.Enabled = true;
                }
                catch (IOException)
                {
                }

            }
        }
        // convert all images to 24 bit format
        private void ConvTo24(Bitmap temp)
        {
            myImage = new Bitmap(temp.Width, temp.Height);
            for (int i = 0; i < temp.Width; i++)
            {
                for (int j = 0; j < temp.Height; j++)
                {
                    Color tempColor = temp.GetPixel(i, j);
                    myImage.SetPixel(i, j, tempColor);
                }
            }
        }
        //get metadata
        private void metaData(Bitmap temp)
        {
            PropertyItem[] propItems = temp.PropertyItems;

            int count = 0;  
            foreach (PropertyItem item in propItems)
            {
                lbImageInfo.Items.Add("Property Item " + count.ToString());

                lbImageInfo.Items.Add("iD: 0x" + item.Id.ToString("x"));

                count++;
            }
            lbImageInfo.Items.Add("Image Width is " + temp.Width.ToString());
            lbImageInfo.Items.Add("Image Length is " + temp.Height.ToString());

            ASCIIEncoding encodings = new ASCIIEncoding();
            {
                try
                {

                    string make = encodings.GetString(propItems[1].Value);

                    lbImageInfo.Items.Add("The equipment make is " + make + ".");

                }

                catch
                {
                    lbImageInfo.Items.Add("no Meta Data Found");
                }

                try
                {
                string model = encodings.GetString(propItems[2].Value);

                lbImageInfo.Items.Add("The model is " + model + ".");

                }

                catch

                {

                    lbImageInfo.Items.Add("no Model Found");

                }

                try

                {

                    string DT = encodings.GetString(propItems[15].Value);

                    lbImageInfo.Items.Add("The Date & Time is " + DT + ".");

                }

                catch

                {

                    lbImageInfo.Items.Add("no date Found");

                }

            }

        }
        //resizing and centring image
        private void imageResize()
        {
            double ratioX = (double)pictureBox.Width / (double)myImage.Width;
            double ratioY = (double)pictureBox.Height / (double)myImage.Height;
            // use whichever multiplier is smaller
            double ratio = ratioX < ratioY ? ratioX : ratioY;

            // now we can get the new height and width
            resized.Height = (int)(myImage.Height * ratio);
            resized.Width = (int)(myImage.Width * ratio);
            originalResized = resized;

            // Now calculate the X,Y position of the upper-left corner 
            // one of these will always be zero
            imageULcorner.X = Convert.ToInt32((pictureBox.Width - (myImage.Width * ratio)) / 2);
            imageULcorner.Y = Convert.ToInt32((pictureBox.Height - (myImage.Height * ratio)) / 2);
        }



        // onpaint event handler
        private void pictureBox_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            // Create a local version of the graphics object for the PictureBox.
            Graphics PboxGraphics = e.Graphics; 
            PboxGraphics.DrawImage(myImage, imageULcorner.X, imageULcorner.Y, resized.Width, resized.Height);
        }
        protected customLine mCurrent;
        //Mouse DOWN
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (imageLoaded)
            {
                MouseEventArgs mouse = e as MouseEventArgs;

                //Panning MouseDown Action
                if (mouse.Button == MouseButtons.Left)
                {
                    mouseDown.X = mouse.Location.X - imageULcorner.X;
                    mouseDown.Y = mouse.Location.Y - imageULcorner.Y;
                }
                    
                //Drawing MouseDown Action
                else if (mouse.Button == MouseButtons.Right)
                {
                    mCurrent = new customLine();                   
                    mCurrent.Location =imageULcorner;
                    mCurrent.Size = resized;
                    pictureBox.Controls.Add(mCurrent);
                    mouseDownAnimation.X = (int)(Math.Abs(mouse.Location.X - imageULcorner.X));
                    mouseDownAnimation.Y = (int)(Math.Abs(mouse.Location.Y - imageULcorner.Y));

                    //mouseDownAnimation = mouse.Location;
                    mCurrent.Invalidate();
                    
                    mouseDown = mouse.Location;
                    mouseDown.X = (int)(Math.Abs(mouseDown.X - imageULcorner.X) * (double)((double)myImage.Width / (double)resized.Width));
                    mouseDown.Y = (int)(Math.Abs(mouseDown.Y - imageULcorner.Y) * (double)((double)myImage.Height / (double)resized.Height));
                    draw = true;
                }

                //Zooming MouseDown Action
                else if (mouse.Button == MouseButtons.Middle)
                {
                    mouseDown = mouse.Location;
                    middleClicked = true;
                }
            }
        }

        //Mouse UP
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (imageLoaded)
            {
                MouseEventArgs mouse = e as MouseEventArgs;

                // Panning MouseUp Action
                if (mouse.Button == MouseButtons.Left)
                {
                    mouseDown = mouse.Location;
                }
                // Drawing MouseUp Action 
                else if (mouse.Button == MouseButtons.Right)
                {
                    if (draw)
                    {
                        mCurrent.Dispose();
                        mouseLocationNow.X = (int)(Math.Abs(mouse.X - imageULcorner.X) * (double)((double)myImage.Width / (double)resized.Width));
                        mouseLocationNow.Y = (int)(Math.Abs(mouse.Y - imageULcorner.Y) * (double)((double)myImage.Height / (double)resized.Height));
                        Graphics image = Graphics.FromImage(myImage);
                        Pen pen = new Pen(Color.Red, 2);
                        image.DrawLine(pen, mouseLocationNow, mouseDown);
                        image.Dispose();
                        pictureBox.Invalidate();
                    }
                    draw = false;
                }

                // Zooming MouseUp Action
                else if (mouse.Button == MouseButtons.Middle)
                {
                    middleClicked = false;
                }

            }
        }
        //Mouse Move
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (imageLoaded)
            {
                MouseEventArgs mouse = e as MouseEventArgs;
                // Panning MouseMoving Action
                if (mouse.Button == MouseButtons.Left)
                {
                    clsPanning pan = new clsPanning();
                    pan.initPoint = mouseDown;
                    pan.lastPoint = mouse.Location;
                    pan.pBox = pictureBox.Location;
                    pan.applyTransformation();
                    imageULcorner.X = pan.pannedPoint.X;
                    imageULcorner.Y = pan.pannedPoint.Y;
                    pictureBox.Invalidate();
                }
                
                // Drawing MouseMoving Action
                if (mouse.Button == MouseButtons.Right)
                {
                    if (draw)
                    {
                        mouseLocationNowAnimation.X = (int)(Math.Abs(mouse.X - imageULcorner.X));
                        mouseLocationNowAnimation.Y = (int)(Math.Abs(mouse.Y - imageULcorner.Y));
                       
                        mCurrent.initPoint.X = mouseDownAnimation.X;
                        mCurrent.initPoint.Y = mouseDownAnimation.Y;
                        mCurrent.lastPoint.X = mouseLocationNowAnimation.X;
                        mCurrent.lastPoint.Y = mouseLocationNowAnimation.Y;

                        mCurrent.Invalidate();
                    }
                }

                // Zooming MouseMoving Action
                if (middleClicked)
                {
                    // initialize zoom instance
                    clsZooming zoom = new clsZooming();
                    // assign zoom parameters
                    zoom.initPoint = mouseDown;
                    zoom.lastPoint = mouse.Location;
                    zoom.resizedSize = resized;
                    zoom.originalResizedSize = originalResized;
                    zoom.imageSize = myImage.Size;
                    zoom.zoomCenteringPoint = imageULcorner;
                    // apply zooming
                    zoom.applyTransformation();
                    // return new size and location
                    resized = zoom.resizedSize;
                    imageULcorner = zoom.zoomCenteringPoint;
                    pictureBox.Invalidate();
                }
            }

        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            if (cbFilterSelect.Text == "Inverse")
            {
                clsInvertFilter invert = new clsInvertFilter(myImage) ;
                myImage= invert.applyFilter();
                pictureBox.Invalidate();
            }
            else if (cbFilterSelect.Text == "GreyScale")
            {
                clsGrayScaleFilter Gray = new clsGrayScaleFilter(myImage);
                myImage = Gray.applyFilter();
                pictureBox.Invalidate();
            }
            else 
            {
                MessageBox.Show("Select A Filter") ;
            }
        }

        private void cbFilterSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnApplyFilter.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                string ImagePath = saveFileDialog.FileName;
                try
                {
                    myImage.Save(ImagePath);
                }
                catch (IOException)
                {
                }
            }
        }
    }
}
