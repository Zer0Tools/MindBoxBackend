using ShapesLib;

namespace ShapesLibTests;

[TestClass]
public class CircleTests
{
    private static float GetArea(float radius)
    {
        return MathF.PI * radius * radius;
    }
    [TestMethod]
    public void GetArea_WithPositiveValues()
    {
        Circle circle = new Circle(1);

        Assert.AreEqual(GetArea(1), circle.GetArea(), 0.00001, "Circle area wrong with radius 1");

        circle.Radius = 2;
        Assert.AreEqual(GetArea(2), circle.GetArea(), 0.00001, "Circle area wrong with radius 2");

        circle.Radius = 5;
        Assert.AreEqual(GetArea(5), circle.GetArea(), 0.00001, "Circle area wrong with radius 5");       

        circle.Radius = 10;
        Assert.AreEqual(GetArea(10), circle.GetArea(), 0.00001, "Circle area wrong with radius 10");  

        circle.Radius = 60;
        Assert.AreEqual(GetArea(60), circle.GetArea(), 0.00001, "Circle area wrong with radius 60");      

        circle.Radius = 222;
        Assert.AreEqual(GetArea(222), circle.GetArea(), 0.00001, "Circle area wrong with radius 222");   

        circle.Radius = 1653;
        Assert.AreEqual(GetArea(1653), circle.GetArea(), 0.00001, "Circle area wrong with radius 1653");           

        circle.Radius = 7423;
        Assert.AreEqual(GetArea(7423), circle.GetArea(), 0.00001, "Circle area wrong with radius 7423");       
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Constructor_WithNegativeValues()
    {
        Circle circle = new Circle(-3);
        circle.GetArea();

        circle.Radius = -2;
        circle.GetArea();

        circle.Radius = -5;
        circle.GetArea();      
    }    

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void SetRadius_WithNegativeValues()
    {
        Circle circle = new Circle(3);
        circle.Radius = -2;   
    }   

}