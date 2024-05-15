using UnityEngine;

public class CircleModel : ShapeModel
{
    public float radius = 0;
    public int segments = 36;

    protected override float SetPerimeter()
    {
        float perimeter = 2 * Mathf.PI * radius;
        return perimeter;
    }
}
