using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HyperSpace
{
    private MapBoundariesData _mapBoundariesData;
    private List<GameObject> _entities;

#if UNITY_EDITOR
    [SerializeField] private bool _drawGizmos;

    public void DrawGizmosBoundary()
    {
        if(!_mapBoundariesData || !_drawGizmos)
        {
            return;
        }

        Gizmos.color = Color.blue;
        Gizmos.DrawCube(_mapBoundariesData.MapBoundaries.Center, _mapBoundariesData.MapBoundaries.Size);

        Gizmos.color = Color.red;
        Gizmos.DrawCube(_mapBoundariesData.MapBoundaries.SafeAreaCenter, _mapBoundariesData.MapBoundaries.SafeAreaSize);
    }
#endif

    public void Initialize(MapBoundariesData mapBoundariesData, List<GameObject> mapObjects)
    {
        _entities = new List<GameObject>();

        _mapBoundariesData = mapBoundariesData;
        _entities = mapObjects;
    }

    public void UpdateHyperSpace()
    {
        if(_entities == null)
        {
            return;
        }

        foreach (var entity in _entities)
        {
            if(!entity.activeInHierarchy)
            {
                continue;
            }

            if(EntityUtility.IsPlayerShot(entity))
            {
                if(HyperSpaceUtility.IsInHyperSpace(entity.transform.position, _mapBoundariesData.MapBoundaries))
                {
                    entity.SetActive(false);
                    continue;
                }
            }

            if (entity.transform.position.x < _mapBoundariesData.MapBoundaries.Left)
            {
                entity.transform.position = new Vector2(_mapBoundariesData.MapBoundaries.Right, entity.transform.position.y);
            }

            if (entity.transform.position.x > _mapBoundariesData.MapBoundaries.Right)
            {
                entity.transform.position = new Vector2(_mapBoundariesData.MapBoundaries.Left, entity.transform.position.y);
            }

            if (entity.transform.position.y > _mapBoundariesData.MapBoundaries.Top)
            {
                entity.transform.position = new Vector2(entity.transform.position.x, _mapBoundariesData.MapBoundaries.Bottom);
            }

            if (entity.transform.position.y < _mapBoundariesData.MapBoundaries.Bottom)
            {
                entity.transform.position = new Vector2(entity.transform.position.x, _mapBoundariesData.MapBoundaries.Top);
            }
        }
    }
}
