

namespace ShapesLib;

/// <summary>
/// Circle shape
/// </summary>
public class Circle : Shape
{
    /// <summary>
    /// Get or sets radius of circle
    /// </summary>
    public float Radius 
    {
        get => _radius; 
        set => SetRadius(value);
    }
    private float _radius;
    private float _area;
    private bool _isChanged;

    /// <summary>
    /// Create circle with radius
    /// </summary>
    /// <param name="radius"></param>
    public Circle( float radius )
    {
        Radius = radius;
        RecalculateArea();
    }

    public override float GetArea()
    {
        if(_isChanged)
        {
            RecalculateArea();
            _isChanged = false;
        }
        return _area;
    }

    private void SetRadius(float radius)
    {
        if(_radius == radius)
            return;        
        if(radius < 0)
            throw new ArgumentException("Radius must be positive");
        _radius = radius;
        _isChanged = true;
    }

    private void RecalculateArea()
    {
        _area = _radius * _radius * MathF.PI;
    }

}


