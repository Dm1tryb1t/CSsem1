#region First Task
Console.WriteLine("First Task");

Console.WriteLine($" Size of sbyte: Min = {sbyte.MinValue}, Max = {sbyte.MaxValue}");
Console.WriteLine($" Size of byte: Min = {byte.MinValue}, Max = {byte.MaxValue}");
Console.WriteLine($" Size of short: Min = {short.MinValue}, Max = {short.MaxValue}");
Console.WriteLine($" Size of ushort: Min = {ushort.MinValue}, Max = {ushort.MaxValue}");
Console.WriteLine($" Size of int: Min = {int.MinValue}, Max = {int.MaxValue}");
Console.WriteLine($" Size of uint: Min = {uint.MinValue}, Max = {uint.MaxValue}");
Console.WriteLine($" Size of long: Min = {long.MinValue}, Max = {long.MaxValue}");
Console.WriteLine($" Size of ulong: Min = {ulong.MinValue}, Max = {ulong.MaxValue}");
Console.WriteLine($" Size of float: Min = {float.MinValue}, Max = {float.MaxValue}");
Console.WriteLine($" Size of double: Min = {double.MinValue}, Max = {double.MaxValue}");
Console.WriteLine($" Size of decimal: Min = {decimal.MinValue}, Max = {decimal.MaxValue}");
Console.WriteLine($" Size of bool: Min = {bool.FalseString}, Max = {bool.TrueString}");
Console.WriteLine($" Size of char: Min = {char.MinValue}, Max = {char.MaxValue}");
#endregion

#region Second Task
Console.WriteLine();
Console.WriteLine("Second Task");

double firstSideA = Double.Parse(Console.ReadLine());
double firstSideB = Double.Parse(Console.ReadLine());
Rectangle firstRectangle = new Rectangle(firstSideA, firstSideB);

//double firstAreaExpected = firstSideA * firstSideB;
//double firstPerimeterExpected = 2 * (firstSideA + firstSideB);

double firstArea = firstRectangle.Area;
double firstPerimeter = firstRectangle.Perimeter;
Console.WriteLine($"Area: {firstArea}\t Perimeter: {firstPerimeter}");
#endregion

#region Third Task
Console.WriteLine();
Console.WriteLine("Third Task");
Point firstPoint = new(2, 1);
Point secondPoint = new(2, -3);
Point thirdPoint = new(-2, -3);
Point fourthPoint = new(-3, -1);
Point fifthPoint = new(-1, 2);

Figure pentagon = new(firstPoint, secondPoint, thirdPoint, fourthPoint, fifthPoint);
Figure quadrangle = new(firstPoint, secondPoint, thirdPoint, fourthPoint);
Figure triangle = new(firstPoint, secondPoint, thirdPoint);

triangle.printInfo();
quadrangle.printInfo();
pentagon.printInfo();
#endregion

#region SecondTask Class
class Rectangle
{
    #region Поля
    double side1 = 0;
    double side2 = 0;
    #endregion

    #region Конструктор
    public Rectangle(double sideA, double sideB)
    {
        side1 = sideA;
        side2 = sideB;
    }
    public Rectangle() : this(0, 0) { }
    #endregion

    #region Методы
    private double CalculateArea()
    {
        return side1 * side2;
    }
    private double CalculatePerimeter()
    {
        return (side1 + side2) * 2;
    }
    #endregion


    #region Свойства
    public double Area => CalculateArea();
    public double Perimeter => CalculatePerimeter();
    #endregion
}
#endregion

#region ThirdTask Class
class Point
{
    #region Поля
    private int x = 0;
    private int y = 0;
    #endregion

    #region Конструктор
    public Point(int newX, int newY) 
    {
        x = newX;
        y = newY;
    }
    #endregion

    #region Свойства
    public int X => x;
    public int Y => y;
    #endregion

}

class Figure
{
    #region Поля
    //private Point point1;
    //private Point point2;
    //private Point point3;
    //private Point point4;
    //private Point point5;
    private Point[] points;
    #endregion

    #region Конструктор
    public Figure(Point pointA, Point pointB, Point pointC, Point pointD, Point pointE)
    {
        points = new Point[] { pointA, pointB, pointC, pointD, pointE };
        //(point1, point2, point3, point4, point5) = (pointA, pointB, pointC, pointD, pointE);
        Name = "Pentagon";
    }
    public Figure(Point pointA, Point pointB, Point pointC, Point pointD) : this(pointA, pointB, pointC, pointD, null) { Name = "Quadrangle"; }
    public Figure(Point pointA, Point pointB, Point pointC) : this(pointA, pointB, pointC, null, null) { Name = "Triangle"; }
    #endregion

    #region Свойства
    public string Name { get; set; }
    #endregion

    #region Методы
    public double LengthSide(Point pointA, Point pointB)
    {
        if(pointA == null || pointB == null) { return 0; }
        return Math.Pow(Math.Pow(pointA.X - pointB.X, 2) + Math.Pow(pointA.Y - pointB.Y, 2), 0.5);
    }
    public double PerimeterCalculator()
    {
        double perimeter = 0;
        perimeter += LengthSide(points[0], points[1]);
        perimeter += LengthSide(points[1], points[2]);
        if (points[3] == null)
        {
            perimeter += LengthSide(points[2], points[0]);
        }
        else
        {
            perimeter += LengthSide(points[2], points[3]);
            if (points[4] == null)
            {
                perimeter += LengthSide(points[3], points[0]);
            }
            else
            {
                perimeter += LengthSide(points[3], points[4]);
                perimeter += LengthSide(points[4], points[0]);
            }
        }
        return perimeter;
    }
    public void printInfo()
    {
        Console.WriteLine($"Figure Name: {Name}, it's Perimeter: {PerimeterCalculator()}");
    }
    #endregion

}
#endregion
