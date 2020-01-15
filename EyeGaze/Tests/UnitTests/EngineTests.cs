using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;
using EyeGaze.Engine;
using EyeGaze.OCR;
using System.Drawing;

namespace EyeGaze.Tests.UnitTests
{
    [TestFixture]
    class EngineTests
    {
        
        [Test]
        public void distanceFromCoordinate()
        {
            EngineMain engine = new EngineMain();
            List<Point> list = new List<Point>();
            Point p1 = new Point(5, 10);
            Point p2 = new Point(20, 20);
            list.Add(p1);
            list.Add(p2);
            Dictionary<Point, double> dict = engine.findDistanceFromCoordinate(10, 10, list);
           
            double value;
            dict.TryGetValue(p1, out value);
            if (value != 5)
                Assert.Fail();
            dict.TryGetValue(p2, out value);
            if (value != Math.Sqrt(200))
                Assert.Fail();
            Assert.IsTrue(true);
        }
    }
}
