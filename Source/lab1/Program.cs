#region First Task
//sbyte, byte, short, ushort, int, uint, long, ulong, float, double, decimal, bool, char
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
double firstSideA = Double.Parse(Console.ReadLine());
double firstSideB = Double.Parse(Console.ReadLine());
Rectangle firstRectangle = new Rectangle(firstSideA, firstSideB);

//double firstAreaExpected = firstSideA * firstSideB;
//double firstPerimeterExpected = 2 * (firstSideA + firstSideB);

double firstArea = firstRectangle.GetArea();
double firstPerimeter = firstRectangle.GetPerimeter();
Console.WriteLine($"Area: {firstArea}\t Perimeter: {firstPerimeter}");
class Rectangle
{
    double side1 = 0, side2 = 0;
    public Rectangle(double sideA, double sideB)
    {
        side1 = sideA;
        side2 = sideB;
    }
    private double CalculateArea()
    {
        return side1 * side2;
    }
    public double GetArea()
    {
        return CalculateArea();
    }
    private double CalculatePerimeter()
    {
        return (side1 + side2) * 2;
    }
    public double GetPerimeter()
    {
        return CalculatePerimeter();
    }
}
#endregion

#region Third Task

class Point
{
    int x, y;
    public Point(int newX, int newY) 
    {
        x = newX;
        y = newY;
    }
}

class Figure
{

}
#endregion
