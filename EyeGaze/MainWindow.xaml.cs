using EyeGaze.OCR;
using System;
using System.Collections.Generic;
using System.Drawing;
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
using Tesseract;
using System.Windows.Shapes;
using Page = Tesseract.Page;
using asprise_ocr_api;
using System.Xml;
using Point = System.Drawing.Point;
using EyeGaze.TextEditor;

using EngineClass = EyeGaze.Engine.EngineMain;
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
            EngineClass engine = new EngineClass();
            engine.startListen();
        
        }
    }
}
