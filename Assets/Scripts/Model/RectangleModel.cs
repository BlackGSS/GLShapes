public class RectangleModel : ShapeModel
{
    public float height = 0;
    public float width = 0;

    protected override float SetPerimeter()
    {
        float perimeter = 2 * (height + width);
        return perimeter;
    }
}
