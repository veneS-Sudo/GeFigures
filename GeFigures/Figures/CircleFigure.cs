namespace GeFigures.Figures;

public class CircleFigure : BaseFigure
{
    public double R { get; }
    
    public CircleFigure(double r)
    {
        if (r <= 0)
        {
            throw new ArgumentException($"радиус круга не должен быть меньше 0. радиус = {r}.");
        }
        
        R = r;
    }
    public override double GetSquare()
    {
        if (Square != default)
        {
            return Square;
        }
        
        var square = Math.PI * Math.Pow(R, 2);
        return Math.Round(square, 2);
    }
}