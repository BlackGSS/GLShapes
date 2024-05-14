using UnityEngine;
using Zenject;

public class CircleModel : ShapeModel
{
    private Circle circle;

    [Inject]
    public void Construct(Circle newCircle){
        circle = newCircle;
    }

    protected override float SetPerimeter()
    {
        float perimeter = 2 * Mathf.PI * circle.radius;
        return perimeter;
    }

    protected override void DrawShape()
    {
        if (circle.radius > 0)
        {
            GL.Begin(GL.LINE_STRIP);
            material.SetPass(0);
            GL.Color(Color.black);

            for (int i = 0; i < circle.segments + 1; i++)
            {
                float theta = 2.0f * Mathf.PI * i / circle.segments;
                float x = circle.radius * Mathf.Cos(theta);
                float y = circle.radius * Mathf.Sin(theta);
                GL.Vertex3(x + origin.transform.position.x, y + origin.transform.position.y, origin.transform.position.z);
            }

            GL.End();
        }
    }
}

