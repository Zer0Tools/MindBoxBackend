

namespace ShapesLib;
public class Circle : Shape
{
    public float Radius 
    {
        get => _radius; 
        set => SetRadius(value);
    }
    private float _radius;
    private float _area;
    private bool _isChanged;

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


