using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Scripting.Hosting;
using Tesseract;
using System.Windows.Shapes;
using Page = Tesseract.Page;
using asprise_ocr_api;
using System.Xml;
using System.Drawing;
using System.IO;

namespace EyeGaze.OCR
{
    class AspOCR
    {
        private AspriseOCR ocr;
        public AspOCR()
        {
            AspriseOCR.SetUp();
            ocr = new AspriseOCR();
            ocr.StartEngine("eng", AspriseOCR.SPEED_FASTEST);
            IDictionary<String, Boolean> dict = new Dictionary<String, Boolean>();
            dict.Add(AspriseOCR.PROP_OUTPUT_SEPARATE_WORDS, true);
        }

        public Dictionary<Point, String> getWordWithCoordinates()
        {
            //string path = Directory.GetCurrentDirectory();
            String xml = ocr.Recognize(@"C:\Users\tomer\Desktop\Yael\Python-Tesseract\printscreen.png", -1, -1, -1, -1, -1,
                AspriseOCR.RECOGNIZE_TYPE_ALL, AspriseOCR.OUTPUT_FORMAT_XML,
                new object[] { AspriseOCR.PROP_OUTPUT_SEPARATE_WORDS, true });
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            XmlNodeList xList = xmlDoc.SelectNodes("/asprise-ocr/page/block/@x");
            XmlNodeList yList = xmlDoc.SelectNodes("/asprise-ocr/page/block/@y");
            XmlNodeList valueList = xmlDoc.SelectNodes("/asprise-ocr/page/block");

            Dictionary<Point, string> result = new Dictionary<Point, string>();
            for(int i=0; i< valueList.Count; i++)
            {
                int x = Convert.ToInt32(xList[i].Value);
                int y = Convert.ToInt32(yList[i].Value);
                String word = valueList[i].InnerText;
                Point point = new Point(x, y);

                result.Add(point, word);

            }
            return result;
        }
    }
}
