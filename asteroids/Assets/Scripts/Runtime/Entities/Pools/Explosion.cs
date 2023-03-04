using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Explosion : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    private UnityAction<Explosion> _onFinishExploding;

    public void SetData(UnityAction<Explosion> onFinishExploding)
    {
        _onFinishExploding = onFinishExploding;
    }

    public void StartExplosion(Vector2 position)
    {
        StartCoroutine(Explode(position));
    }

    private IEnumerator Explode(Vector2 position)
    {
        transform.position = position;
        _particleSystem.Play();

        yield return new WaitForSeconds(_particleSystem.main.duration);
        _onFinishExploding.Invoke(this);
    }
}
