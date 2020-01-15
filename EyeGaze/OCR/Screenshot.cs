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

namespace EyeGaze.OCR
{
	 public class Screenshot
		{
			public int picNumber;
			public Screenshot()
			{
				picNumber = 0;
			}

			public String CaptureScreenShot()
			{
				try

				{
					picNumber = 100;
					String picLocation = @"C:\Users\tomer\Desktop\Yael\EyeGaze\Screenshots\screenshot" + picNumber + ".jpg";

					Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
					Graphics graphics = Graphics.FromImage(printscreen as Image);

					graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);

					printscreen.Save(picLocation, ImageFormat.Png);

					//MessageBox.Show("Screen Captured: " + picLocation);


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
