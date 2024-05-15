public class SquareModel : ShapeModel
{
    public float sideLength;

    protected override float SetPerimeter()
    {
        float perimeter = sideLength * 4;
        return perimeter;
    }
}
