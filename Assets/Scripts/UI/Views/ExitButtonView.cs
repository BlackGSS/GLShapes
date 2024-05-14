using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtonView : OnClickView
{
    protected override void OnClick()
    {
        Application.Quit();
    }
}
