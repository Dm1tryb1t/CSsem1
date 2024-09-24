
namespace TestProject1
{
    [TestClass]
    public class RectangleUnitTest
    {
        [TestMethod]
        public void RectangleAreaTest()
        {
            double sideA = 5;
            double sideB = 10;
            Rectangle rectangle = new Rectangle(sideA, sideB);

            double area = rectangle.Area;

            Assert.AreEqual(50, area);
        }
        [TestMethod]
        public void RectanglePerimeterWithZeroTest()
        {
            double sideA = 0;
            double sideB = 10;
            Rectangle rectangle = new Rectangle(sideA, sideB);

            double perimeter = rectangle.Perimeter;

            Assert.AreEqual(10, perimeter);
        }
        [TestMethod]
        public void RectanglePerimeterTest()
        {
            double sideA = 5;
            double sideB = 10;
            Rectangle rectangle = new Rectangle(sideA, sideB);

            double perimeter = rectangle.Perimeter;

            Assert.AreEqual(30, perimeter);
        }
    }
    [TestClass]
    public class FigureUnitTest
    {
        [TestMethod]
        public void FigureTriangleConstructorTest()
        {
            Point pointA = new Point(0, 0);
            Point pointB = new Point(1, 0);
            Point pointC = new Point(0, 1);

            Figure triangle = new Figure(pointA, pointB, pointC);

            Assert.AreEqual("Triangle", triangle.Name);
        }
        [TestMethod]
        public void FigureQuadrangleConstructorTest()
        {
            Point pointA = new Point(0, 0);
            Point pointB = new Point(1, 0);
            Point pointC = new Point(1, 1);
            Point pointD = new Point(0, 1);

            Figure quadrangle = new Figure(pointA, pointB, pointC, pointD);

            Assert.AreEqual("Quadrangle", quadrangle.Name);
        }
        [TestMethod]
        public void FigurePentagonConstructorTest()
        {
            Point pointA = new Point(0, 0);
            Point pointB = new Point(1, 0);
            Point pointC = new Point(1, 1);
            Point pointD = new Point(0, 1);
            Point pointE = new Point(0.5, 1.5);

            Figure pentagon = new Figure(pointA, pointB, pointC, pointD, pointE);

            Assert.AreEqual("Pentagon", pentagon.Name);
        }
        [TestMethod]
        public void SideLengthTest()
        {
            Point pointA = new Point(0, 0);
            Point pointB = new Point(3, 4);
            Figure figure = new Figure(pointA, pointB, null);

            double length = figure.LengthSide(pointA, pointB);

            Assert.AreEqual(5, length);
        }
        [TestMethod]
        public void PerimeterCalculatorTestForTriangle()
        {
            Point pointA = new Point(0, 0);
            Point pointB = new Point(3, 0);
            Point pointC = new Point(0, 4);
            Figure triangle = new Figure(pointA, pointB, pointC);

            double perimeter = triangle.PerimeterCalculator();

            Assert.AreEqual(12, perimeter);
        }
        [TestMethod]
        public void PerimeterCalculatorTestForQuadrangle()
        {
            Point pointA = new Point(0, 0);
            Point pointB = new Point(1, 0);
            Point pointC = new Point(1, 1);
            Point pointD = new Point(0, 1);
            Figure quadrangle = new Figure(pointA, pointB, pointC, pointD);

            double perimeter = quadrangle.PerimeterCalculator();

            Assert.AreEqual(4, perimeter);
        }
        [TestMethod]
        public void PerimeterCalculatorTestForPentagon()
        {
            Point pointA = new(2, 1);
            Point pointB = new(2, -3);
            Point pointC = new(-2, -3);
            Point pointD = new(-3, -1);
            Point pointE = new(-1, 2);
            Figure pentagon = new Figure(pointA, pointB, pointC, pointD, pointE);

            double perimeter = pentagon.PerimeterCalculator();

            Assert.IsTrue(perimeter > 17 && perimeter < 17.005);
        }
    }
}
