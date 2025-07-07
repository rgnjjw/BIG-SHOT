using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AbLevel : MonoBehaviour
{
    public static AbLevel Instance;

    public int _scoreUpLevel { get; set; } = 1;
    public int _healthUPLevel { get; set; } = 1;
    public int _itemUPLevel { get; set; } = 1;

    public TextMeshProUGUI hp;
    public TextMeshProUGUI score;
    public TextMeshProUGUI item;

    private void Awake()
    {
        // 싱글톤 중복 방지
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 씬이 로드될 때마다 호출
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0) // UI가 존재하는 메인 씬이라면
        {
            // TextMeshProUGUI 재연결 (오브젝트 이름은 네 Hierarchy에 맞게 수정해)
            hp = GameObject.Find("HpText")?.GetComponent<TextMeshProUGUI>();
            score = GameObject.Find("ScoreText")?.GetComponent<TextMeshProUGUI>();
            item = GameObject.Find("ItemText")?.GetComponent<TextMeshProUGUI>();

            // 텍스트 다시 세팅
            RefreshUI();
        }
    }

    public void RefreshUI()
    {
        hp.text = _healthUPLevel switch
        {
            6 => "Hp UP : Max",
            _ => $"Hp UP : {50 * _healthUPLevel}"
        };

        score.text = _scoreUpLevel switch
        {
            4 => "Score UP : Max",
            3 => "Score UP : 1000",
            2 => "Score UP : 500",
            1 => "Score UP : 200",
            _ => "Score UP : ???"
        };

        item.text = _itemUPLevel switch
        {
            4 => "Item UP : Max",
            3 => "Item UP : 1000",
            2 => "Item UP : 500",
            1 => "Item UP : 200",
            _ => "Item UP : ???"
        };
    }
}
