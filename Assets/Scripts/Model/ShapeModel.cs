using UnityEngine;

public abstract class ShapeModel : MonoBehaviour
{
    [SerializeField] protected RectTransform origin;
    [SerializeField] protected Material material;

    //Upgrades: Perimeter as a variable for Set it only when the size change
    public float GetPerimeter()
    {
        float perimeter = SetPerimeter();
        return perimeter;
    }

    protected abstract float SetPerimeter();

    void OnPostRender()
    {
        DrawShape();
    }

    protected abstract void DrawShape();

}
