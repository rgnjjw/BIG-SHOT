using System.Collections;
using TMPro;
using UnityEngine;

public class CoinUIU : MonoBehaviour
{
    private static readonly WaitForSecondsRealtime waitForSeconds = new WaitForSecondsRealtime(0.01f);
    private Coroutine _updateCoroutine;

    private void OnEnable()
    {
        // 오브젝트가 활성화될 때 코인 출력 시작
        StartCoinUpdate();
    }

    private void StartCoinUpdate()
    {
        if (_updateCoroutine != null)
            StopCoroutine(_updateCoroutine);

        int target = CoinManager.Instance._roundCoin;
        _updateCoroutine = StartCoroutine(ShowCoinRoutine(target));//증가
    }

    private IEnumerator ShowCoinRoutine(int targetCoin)
    {
        var txt = GetComponent<TextMeshProUGUI>();
        int displayCoin = 0;

        while (displayCoin <= targetCoin)
        {
            txt.text = $"COIN : {displayCoin:D4}";
            displayCoin++;
            yield return waitForSeconds;
        }
    }
}
