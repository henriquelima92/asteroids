using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private Mover _movement;

    private void Start()
    {
        _movement.SetMovingState(MovingState.Thrusting);
        _movement.Move(RandomUtility.GetRandomDirection());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer(EntityUtility.PlayerShot))
        {
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
