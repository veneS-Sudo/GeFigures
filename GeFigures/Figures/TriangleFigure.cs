namespace GeFigures.Figures;

public class TriangleFigure : BaseFigure
{
    public double SideA { get; }
    public double SideB { get; }
    public double SideC { get; }
    
    public TriangleFigure(double sideA, double sideB, double sideC)
    {
        if (sideA <= 0 || sideB <= 0 || sideC <= 0)
        {
            throw new ArgumentException("длины сторон треугольника должны быть больше 0.");
        }

        if (!IsExists(sideA, sideB, sideC))
        {
            throw new ArgumentException("треугольник не существует.");
        }
            
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }
    
    public override double GetSquare()
    {
        if (Square != default)
        {
            return Square;
        }
            
        if (IsRectangular(SideA, SideB, SideC, out var cathets))
        {
            Square = cathets.Item1 * cathets.Item2 / 2;
            return Square;
        }
        
        // Определение площади по формуле Герона
        var p = (SideA + SideB + SideC) / 2;
        Square = Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        return Square;
    }

    public static bool IsRectangular(double sideA, double sideB, double sideC, out (double, double) cathets)
    {
        var sides = new List<double> { sideA, sideB, sideC };
        sides.Sort();
        
        if (Math.Abs(Math.Pow(sides[2], 2) - (Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2))) < 0.06)
        {
            cathets = (sides[0], sides[1]);
            return true;
        }
        
        cathets = (0, 0);
        return false;
    }
    
    public static bool IsExists(double sideA, double sideB, double sideC)
    {
        return sideA + sideB > sideC &&
            sideA + sideC > sideB &&
            sideB + sideC > sideA;
    }
}