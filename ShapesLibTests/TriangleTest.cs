using ShapesLib;

namespace ShapesLibTests;

[TestClass]
public class TriangleTests
{
    private static float GetArea(float a, float b, float c)
    {
        float semiPerimeter = (a + b + c) / 2f;
        return MathF.Sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));
    }
    [TestMethod]
    public void GetArea_WithPositiveValues()
    {
        Triangle triangle = new Triangle(1, 1, 1);

        Assert.AreEqual(GetArea(triangle.SideA, triangle.SideB, triangle.SideC), 
            triangle.GetArea(), 0.00001, $"Triangle area wrong with sides: {triangle.SideA}, {triangle.SideB}, {triangle.SideC}");

        triangle.SetSides(2, 2, 3);
        Assert.AreEqual(GetArea(triangle.SideA, triangle.SideB, triangle.SideC), 
            triangle.GetArea(), 0.00001, $"Triangle area wrong with sides: {triangle.SideA}, {triangle.SideB}, {triangle.SideC}"); 

        triangle.SetSides(3, 4, 5);
        Assert.AreEqual(6, triangle.GetArea(), 0.00001, 
            $"Triangle area wrong with sides: {triangle.SideA}, {triangle.SideB}, {triangle.SideC}");    

        triangle.SetSides(4, 3, 6);
        Assert.AreEqual(GetArea(triangle.SideA, triangle.SideB, triangle.SideC), 
            triangle.GetArea(), 0.00001, $"Triangle area wrong with sides: {triangle.SideA}, {triangle.SideB}, {triangle.SideC}");  

        triangle.SetSides(8, 5, 12);
        Assert.AreEqual(GetArea(triangle.SideA, triangle.SideB, triangle.SideC), 
            triangle.GetArea(), 0.00001, $"Triangle area wrong with sides: {triangle.SideA}, {triangle.SideB}, {triangle.SideC}"); 

        triangle.SetSides(8, 20, 16);
        Assert.AreEqual(GetArea(triangle.SideA, triangle.SideB, triangle.SideC), 
            triangle.GetArea(), 0.00001, $"Triangle area wrong with sides: {triangle.SideA}, {triangle.SideB}, {triangle.SideC}");                                    
    }

    [TestMethod]
    public void IsRight()
    {
        Triangle triangle = new Triangle(1, 1, 1);

        Assert.IsFalse(triangle.IsRight(), $"Triangle not right with sides: {triangle.SideA}, {triangle.SideB}, {triangle.SideC}");

        triangle.SetSides(2, 2, 3);
        Assert.IsFalse(triangle.IsRight(), $"Triangle not right with sides: {triangle.SideA}, {triangle.SideB}, {triangle.SideC}");

        triangle.SetSides(3, 4, 5);
        Assert.IsTrue(triangle.IsRight(), $"Triangle right with sides: {triangle.SideA}, {triangle.SideB}, {triangle.SideC}");

        triangle.SetSides(4, 3, 6);
        Assert.IsFalse(triangle.IsRight(), $"Triangle not right with sides: {triangle.SideA}, {triangle.SideB}, {triangle.SideC}"); 

        triangle.SetSides(8, 5, 12);
        Assert.IsFalse(triangle.IsRight(), $"Triangle not right with sides: {triangle.SideA}, {triangle.SideB}, {triangle.SideC}");

        triangle.SetSides(8, 20, 16);
        Assert.IsFalse(triangle.IsRight(), $"Triangle not right with sides: {triangle.SideA}, {triangle.SideB}, {triangle.SideC}");  
                             
    }


    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Constructor_WithNegativeValues()
    {
        Triangle triangle = new Triangle(-1, -1, -1);
    }  

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void SetSide_WithNegativeValues()
    {
        Triangle triangle = new Triangle(1, 1, 1);
        triangle.SideA = -34;
    }  

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]    
    public void SetSides_WithNegativeValues()
    {
        Triangle triangle = new Triangle(1, 1, 1);
        triangle.SetSides(-1, 3, 5);
    }  

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Constructor_WithImpossibleValue()
    {
        Triangle triangle = new Triangle(2, 2, 4);
    }  

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]    
    public void SetSideA_WithImpossibleValue()
    {
        Triangle triangle = new Triangle(1, 1, 1);
        triangle.SideA = 23;
    }       
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]    
    public void SetSideB_WithImpossibleValue()
    {
        Triangle triangle = new Triangle(1, 1, 1);
        triangle.SideB = 23;
    }   

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]    
    public void SetSideC_WithImpossibleValue()
    {
        Triangle triangle = new Triangle(1, 1, 1);
        triangle.SideC = 23;
    }  

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]    
    public void SetSides_WithImpossibleValues()
    {
        Triangle triangle = new Triangle(1, 1, 1);
        triangle.SetSides(23, 2, 5);
    }            

}