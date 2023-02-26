using System;

[Serializable]
public struct FloatRange
{
    public float Min;
    public float Max;

    public float GetRandomRange()
    {
        return UnityEngine.Random.Range(Min, Max);
    }
}
