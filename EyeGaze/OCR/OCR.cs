using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeGaze.OCR
{
    interface OCR
    {
        public Dictionary<Point, String> GetWordWithCoordinates();
    }
}
