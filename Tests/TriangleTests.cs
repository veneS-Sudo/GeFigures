using GeFigures.Figures;

namespace GeFigures.Test;

public class TriangleTests
{
    [Fact]
    public void GetSquare_CreateExistsTriangle_ShouldReturnRightSquareOfTriangle()
    {
        var triangle = new TriangleFigure(5, 4, 3);
        var expected = 6; // по формуле Герона

        var square = triangle.GetSquare();
        
        Assert.Equal(expected, square);
    }

    [Theory]
    [InlineData(5, 4, 1)]
    [InlineData(5, 1, 1)]
    [InlineData(5, 4,-1)]
    [InlineData(-5, -4, 2)]
    public void TriangleFigureCtor_CreateNotExistsTriangle_ThrowArgumentException(double sideA, double sideB, double sideC)
    {
        Assert.Throws<ArgumentException>(() => new TriangleFigure(sideA, sideB, sideC));
    }

    [Theory]
    [InlineData(5, 4, 3, true)]
    [InlineData(4, 4, 3, false)]
    public void IsRectangular_SetupSides_ShouldReturnExpectedValue(double sideA, double sideB, double sideC, bool expected)
    {
        var actual = TriangleFigure.IsRectangular(sideA, sideB, sideC, out var cathets);
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsRectangular_SetupSides_ShouldInitCathetsParameterRightValues()
    {
        double sideA = 5, sideB = 4, sideC = 3;
        var expected = (3, 4);
        
        TriangleFigure.IsRectangular(sideA, sideB, sideC, out var cathets);
        
        Assert.Equal(expected, cathets);
    }

    [Theory]
    [InlineData(1, 1, 0, false)]
    [InlineData(-1, -1, -1, false)]
    [InlineData(0, 0, 0, false)]
    [InlineData(-1, 0, 0, false)]
    [InlineData(1, 1, 1, true)]
    [InlineData(5, 4, 2, true)]
    public void IsExists_SetupSides_ShouldReturnExpectedValue(double sideA, double sideB, double sideC, bool expected)
    {
        var actual = TriangleFigure.IsExists(sideA, sideB, sideC);
        
        Assert.Equal(expected, actual);
    }
}