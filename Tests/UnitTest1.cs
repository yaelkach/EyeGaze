using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
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
