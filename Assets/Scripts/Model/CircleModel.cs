using UnityEngine;
using Zenject;

public class CircleModel : ShapeModel
{
    private ProcessCircleController processCircleController;
    private ReorderGridController reorderGridController;
    private float radius = 0;
    private int segments = 36;

    [Inject]
    public void Construct(ProcessCircleController newProcessCircleController, ReorderGridController newReorderGridController)
    {
        processCircleController = newProcessCircleController;
        reorderGridController = newReorderGridController;
    }

    void Start()
    {
        processCircleController.OnBuildShape += SetValues;
        reorderGridController.OnPositionUpdated += SetOrigin;
    }
    private void SetOrigin(ShapeModel shape, RectTransform newOrigin)
    {
        if (shape == this)
            origin = newOrigin;
    }


    private void SetValues(float radiusSize, int segmentsAmount)
    {
        radius = radiusSize;
        segments = segmentsAmount;

    }

    protected override float SetPerimeter()
    {
        float perimeter = 2 * Mathf.PI * radius;
        return perimeter;
    }

    protected override void DrawShape()
    {
        if (radius > 0)
        {
            GL.Begin(GL.LINE_STRIP);
            material.SetPass(0);
            GL.Color(Color.black);

            for (int i = 0; i < segments + 1; i++)
            {
                float theta = 2.0f * Mathf.PI * i / segments;
                float x = radius * Mathf.Cos(theta);
                float y = radius * Mathf.Sin(theta);
                GL.Vertex3(x + origin.transform.position.x, y + origin.transform.position.y, origin.transform.position.z);
            }

            GL.End();
        }
    }
}
