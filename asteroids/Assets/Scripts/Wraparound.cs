using UnityEngine;

public class Wraparound
{
    private MapBoundaries _mapBoundaries;
    private Transform _target;

    public Wraparound(MapBoundaries mapBoundaries, Transform target)
    {
        _mapBoundaries = mapBoundaries;
        _target = target;
    }

    public void CheckBoundaries()
    {
        if(!_target)
        {
            return;
        }

        if (_target.position.x < _mapBoundaries.Left)
        {
            _target.position = new Vector2(_mapBoundaries.Right, _target.position.y);
        }

        if (_target.position.x > _mapBoundaries.Right)
        {
            _target.position = new Vector2(_mapBoundaries.Left, _target.position.y);
        }

        if (_target.position.y > _mapBoundaries.Top)
        {
            _target.position = new Vector2(_target.position.x, _mapBoundaries.Bottom);
        }

        if (_target.position.y < _mapBoundaries.Bottom)
        {
            _target.position = new Vector2(_target.position.x, _mapBoundaries.Top);
        }
    }

    public bool IsSaucerInsideBoundaries()
    {
        if (_target.position.y > _mapBoundaries.Top)
        {
            _target.position = new Vector2(_target.position.x, _mapBoundaries.Bottom);
        }

        if (_target.position.y < _mapBoundaries.Bottom)
        {
            _target.position = new Vector2(_target.position.x, _mapBoundaries.Top);
        }

        if (_target.position.x < _mapBoundaries.Left || _target.position.x > _mapBoundaries.Right)
        {
            return false;
        }

        return true;
    }
}
