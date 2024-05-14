using UnityEngine;
using Zenject;

public class RectangleModel : ShapeModel
{
    private ProcessRectangleController processRectangleController;
    private ReorderGridController reorderGridController;
    private float height;
    private float width;

    [Inject]
    public void Construct(ProcessRectangleController newProcessTriangleController, ReorderGridController newReorderGridController)
    {
        processRectangleController = newProcessTriangleController;
        reorderGridController = newReorderGridController;
    }

    void Start()
    {
        processRectangleController.OnBuildShape += SetSides;
        reorderGridController.OnPositionUpdated += SetOrigin;
    }

    private void SetSides(float leftSide, float topSide)
    {
        height = leftSide;
        width = topSide;
    }

    private void SetOrigin(ShapeModel shape, RectTransform newOrigin)
    {
        if (shape == this)
            origin = newOrigin;
    }

    //Upgrade: This could inherit from SquareModel
    protected override void DrawShape()
    {
        if (height > 0 && width > 0)
        {
            GL.Begin(GL.LINES);
            material.SetPass(0);
            GL.Color(Color.black);

            //Get the center of the object to be the anchor
            Vector3 center = origin.position;

            Vector3 vertex1 = center + new Vector3(-width / 2, -height / 2, 0);
            Vector3 vertex2 = center + new Vector3(-width / 2, height / 2, 0);
            Vector3 vertex3 = center + new Vector3(width / 2, height / 2, 0);
            Vector3 vertex4 = center + new Vector3(width / 2, -height / 2, 0);

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

    void OnDrawGizmos()
    {
        DrawShape();
    }

    protected override float SetPerimeter()
    {
        float perimeter = 2 * (height + width);
        return perimeter;
    }
}
