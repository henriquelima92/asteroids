using System;
using UnityEngine;

public class WraparoundDrawer : MonoBehaviour
{
    [SerializeField] private MapBoundariesData _mapBoundariesData;

#if UNITY_EDITOR
    [SerializeField] private bool _drawGizmos;

    private void OnDrawGizmos()
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
}
