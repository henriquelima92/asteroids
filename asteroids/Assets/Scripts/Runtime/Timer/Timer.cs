using UnityEngine;
using UnityEngine.Events;

public class Timer : ITimer
{
    public UnityAction OnTrigger { get; private set; }
    public bool HasTriggered { get; private set; }
    public float CooldownTime { get; private set; }
    public float CurrentTime { get; private set; }


    public Timer(float cooldownTime, UnityAction onTrigger)
    {
        CooldownTime = cooldownTime;
        OnTrigger = onTrigger;
    }

    public void UpdateCooldown()
    {
        if(CurrentTime > CooldownTime )
        {
            if(!HasTriggered)
            {
                OnTrigger?.Invoke();
                HasTriggered = true;
            }

            return;
        }

        CurrentTime += Time.deltaTime;
    }

    public void ResetTimer()
    {
        CurrentTime = 0;
        HasTriggered = false;
    }
}
