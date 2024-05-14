using System;
using UnityEngine;

public class RectangleModelView : ShapeModelView<ValueTuple<string, string>>
{
    [SerializeField] private InputCustom leftSideLength;
    [SerializeField] private InputCustom topSideLength;
    private string leftSide;
    private string topSide;

    protected override void AddListeners()
    {
        base.AddListeners();
        leftSideLength.onTextChanged += (newText) => leftSide = newText;
        topSideLength.onTextChanged += (newText) => topSide = newText;
    }
    
    protected override void PackData()
    {
        data = (leftSide, topSide);
    }
}
