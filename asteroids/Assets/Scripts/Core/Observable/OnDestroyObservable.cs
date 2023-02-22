using UnityEngine.Events;

public class OnDestroyObservable<Transform> : IObservable<Transform>
{
    public UnityAction<Transform> Actions { get;  private set; }

    public void AddListener(UnityAction<Transform> action)
    {
        Actions = action;
    }
    public void Invoke(Transform obj)
    {
        Actions?.Invoke(obj);
    }
}
