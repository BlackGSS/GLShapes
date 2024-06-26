using System;
using UnityEngine;

public class SquareModelView : ShapeModelView<ValueTuple<string, string>>
{
    [SerializeField] private InputCustom sideLength;
    private string firstSideString;

    protected override void AddListeners()
    {
        base.AddListeners();
        sideLength.onTextChanged += (newText) => firstSideString = newText;
    }
    
    protected override void PackData()
    {
        data = (firstSideString, null);
    }
}
