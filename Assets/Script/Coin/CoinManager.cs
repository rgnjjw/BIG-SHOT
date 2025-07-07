using System;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }
    public int _coin;
    public int _roundCoin = 0;
    public int _coinValue = 10;

    public event Action<int> OnCoinChanged;

    private const string CoinKey = "CoinValue";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            _coin = PlayerPrefs.GetInt(CoinKey, 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlusCoin(int value)
    {
        _coin += value;
        PlayerPrefs.SetInt(CoinKey, _coin);
        PlayerPrefs.Save();

        OnCoinChanged?.Invoke(value); // 변경값 전달
    }

    public void ResetCoin()
    {
        _coin = 0;
        PlayerPrefs.DeleteKey(CoinKey);
    }
}
