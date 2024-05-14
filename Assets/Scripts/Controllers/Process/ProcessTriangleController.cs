using System;
using UnityEngine;
using Zenject;

public class ProcessTriangleController : MonoBehaviour
{
    private TriangleModelView triangleView;

    public Action<float, float> OnBuildShape;

    [Inject]
    public void Construct (TriangleModelView newTriangleView)
    {
        triangleView = newTriangleView;
    }

    private void Start()
    {
        triangleView.OnShapeRender += ProcessShape;
    }

    private void ProcessShape(ValueTuple<string, string> sides)
    {
        OnBuildShape?.Invoke(float.Parse(sides.Item1), float.Parse(sides.Item2));
    }
}
