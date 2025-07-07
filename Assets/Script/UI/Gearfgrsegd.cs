using TMPro;
using UnityEngine;

public class Gearfgrsegd : MonoBehaviour
{
    private void Awake()
    {
        ScoreManager.Instance.OnScoreChanged += UpdateUI;
    }
    private void OnDestroy()
    {
        ScoreManager.Instance.OnScoreChanged -= UpdateUI;
    }

    private void UpdateUI(int obj)
    {
        GetComponent<TextMeshProUGUI>().text = obj.ToString("D4");
    }
}
