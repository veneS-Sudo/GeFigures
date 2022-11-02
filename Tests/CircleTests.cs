using GeFigures.Figures;

namespace GeFigures.Test;

public class CircleTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void CircleFigureCtor_CreateNotExistsCircle_ThrowArgumentException(double r)
    {
        Assert.Throws<ArgumentException>(() => new CircleFigure(r));
    }

    [Fact]
    public void GetSquare_CreateExistsCircle_ShouldReturnRightSquare()
    {
        var circle = new CircleFigure(5);
        var expected = 78.54;

        var square = circle.GetSquare();
        
        Assert.Equal(expected, square);
    }
}