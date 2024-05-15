using UnityEngine;

public class RectangleDrawer : ShapeDrawer<RectangleModel>
{
    //Upgrade: This could inherit from SquareModel
    protected override void DrawShape()
    {
        if (shape.height > 0 && shape.width > 0)
        {
            GL.Begin(GL.LINES);
            material.SetPass(0);
            GL.Color(Color.black);

            //Get the center of the object to be the anchor
            Vector3 center = origin.position;

            Vector3 vertex1 = center + new Vector3(-shape.width / 2, -shape.height / 2, 0);
            Vector3 vertex2 = center + new Vector3(-shape.width / 2, shape.height / 2, 0);
            Vector3 vertex3 = center + new Vector3(shape.width / 2, shape.height / 2, 0);
            Vector3 vertex4 = center + new Vector3(shape.width / 2, -shape.height / 2, 0);

            // Draw lines between vertices
            GL.Vertex(vertex1);
            GL.Vertex(vertex2);
            GL.Vertex(vertex2);
            GL.Vertex(vertex3);
            GL.Vertex(vertex3);
            GL.Vertex(vertex4);
            GL.Vertex(vertex4);
            GL.Vertex(vertex1);

            GL.End();
        }
    }
}
