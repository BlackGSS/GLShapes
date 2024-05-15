using UnityEngine;
using System;
using Zenject;

public abstract class ProcessShapeController<T, U> : MonoBehaviour where T : OnClickView
{
    protected T shapeView;
    protected U shape;

    [Inject]
    public void Construct(T newTriangleView, U shapeModel)
    {
        shapeView = newTriangleView;
        shape = shapeModel;
        AddListeners();
    }

    protected abstract void AddListeners();

    protected abstract void ProcessShape(ValueTuple<string, string> sides);
}
