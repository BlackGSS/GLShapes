using UnityEngine;
using TMPro;

public class DropdownView : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private GameObject[] dropdownValues;
    
    private GameObject currentPanel;

    void Start()
    {
        for (int i = 0; i < dropdownValues.Length; i++)
        {
            dropdownValues[i].SetActive(false);
        }

        dropdown.value = 0;
        OnValueChanged(0);
        dropdown.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnValueChanged(int valueSelected)
    {
        currentPanel?.SetActive(false);
        GameObject newPanel = dropdownValues[valueSelected];
        newPanel.SetActive(true);
        currentPanel = newPanel;
    }
}