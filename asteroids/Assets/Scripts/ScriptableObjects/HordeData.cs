using UnityEngine;

[CreateAssetMenu(fileName = "Horde", menuName = "Data/Hordes/Horde", order = 1)]
public class HordeData : ScriptableObject
{
    [SerializeField] private Horde _horde;
    public Horde Horde => _horde;
}
