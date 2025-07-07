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
        // �̱��� �ߺ� ����
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

    // ���� �ε�� ������ ȣ��
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0) // UI�� �����ϴ� ���� ���̶��
        {
            // TextMeshProUGUI �翬�� (������Ʈ �̸��� �� Hierarchy�� �°� ������)
            hp = GameObject.Find("HpText")?.GetComponent<TextMeshProUGUI>();
            score = GameObject.Find("ScoreText")?.GetComponent<TextMeshProUGUI>();
            item = GameObject.Find("ItemText")?.GetComponent<TextMeshProUGUI>();

            // �ؽ�Ʈ �ٽ� ����
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
