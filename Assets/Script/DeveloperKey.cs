using UnityEngine;
using UnityEngine.InputSystem;

public class DeveloperKey : MonoBehaviour
{
    private void Update()
    {
        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            CoinManager.Instance._coin += 100;
        }
    }
}
