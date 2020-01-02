using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EyeGaze.Engine
{
    public class ScreenShot
    {
        public int picNumber;
        public ScreenShot()
        {
            picNumber = 0;
        }

        public String CaptureScreenShot()
        {
			try

			{
				/*
				//Creating a new Bitmap object

				Bitmap captureBitmap = new Bitmap(1024, 768, System.Drawing.Imaging.PixelFormat.Format32bppArgb);


				//Bitmap captureBitmap = new Bitmap(int width, int height, PixelFormat);

				//Creating a Rectangle object which will  

				//capture our Current Screen

				//Rectangle captureRectangle = Screen.AllScreens[0].Bounds;

				Rectangle captureRectangle = Screen.GetBounds(Point.Empty);


				//Creating a New Graphics Object

				Graphics captureGraphics = Graphics.FromImage(captureBitmap);



				//Copying Image from The Screen

				captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);



				//Saving the Image File (I am here Saving it in My E drive).

				String picLocation = @"C:\a_work\final project\EyeGaze\EyeGaze\Engine\ScreenPhotos\screen" + picNumber + ".jpg";

				captureBitmap.Save(picLocation, ImageFormat.Jpeg);
				*/
				//Displaying the Successfull Result
				picNumber = 7;

				Rectangle bounds = Screen.AllScreens[0].Bounds;
				Thread.Sleep(5000);
				MessageBox.Show("width: " + bounds.Width + "Height: " + bounds.Height);
				String picLocation = @"C:\a_work\final project\EyeGaze\EyeGaze\Engine\ScreenPhotos\screen" + picNumber + ".jpg";

				Bitmap printscreen = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
				Graphics graphics = Graphics.FromImage(printscreen as Image);

				graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);

				printscreen.Save(picLocation, ImageFormat.Png);

				//MessageBox.Show(""+bounds.Width +"Height"+bounds.Height);
				using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
				{
					using (Graphics g = Graphics.FromImage(bitmap))
					{
						g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
					}
					bitmap.Save(picLocation, ImageFormat.Jpeg);
				}


				MessageBox.Show("Screen Captured: " + picLocation);

	
				return picLocation;

			}

			catch (Exception ex)

			{

				MessageBox.Show(ex.Message);
				return null;
			}


		}

	}
}
