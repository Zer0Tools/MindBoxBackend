namespace ShapesLib;


/// <summary>
/// Triangle shape
/// </summary>
public class Triangle : Shape
{
    /// <summary>
    /// Get or set side
    /// </summary>
    public float SideA 
    {
        get => _sideA; 
        set => SetSide(ref value, ref _sideA, ref _sideB, ref _sideC);
    }

    /// <summary>
    /// Get or set side
    /// </summary>    
    public float SideB 
    {
        get => _sideB; 
        set => SetSide(ref value, ref _sideB, ref _sideA, ref _sideC);
    }

    /// <summary>
    /// Get or set side
    /// </summary>    
    public float SideC 
    {
        get => _sideC; 
        set => SetSide(ref value, ref _sideC, ref _sideA, ref _sideB);
    }
    private float _sideA;
    private float _sideB;
    private float _sideC;
    private float _area; 
    private bool _isRight;
    private bool _shouldRecalculateArea;
    private bool _shouldCheckRight;

    /// <summary>
    /// Create triangle wits sides
    /// </summary>
    /// <param name="sideA"></param>
    /// <param name="sideB"></param>
    /// <param name="sideC"></param>
    public Triangle(float sideA, float sideB, float sideC)
    {
        SetSides(sideA, sideB, sideC);
    }

    /// <summary>
    /// Set triangle sides
    /// </summary>
    /// <param name="sideA"></param>
    /// <param name="sideB"></param>
    /// <param name="sideC"></param>
    /// <exception cref="ArgumentException"></exception>
    public void SetSides(float sideA, float sideB, float sideC)
    {
        if(sideA < 0)
            throw new ArgumentException("sideA must be positive");              
        _sideA = sideA;   
        if(sideB < 0)
            throw new ArgumentException("sideB must be positive");                     
        _sideB = sideB;
        if(sideC < 0)
            throw new ArgumentException("sideC must be positive");             
        _sideC = sideC;
        CheckIfPossible();
        RecalculateArea();
        CheckRight();        
    }

    public override float GetArea()
    {
        if(_shouldRecalculateArea)
        {
            RecalculateArea();
            _shouldRecalculateArea = false;
        }
        return _area;
    }

    /// <summary>
    /// Check if triangle is right(angle is 90 degrees)
    /// </summary>
    /// <returns> returns true if right </returns>
    public bool IsRight()
    {
        if(_shouldCheckRight)
        {
            CheckRight();
            _shouldCheckRight = false;

        }
        return _isRight;
    }

    private void SetSide(ref float value, ref float targetSide, ref float sideA, ref float sideB)
    {
            if(value == targetSide) 
                return;            
            if(value < 0)
                throw new ArgumentException("side must be positive"); 

            if(value >= sideA + sideB)
                throw new ArgumentException("Triangle with this sides is imposible");    
            
            targetSide = value;
            _shouldRecalculateArea = true;
            _shouldCheckRight = true;
    }

    private void RecalculateArea()
    {
        float semiPerimeter = (_sideA + _sideB + _sideC) / 2f;
        _area = MathF.Sqrt(semiPerimeter * (semiPerimeter - _sideA) * (semiPerimeter - _sideB) * (semiPerimeter - _sideC));
    }

    private void CheckRight()
    {
        float squaredA = _sideA * _sideA;
        float squaredB = _sideB * _sideB;
        float squaredC = _sideC * _sideC;
        _isRight = (squaredA - (squaredB + squaredC)) == 0 || 
                   (squaredB - (squaredC + squaredA)) == 0 ||
                   (squaredC - (squaredA + squaredB)) == 0;
    }

    private void CheckIfPossible()
    {
        if(( (_sideA + SideB) <= SideC ) ||
           ( (_sideC + SideA) <= SideB ) ||
           ( (_sideB + SideC) <= SideA ))
           throw new ArgumentException("Triangle with this sides is imposible");
    }
}