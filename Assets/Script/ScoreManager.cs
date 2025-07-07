using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // 전역 접근 가능한 싱글톤 인스턴스
    public event Action<int> OnScoreChanged;
    public int CanAdd = 1;
    public int _bestScore;
    public int _score { get; private set; }     // 현재 점수
    public int _plusScore = 1;

    private void OnEnable()
    {
        // 싱글톤 인스턴스 설정
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // 중복 인스턴스 제거
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
        _bestScore = PlayerPrefs.GetInt("BestScore", 0); // 저장된 최고 점수 불러오기
        UpdateScore(); // UI 초기 표시
    }
    public void AddScore(int zero)
    {
        _score += _plusScore * zero; // 점수 추가
        UpdateScore();   // UI 갱신
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

        // 변경된 방식 사용: 권장되는 API로 교체
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
