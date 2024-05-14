using UnityEngine;
using UnityEngine.UI;

public abstract class OnClickView : MonoBehaviour
{
    [SerializeField] private Button button;
    private void Awake()
    {
        AddListeners();
    }

    protected virtual void AddListeners()
    {
        button.onClick.AddListener(OnClick);
    }

    protected abstract void OnClick() ;
}
