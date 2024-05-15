using UnityEngine;

public class TriangleDrawer : ShapeDrawer<TriangleModel>
{
    protected override void DrawShape()
    {
        if (shape.leftSideLength > 0 && shape.bottomSideLength > 0)
        {
            GL.Begin(GL.LINES);
            material.SetPass(0);
            GL.Color(Color.black);

            //Get the center of the object to be the anchor
            Vector3 center = origin.position;

            // Calculate the vertices of the right triangle with the center at the center of the object
            Vector3 vertex1 = new Vector3(-shape.bottomSideLength / 2, -shape.leftSideLength / 2, 0) + center;
            Vector3 vertex2 = new Vector3(shape.bottomSideLength / 2, -shape.leftSideLength / 2, 0) + center;
            Vector3 vertex3 = new Vector3(-shape.bottomSideLength / 2, shape.bottomSideLength / 2, 0) + center;

            // Draw lines between vertices
            GL.Vertex(vertex1);
            GL.Vertex(vertex2);
            GL.Vertex(vertex2);
            GL.Vertex(vertex3);
            GL.Vertex(vertex3);
            GL.Vertex(vertex1);

            GL.End();
        }
    }
}
