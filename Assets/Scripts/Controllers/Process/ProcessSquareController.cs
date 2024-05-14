using System;
using UnityEngine;
using Zenject;

public class ProcessSquareController : MonoBehaviour
{
    private SquareModelView squareView;

    public Action<float> OnBuildShape;

    [Inject]
    public void Construct (SquareModelView newSquareView)
    {
        squareView = newSquareView;
    }

    private void Start()
    {
        squareView.OnShapeRender += ProcessShape;
    }

    private void ProcessShape(string length)
    {
        OnBuildShape?.Invoke(float.Parse(length));
    }
}
