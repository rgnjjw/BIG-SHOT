using System.Collections;
using TMPro;
using UnityEngine;

public class TextOutput : MonoBehaviour
{
    private static readonly WaitForSecondsRealtime waitForSeconds = new WaitForSecondsRealtime(0.01f);
    private Coroutine _scoreCoroutine;

    private void Awake()
    {
        if (ScoreManager.Instance == null)
        {
            return;
        }

        ScoreManager.Instance.OnScoreChanged += UpdateUI;
    }

    private void OnDestroy()
    {
        if (ScoreManager.Instance != null)
            ScoreManager.Instance.OnScoreChanged -= UpdateUI;
    }

    private void UpdateUI(int score)
    {
        if (_scoreCoroutine != null)
            StopCoroutine(_scoreCoroutine);

        _scoreCoroutine = StartCoroutine(ScoreRoutine(score));
    }

    private IEnumerator ScoreRoutine(int targetScore)
    {
        TextMeshProUGUI txt = GetComponent<TextMeshProUGUI>();
        if (txt == null)
        {
            yield break;
        }

        yield return new WaitUntil(() => gameObject.activeInHierarchy);

        int displayScore = 0;
        while (displayScore <= targetScore)
        {
            txt.text = $"YOUR SCORE : {displayScore:D4}";
            displayScore++;
            yield return waitForSeconds;
        }
    }
}
