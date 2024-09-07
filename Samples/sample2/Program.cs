
using System.Drawing;

Shape shape = new();
Rectangle rectangle = new();

List<Shape> shapes = new List<Shape>();
shapes.Add(shape);
shapes.Add(rectangle);
foreach(var s in shapes)
{
    s.Draw();
}

public class Ellipse : Shape
{
    new public void Draw() => DisplayShape();
    protected override void DisplayShape()
    {
        Console.WriteLine($"Ellipce at position {Position} with size {Size}");
    }
}

public class Rectangle : Shape
{
    new public void Draw() => DisplayShape();
    protected override void DisplayShape()
    {
        Console.WriteLine($"Rectangle at position {Position} with size {Size}");
    }
}

public class Shape
{
    public SequencePosition Position { get; } = new SequencePosition();
    public Size Size { get; } = new Size();
    public void Draw() => DisplayShape();
    protected virtual void DisplayShape()
    {
        Console.WriteLine($"Shape with {Position} and {Size}");
    }
}
