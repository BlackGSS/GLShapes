using System;
using UnityEngine;
using Zenject;

public class ProcessCircleController : MonoBehaviour
{
    private CircleModelView circleView;

    //Improvement: Data driven as Circle, Rectangle, etc
    public Action<float, int> OnBuildShape;

    [Inject]
    public void Construct(CircleModelView newCircleView)
    {
        circleView = newCircleView;
    }

    private void Start()
    {
        circleView.OnShapeRender += ProcessShape;
    }

    private void ProcessShape(ValueTuple<string, string> sides)
    {
        OnBuildShape?.Invoke(float.Parse(sides.Item1), int.Parse(sides.Item2));
    }
}
