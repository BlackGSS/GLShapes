using UnityEngine;

public class CircleDrawer : ShapeDrawer<CircleModel>
{
    protected override void DrawShape()
    {
        if (shape.radius > 0)
        {
            GL.Begin(GL.LINE_STRIP);
            material.SetPass(0);
            GL.Color(Color.black);

            for (int i = 0; i < shape.segments + 1; i++)
            {
                float theta = 2.0f * Mathf.PI * i / shape.segments;
                float x = shape.radius * Mathf.Cos(theta);
                float y = shape.radius * Mathf.Sin(theta);
                GL.Vertex3(x + origin.transform.position.x, y + origin.transform.position.y, origin.transform.position.z);
            }

            GL.End();
        }
    }
}