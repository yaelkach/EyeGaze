using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;


namespace EyeGaze.OCR
{
    class TesseractOCR
    {
        public TesseractOCR() { }

        public void createTSV()
        {
            var ipy = Python.CreateRuntime();
            dynamic test = ipy.UseFile("tesseract.py");
            test.Simple();
        }
    }
}
