using UnityEngine;

public class TriangleModel : ShapeModel
{
    public float leftSideLength = 0;
    public float bottomSideLength = 0;

    protected override float SetPerimeter()
    {
        float hypotenuse = Mathf.Sqrt((leftSideLength * leftSideLength) + (bottomSideLength * bottomSideLength));
        float perimeter = hypotenuse + leftSideLength + bottomSideLength;
        return perimeter;
    }
}
