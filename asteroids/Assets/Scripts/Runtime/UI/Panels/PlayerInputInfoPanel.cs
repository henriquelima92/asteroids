using TMPro;
using UnityEngine;

public class PlayerInputInfoPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _thrustingKey;
    [SerializeField] private TextMeshProUGUI _rotateLeftKey;
    [SerializeField] private TextMeshProUGUI _rotateRightKey;
    [SerializeField] private TextMeshProUGUI _shotKey;
    [SerializeField] private TextMeshProUGUI _hyperSpaceKey;

    public void SetPanel(PlayerInputs playerInputs)
    {
        _thrustingKey.text = playerInputs.Thrust.ToString();
        _rotateLeftKey.text = playerInputs.RotateLeft.ToString();
        _rotateRightKey.text = playerInputs.RotateRight.ToString();
        _shotKey.text = playerInputs.Shot.ToString();
        _hyperSpaceKey.text = playerInputs.HyperSpace.ToString();
    }
}
