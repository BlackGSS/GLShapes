using UnityEngine;
using Zenject;

public abstract class ShapeDrawer<T> : MonoBehaviour where T : ShapeModel
{
    [SerializeField] protected RectTransform origin;
    [SerializeField] protected Material material;

    protected T shape = null;

    [Inject]
    public void Construct(T newCircle)
    {
        shape = newCircle;
    }

    void OnPostRender()
    {
        if (shape != null)
        {
            CheckOrigin();
            DrawShape();
        }
    }

    private void CheckOrigin()
    {
        if (shape.origin != null & shape.origin != origin)
        {
            origin = shape.origin;
        }
    }

    protected abstract void DrawShape();
}

public interface IPerimeter
{
    public float Perimeter { get; set; }
    public float SetPerimeter();
}
