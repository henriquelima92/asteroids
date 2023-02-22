using System;
using UnityEngine.Events;

public interface IObservable
{
    public UnityAction Actions { get; }

    void AddListener(UnityAction action);
    void Invoke();
}
