using System;
using UnityEngine;

[Serializable]
public struct HyperSpaceBoundaries
{
    public float Left;
    public float Right;
    public float Top;
    public float Bottom;

#if UNITY_EDITOR
    public void DrawGizmosBoundary()
    {
        var leftTop = new Vector2(Left, Top);
        var rightTop = new Vector2(Right, Top);

        var leftBottom = new Vector2(Left, Bottom);
        var rightBottom = new Vector2(Right, Bottom);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(leftTop, rightTop);
        Gizmos.DrawLine(rightTop, rightBottom);
        Gizmos.DrawLine(rightBottom, leftBottom);
        Gizmos.DrawLine(leftBottom, leftTop);
    }
#endif

    public void SetHyperspace(Transform entity)
    {
        if(entity.position.x < Left)
        {
            entity.position = new Vector2(Right, entity.position.y);
        }

        if(entity.position.x > Right)
        {
            entity.position = new Vector2(Left, entity.position.y);
        }

        if(entity.position.y > Top)
        {
            entity.position = new Vector2(entity.position.x, Bottom);
        }

        if(entity.position.y < Bottom)
        {
            entity.position = new Vector2(entity.position.x, Top);
        }
    }

    public bool IsInHyperSpace(Transform entity)
    {
        return entity.position.x < Left || entity.position.x > Right ||
            entity.position.y > Top || entity.position.y < Bottom;
    }
}

public class HyperSpace : MonoBehaviour
{
    [SerializeField] private HyperSpaceBoundaries _hyperSpaceBoundaries;
    [SerializeField] private HeroShip _ship;

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        _hyperSpaceBoundaries.DrawGizmosBoundary();
    }
#endif

    private void Update()
    {
        _hyperSpaceBoundaries.SetHyperspace(_ship.transform);
    }
}
