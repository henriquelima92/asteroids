using UnityEngine;

[CreateAssetMenu(fileName = "MapBoundaries", menuName = "Data/MapBoundaries/MapBoundaries", order = 1)]
public class MapBoundariesData : ScriptableObject
{
    [SerializeField] private MapBoundaries _mapBoundaries;
    public MapBoundaries MapBoundaries => _mapBoundaries;
}
