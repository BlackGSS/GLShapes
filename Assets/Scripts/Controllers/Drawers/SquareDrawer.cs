using UnityEngine;

public class SquareDrawer : ShapeDrawer<SquareModel>, IPerimeter
{
    public float Perimeter { get => SetPerimeter(); set => Perimeter = value; }

    public float SetPerimeter()
    {
        float perimeter = shape.sideLength * 4;
        return perimeter;
    }

    //Improvement: This could be a Vector3[] DrawShape(float vertexAmoun, int xValue, int yValue) with the vertex calculation and then a DrawLines() which every one implements a DrawLines(Vertex[] vertex)
    protected override void DrawShape()
    {
        //Improvement: Implement lastsquare.sideLength variable, so this will only render when lastsquare.sideLength != square.sideLength
        if (shape.sideLength > 0)
        {
            GL.Begin(GL.LINES);
            material.SetPass(0);
            GL.Color(Color.black);

            //Get the center of the object to be the anchor
            Vector3 center = origin.position;

            Vector3 vertex1 = new Vector3(-shape.sideLength / 2, -shape.sideLength / 2, 0) + center;
            Vector3 vertex2 = new Vector3(-shape.sideLength / 2, shape.sideLength / 2, 0) + center;
            Vector3 vertex3 = new Vector3(shape.sideLength / 2, shape.sideLength / 2, 0) + center;
            Vector3 vertex4 = new Vector3(shape.sideLength / 2, -shape.sideLength / 2, 0) + center;

            // // Rotate the square but didn't work properly bc ancles
            // Quaternion rotation = origin.localRotation;
            // vertex1 = rotation * vertex1;
            // vertex2 = rotation * vertex2;
            // vertex3 = rotation * vertex3;
            // vertex4 = rotation * vertex4;

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
