using UnityEngine;
using Zenject;

public class SquareModel : ShapeModel
{
    private ProcessSquareController processSquareController;
    private ReorderGridController reorderGridController;
    private float sideLength;

    [Inject]
    public void Construct(ProcessSquareController newProcessTriangleController, ReorderGridController newReorderGridController)
    {
        processSquareController = newProcessTriangleController;
        reorderGridController = newReorderGridController;
    }

    void Start()
    {
        processSquareController.OnBuildShape += SetSides;
        reorderGridController.OnPositionUpdated += SetOrigin;
    }


    //Improvement: This should be a Square class where it has sides and origin
    private void SetSides(float length)
    {
        sideLength = length;
    }

    private void SetOrigin(ShapeModel shape, RectTransform newOrigin)
    {
        if (shape == this)
            origin = newOrigin;
    }

    //Improvement: This could be a Vector3[] DrawShape(float vertexAmoun, int xValue, int yValue) with the vertex calculation and then a DrawLines() which every one implements a DrawLines(Vertex[] vertex)
    protected override void DrawShape()
    {
        //Improvement: Implement lastSideLength variable, so this will only render when lastSideLength != sideLength
        if (sideLength > 0)
        {
            GL.Begin(GL.LINES);
            material.SetPass(0);
            GL.Color(Color.black);

            //Get the center of the object to be the anchor
            Vector3 center = origin.position;

            Vector3 vertex1 = new Vector3(-sideLength / 2, -sideLength / 2, 0) + center;
            Vector3 vertex2 = new Vector3(-sideLength / 2, sideLength / 2, 0) + center;
            Vector3 vertex3 = new Vector3(sideLength / 2, sideLength / 2, 0) + center;
            Vector3 vertex4 = new Vector3(sideLength / 2, -sideLength / 2, 0) + center;

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

    protected override float SetPerimeter()
    {
        float perimeter = sideLength * 4;
        return perimeter;
    }
}
