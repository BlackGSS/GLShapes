using UnityEngine;
using Zenject;

public class TriangleModel : ShapeModel
{
    private ProcessTriangleController processTriangleController;
    private ReorderGridController reorderGridController;
    private float leftSideLength = 0;
    private float bottomSideLength = 0;

    [Inject]
    public void Construct(ProcessTriangleController newProcessTriangleController, ReorderGridController newReorderGridController)
    {
        processTriangleController = newProcessTriangleController;
        reorderGridController = newReorderGridController;
    }

    void Start()
    {
        processTriangleController.OnBuildShape += SetSides;
        reorderGridController.OnPositionUpdated += SetOrigin;
    }

    void SetSides(float sideLeft, float sideBottom)
    {
        leftSideLength = sideLeft;
        bottomSideLength = sideBottom;
    }

    private void SetOrigin(ShapeModel shape, RectTransform newOrigin)
    {
        if (shape == this)
            origin = newOrigin;
    }

    protected override void DrawShape()
    {
        if (leftSideLength > 0 && bottomSideLength > 0)
        {
            GL.Begin(GL.LINES);
            material.SetPass(0);
            GL.Color(Color.black);

            //Get the center of the object to be the anchor
            Vector3 center = origin.position;

            // Calculate the vertices of the right triangle with the center at the center of the object
            Vector3 vertex1 = new Vector3(-bottomSideLength / 2, -leftSideLength / 2, 0) + center;
            Vector3 vertex2 = new Vector3(bottomSideLength / 2, -leftSideLength / 2, 0) + center;
            Vector3 vertex3 = new Vector3(-bottomSideLength / 2, leftSideLength / 2, 0) + center;

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

    void OnDrawGizmos()
    {
        DrawShape();
    }

    protected override float SetPerimeter()
    {
        float hypotenuse = Mathf.Sqrt((leftSideLength * leftSideLength) + (bottomSideLength * bottomSideLength));
        float perimeter = hypotenuse + leftSideLength + bottomSideLength;
        return perimeter;
    }
}
