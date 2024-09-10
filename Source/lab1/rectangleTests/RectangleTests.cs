using lab1;


namespace rectangleTests
{
    public class RectangleTests
    {
        [Fact]
        public void CalculateArea_ReturnsCorrectArea()
        {
            double sideA = 5;
            double sideB = 10;
            Rectangle rectangle = new Rectangle(sideA, sideB);

            double area = rectangle.Area;

            Assert.Equal(50, area);
        }

        [Fact]
        public void CalculatePerimeter_ReturnsCorrectPerimeter()
        {
            double sideA = 5;
            double sideB = 10;
            Rectangle rectangle = new Rectangle(sideA, sideB);

            double perimeter = rectangle.Perimeter();

            Assert.Equal(30, perimeter);
        }
    }
}