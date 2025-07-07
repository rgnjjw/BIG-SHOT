using TMPro;
using UnityEngine;

public class CoinText : MonoBehaviour
{
    TextMeshProUGUI _text;
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        _text.text = CoinManager.Instance._coin.ToString("D5");
    }
}

