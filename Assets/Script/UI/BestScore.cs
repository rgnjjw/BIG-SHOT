using TMPro;
using UnityEngine;

public class BestScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _bestScore; // 최고 점수를 표시할 텍스트

    private void Start()
    {
        UpdateBestScoreUI();
    }

    // ScoreManager의 최고 점수를 읽어서 텍스트에 표시
    public void UpdateBestScoreUI()
    {
        if (ScoreManager.Instance != null)
        {
            _bestScore.text = ScoreManager.Instance._bestScore.ToString("D4");
        }
    }
}
