using System;

[Serializable]
public struct Range
{
    public int Min;
    public int Max;

    public int GetRandomRange()
    {
        return UnityEngine.Random.Range(Min, Max);
    }
}
