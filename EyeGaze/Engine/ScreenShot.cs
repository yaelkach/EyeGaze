using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
				picNumber = 100;
				String picLocation = @"C:\a_work\final project\EyeGaze\EyeGaze\Engine\ScreenPhotos\screen" + picNumber + ".jpg";

				Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
				Graphics graphics = Graphics.FromImage(printscreen as Image);

				graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);

				printscreen.Save(picLocation, ImageFormat.Png);
			
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
