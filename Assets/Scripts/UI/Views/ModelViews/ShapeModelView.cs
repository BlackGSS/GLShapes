using UnityEngine;
using System;

public abstract class ShapeModelView<T> : OnClickView
{
    protected T data;
    public Action<T> OnShapeRender;

    protected override void OnClick()
    {
        PackData();
        //Improvement: Check if the data is valid before send to render, isn't null or isn't equal to 0
        OnShapeRender?.Invoke(data);
    }

    protected abstract void PackData();
}
