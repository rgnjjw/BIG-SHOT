using TMPro;
using UnityEngine;

public class BestScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _bestScore; // �ְ� ������ ǥ���� �ؽ�Ʈ

    private void Start()
    {
        UpdateBestScoreUI();
    }

    // ScoreManager�� �ְ� ������ �о �ؽ�Ʈ�� ǥ��
    public void UpdateBestScoreUI()
    {
        if (ScoreManager.Instance != null)
        {
            _bestScore.text = ScoreManager.Instance._bestScore.ToString("D4");
        }
    }
}
