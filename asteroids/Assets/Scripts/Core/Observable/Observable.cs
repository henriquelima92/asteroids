using System;
using UnityEngine.Events;

public class Observable : IObservable
{
    public UnityAction Actions { get;  private set; }

    public void AddListener(UnityAction action)
    {
        Actions = action;
    }
    public void Invoke()
    {
        Actions?.Invoke();
    }
}
