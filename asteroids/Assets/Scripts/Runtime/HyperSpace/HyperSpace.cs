using UnityEngine;

public class HyperSpace
{
    private MapBoundaries _mapBoundaries;
    private Transform _target;

    public HyperSpace(MapBoundaries mapBoundaries, Transform target)
    {
        _mapBoundaries = mapBoundaries;
        _target = target;
    }

    public void GoToHyperSpace()
    {
        var xPosition = Random.Range(_mapBoundaries.Left, _mapBoundaries.Right);
        var yPosition = Random.Range(_mapBoundaries.Bottom, _mapBoundaries.Top);

        _target.position = new Vector2(xPosition, yPosition);
    }
}
