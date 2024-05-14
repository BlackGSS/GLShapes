using System;
using UnityEngine;

public class TriangleModelView : ShapeModelView<ValueTuple<string, string>>
{
    [SerializeField] private InputCustom leftSideInput;
    [SerializeField] private InputCustom bottomSideInput;

    private string leftSideString;
    private string bottomSideString;
    
    protected override void AddListeners()
    {
        base.AddListeners();
        leftSideInput.onTextChanged += (newText) => leftSideString = newText;
        bottomSideInput.onTextChanged += (newText) => bottomSideString = newText;
    }

    protected override void PackData()
    {
        data = (leftSideString, bottomSideString);
    }
}
