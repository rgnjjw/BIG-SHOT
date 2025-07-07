using TMPro;
using UnityEngine;

public class Round : MonoBehaviour
{
    private TextMeshProUGUI roundText;
    private float _timer = 0;
    private int _round = 0;
    private void Awake()
    {
        roundText = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        _timer = 0;
        _round = 0;
    }
    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= 20 && _round <= 10)
        {
            _round++;
            roundText.text = $"Round : {_round}";
            _timer = 0;
        }
        if (_round >= 11)
        {
            roundText.text = $"Round : Infinity";
        }
    }
}
