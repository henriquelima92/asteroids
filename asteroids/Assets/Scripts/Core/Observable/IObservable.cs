using System;
using UnityEngine.Events;

public interface IObservable<T>
{
    public UnityAction<T> Actions { get; }

    void AddListener(UnityAction<T> action);
    void Invoke(T obj);
}
