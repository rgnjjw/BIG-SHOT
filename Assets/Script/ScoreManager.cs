using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // ���� ���� ������ �̱��� �ν��Ͻ�
    public event Action<int> OnScoreChanged;
    public int CanAdd = 1;
    public int _bestScore;
    public int _score { get; private set; }     // ���� ����
    public int _plusScore = 1;

    private void OnEnable()
    {
        // �̱��� �ν��Ͻ� ����
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // �ߺ� �ν��Ͻ� ����
            return;
        }
        SceneManager.activeSceneChanged += OnSceneChanged;
    }
    private void OnDisable()
    {
        SceneManager.activeSceneChanged -= OnSceneChanged;
    }

    private void OnSceneChanged(Scene arg0, Scene arg1)
    {
        CanAdd = 1;
    }

    private void Start()
    {
        CanAdd = 1;
        PlayerPrefs.DeleteKey("BestScore");
        _bestScore = PlayerPrefs.GetInt("BestScore", 0); // ����� �ְ� ���� �ҷ�����
        UpdateScore(); // UI �ʱ� ǥ��
    }
    public void AddScore(int zero)
    {
        _score += _plusScore * zero; // ���� �߰�
        UpdateScore();   // UI ����
    }

    private void UpdateScore()
    {
        OnScoreChanged?.Invoke(_score);
    }

    public void GameOver()
    {
        if (_score > _bestScore)
        {
            _bestScore = _score;
            PlayerPrefs.SetInt("BestScore", _bestScore);
            PlayerPrefs.Save();
        }

        // ����� ��� ���: ����Ǵ� API�� ��ü
        BestScore bestScoreUI = FindFirstObjectByType<BestScore>();
        if (bestScoreUI != null)
        {
            bestScoreUI.UpdateBestScoreUI();
        }
    }
    public void ReStart()
    {
        _score = 0;
    }
}
