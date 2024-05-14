using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class CalculatePerimeterController : MonoBehaviour
{
    [SerializeField] private ShapeModel[] shapeModels;
    [SerializeField] private ReorderGridView reorderGridView;
    public Dictionary<ShapeModel, float> shapePerimeters = new Dictionary<ShapeModel, float>();
    public Action<Dictionary<ShapeModel, float>> OnPerimetersCalculated;

    [Inject]
    public void Construct(ShapeModel[] currentShapeModels, ReorderGridView newReorderGridView)
    {
        shapeModels = currentShapeModels;
        reorderGridView = newReorderGridView;
    }

    void Start()
    {
        for (int i = 0; i < shapeModels.Length; i++)
        {
            shapePerimeters.Add(shapeModels[i], 0);
        }

        reorderGridView.OnReorderDescendShapes += () => CalculateReorderShapesByDescend(true);
        reorderGridView.OnReorderAscendShapes += () => CalculateReorderShapesByDescend(false);
    }

    private void CalculateReorderShapesByDescend(bool shouldOrderByDescend)
    {
        SetPerimeters();
        OrderByDescending(shouldOrderByDescend);
        OnPerimetersCalculated?.Invoke(shapePerimeters);
    }

    private void SetPerimeters()
    {
        for (int i = 0; i < shapePerimeters.Count; i++)
        {
            shapePerimeters[shapeModels[i]] = shapeModels[i].GetPerimeter();
        }
    }

    private void OrderByDescending(bool shouldOrderByDescend)
    {
        var shapesWith0perimeter = shapePerimeters.Where(x => x.Value == 0).ToList();

        for (int i = 0; i < shapesWith0perimeter.Count; i++)
        {
            shapePerimeters.Remove(shapesWith0perimeter[i].Key);
        }

        var currentShapePerimeters = shouldOrderByDescend ? shapePerimeters.OrderByDescending(x => x.Value).ToList() : shapePerimeters.OrderBy(x => x.Value).ToList();
        shapePerimeters = currentShapePerimeters.ToDictionary(x => x.Key, x => x.Value);

        for (int i = 0; i < shapesWith0perimeter.Count; i++)
        {
            shapePerimeters.Add(shapesWith0perimeter[i].Key, shapesWith0perimeter[i].Value);
        }
    }
}
