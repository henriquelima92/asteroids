using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public interface ITimer
{
    public UnityAction OnTrigger { get; }
    public bool HasTriggered { get; }
    public float CooldownTime { get; }
    public float CurrentTime { get; }


    void UpdateCooldown();
    void ResetTimer();
}
