using ShapesLib;

Shape[] shapes = new Shape[]
{
    new Circle(32), new Triangle(2, 4, 3), new Circle(2.54f), new Triangle(2.3f, 3.6f, 2.6f)    
};

foreach (Shape shape in shapes)
{
    Console.WriteLine($"area of shape {shape.GetArea()}");
}

