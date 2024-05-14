using UnityEngine;
using System;
using Zenject;

public class ProcessShapeController<T, U> : MonoBehaviour where T : OnClickView
{
    private T shapeView;

    public Action<float, float> OnBuildShape;

    [Inject]
    public void Construct (T newTriangleView)
    {
        shapeView = newTriangleView;
    }

    private void Start()
    {
        // shapeView.OnShapeRender += ProcessShape;
    }

    private void ProcessShape(ValueTuple<string, string> sides)
    {
        OnBuildShape?.Invoke(float.Parse(sides.Item1), float.Parse(sides.Item2));
    }
}
