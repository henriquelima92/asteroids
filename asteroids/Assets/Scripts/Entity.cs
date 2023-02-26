using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D _rigidbody;
    public Rigidbody2D Rigidbody => _rigidbody;

    protected Wraparound Wraparound;

    public virtual void Set(MapBoundaries mapBoundaries)
    {
        Wraparound = new Wraparound(mapBoundaries, transform);
    }

    protected virtual void Update()
    {
        Wraparound.CheckBoundaries();
    }
}
