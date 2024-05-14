using System;
using UnityEngine;
using UnityEngine.UI;

public class ReorderGridView : MonoBehaviour
{
    [SerializeField] private Button buttonDescend;
    [SerializeField] private Button buttonAscend;
    public Action OnReorderDescendShapes;
    public Action OnReorderAscendShapes;

    private void Start()
    {
        buttonDescend.onClick.AddListener(() => OnReorderDescendShapes.Invoke());
        buttonAscend.onClick.AddListener(() => OnReorderAscendShapes.Invoke());
    }
}
