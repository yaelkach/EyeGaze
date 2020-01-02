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

namespace EyeGaze
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //InitializeComponent();
            //TesseractOCR ocr = new TesseractOCR();
            //ocr.createTSV();
            //Bitmap img = new Bitmap(@"C:\Users\tomer\Desktop\Yael\Python-Tesseract\test1.png");
            ////TesseractEngine engine = new TesseractEngine("./tessdata", "eng", EngineMode.Default);
            //Page page = engine.Process(img, PageSegMode.Auto);
            AspOCR ocr = new AspOCR();
            Dictionary<Point, string> wordWithCoordinates = ocr.getWordWithCoordinates();
            List<Point> coordinates = new List<Point>(wordWithCoordinates.Keys);
            Dictionary<Point, double> distanceFromCoordinate = findDistanceFromCoordinate(177, 480, coordinates);
            List<KeyValuePair<Point, double>> sortedPoints = sortByDistance(distanceFromCoordinate);

            List<KeyValuePair<Point, string>> sortedValues = sortValues(wordWithCoordinates, sortedPoints);
            WordTextEditor word = new WordTextEditor(sortedValues);
            word.openWord();


        }

        private Dictionary<Point, double> findDistanceFromCoordinate(int x, int y, List<Point> coordinates)
        {
            Dictionary<Point, double> result = new Dictionary<Point, double>();
            foreach(Point point in coordinates)
            {
                double distance = Math.Sqrt(Math.Pow(x - point.X, 2) + Math.Pow(y - point.Y, 2));
                if (distance < 300)
                {
                    result.Add(point, distance);
                }
            }
            return result;
        }

        private List<KeyValuePair<Point, double>> sortByDistance(Dictionary<Point, double> coordinatesDistance)
        {
            List<KeyValuePair<Point, double>> myList = coordinatesDistance.ToList();
            myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            return myList;
        }

        private List<KeyValuePair<Point, string>> sortValues(Dictionary<Point, string> coordinatesWithWords,
            List<KeyValuePair<Point, double>> sortedPoints)
        {
            List<KeyValuePair<Point, string>> sortedValues = new List<KeyValuePair<Point, string>>();
            foreach (KeyValuePair<Point, double> point in sortedPoints)
            {
                string word;
                coordinatesWithWords.TryGetValue(point.Key, out word);
                KeyValuePair<Point, string> pair = new KeyValuePair<Point, string>(point.Key, word);
                sortedValues.Add(pair);
            }
            return sortedValues;
        }
    }
}
