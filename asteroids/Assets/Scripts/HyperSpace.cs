using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct MapBoundaries
{
    public float Left;
    public float Right;
    public float Top;
    public float Bottom;
}

[Serializable]
public class HyperSpace
{
    [SerializeField] private MapBoundaries _mapBoundaries;

    private List<GameObject> _entities;
#if UNITY_EDITOR
    public void DrawGizmosBoundary()
    {
        var leftTop = new Vector2(_mapBoundaries.Left, _mapBoundaries.Top);
        var rightTop = new Vector2(_mapBoundaries.Right, _mapBoundaries.Top);

        var leftBottom = new Vector2(_mapBoundaries.Left, _mapBoundaries.Bottom);
        var rightBottom = new Vector2(_mapBoundaries.Right, _mapBoundaries.Bottom);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(leftTop, rightTop);
        Gizmos.DrawLine(rightTop, rightBottom);
        Gizmos.DrawLine(rightBottom, leftBottom);
        Gizmos.DrawLine(leftBottom, leftTop);
    }
#endif

    public void Initialize(List<GameObject> mapObjects)
    {
        //_mapBoundaries = mapBoundaries;
        _entities = mapObjects;
    }

    public void UpdateHyperSpace()
    {
        foreach (var entity in _entities)
        {
            if(!entity.activeInHierarchy)
            {
                continue;
            }

            if(EntityUtility.IsPlayerShot(entity))
            {
                if(HyperSpaceUtility.IsInHyperSpace(entity.transform.position, _mapBoundaries))
                {
                    entity.SetActive(false);
                    continue;
                }
            }

            if (entity.transform.position.x < _mapBoundaries.Left)
            {
                entity.transform.position = new Vector2(_mapBoundaries.Right, entity.transform.position.y);
            }

            if (entity.transform.position.x > _mapBoundaries.Right)
            {
                entity.transform.position = new Vector2(_mapBoundaries.Left, entity.transform.position.y);
            }

            if (entity.transform.position.y > _mapBoundaries.Top)
            {
                entity.transform.position = new Vector2(entity.transform.position.x, _mapBoundaries.Bottom);
            }

            if (entity.transform.position.y < _mapBoundaries.Bottom)
            {
                entity.transform.position = new Vector2(entity.transform.position.x, _mapBoundaries.Top);
            }
        }
    }
}
