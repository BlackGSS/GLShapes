using System;
using UnityEngine;
using Zenject;

public class ProcessRectangleController : MonoBehaviour
{
    private RectangleModelView rectangleView;

    public Action<float, float> OnBuildShape;

    [Inject]
    public void Construct (RectangleModelView newSquareView)
    {
        rectangleView = newSquareView;
    }

    private void Start()
    {
        rectangleView.OnShapeRender += ProcessShape;
    }

    private void ProcessShape(ValueTuple<string, string> sides)
    {
        OnBuildShape?.Invoke(float.Parse(sides.Item1), float.Parse(sides.Item2));
    }
}
