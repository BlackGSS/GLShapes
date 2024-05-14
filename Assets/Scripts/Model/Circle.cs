using UnityEngine;
using System;
using Zenject;

public class Circle : Shape
{
    private ProcessCircleController processCircleController;
    private ReorderGridController reorderGridController;
    public float radius = 0;
    public int segments = 36;

    public Circle() { }

    public Circle(float r, int s)
    {
        radius = r;
        segments = s;
    }

    [Inject]
    public void Construct(ProcessCircleController newProcessCircleController, ReorderGridController newReorderGridController)
    {
        processCircleController = newProcessCircleController;
        reorderGridController = newReorderGridController;
        AddListeners();
    }

    private void AddListeners()
    {
        processCircleController.OnBuildShape += SetValues;
        reorderGridController.OnPositionUpdated += SetOrigin;
    }

    private void SetOrigin(ShapeModel shape, RectTransform newOrigin)
    {
        // if (shape == this)
        //     origin = newOrigin;
    }


    private void SetValues(Circle newCircle)
    {
        radius = newCircle.radius;
        segments = newCircle.segments;
    }
}
