using System;
using UnityEngine;

public class CircleModelView : ShapeModelView<ValueTuple<string, string>>
{
    [SerializeField] private InputCustom radiusInput;
    [SerializeField] private InputCustom segmentsInput;

    private string radiusString;
    private string segmentsString;

    protected override void AddListeners()
    {
        base.AddListeners();
        radiusInput.onTextChanged += (newText) => radiusString = newText;
        segmentsInput.onTextChanged += (newText) => segmentsString = newText;
    }

    protected override void PackData()
    {
        data = (radiusString, segmentsString);
    }
}
