using EyeGaze.Engine;
using EyeGaze.OCR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace EyeGaze
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TesseractOCR ocr = new TesseractOCR();
            ScreenShot screenShot = new ScreenShot();

            String picLocation = screenShot.CaptureScreenShot();
            int x = 3;
            //ocr.createTSV();
        }
    }
}
