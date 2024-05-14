using System;
using TMPro;
using UnityEngine;

public class InputCustom : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;

    public Action<string> onTextChanged;

    private void Start()
    {
        inputField.onValueChanged.AddListener((newtext) => onTextChanged?.Invoke(newtext));
        onTextChanged?.Invoke(inputField.text);
    }
}
