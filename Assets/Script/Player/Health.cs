using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Image _healthbar;
    [SerializeField] private GameObject _player;

    [SerializeField] GameObject _box1;
    [SerializeField] GameObject _box2;
    [SerializeField] GameObject _box3;
    [SerializeField] GameObject _box4;
    [SerializeField] GameObject _gameOverUI;

    public static Health Instance;
    public float _hp;

    private bool _isDead;

    private void Awake()
    {
        CoinManager.Instance._roundCoin = 0;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }



    private void Start()
    {
        _hp = StartHealth.Instance._startHealth;
        StartCoroutine(HealthDelay());
        CoinManager.Instance._coinValue = 10;
    }

    private void Update()
    {
        if (_healthbar != null)
        {
            _healthbar.fillAmount = _hp;
        }

        if (_hp <= 0 && !_isDead)
        {
            _isDead = true;

            ScoreManager.Instance.GameOver();
            ScoreManager.Instance.CanAdd = 0;
            StopCoroutine(HealthDelay());
            StartCoroutine(Box());
        }
    }

    public void Damage(float minusHp)
    {
        _hp -= minusHp;
    }

    public void Heal(float healvalue)
    {
        _hp += healvalue;
    }

    IEnumerator HealthDelay()
    {
        while (_hp > 0)
        {
            _hp -= 0.001f;
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator Box()
    {
        BGM.Instance.Die();
        CoinManager.Instance._coinValue = 0;
        _box1.SetActive(true);
        _box2.SetActive(true);
        yield return new WaitForSecondsRealtime(0.6f);
        _box3.SetActive(true);
        _box4.SetActive(true);
        yield return new WaitForSecondsRealtime(0.6f);
        _gameOverUI.SetActive(true);
        yield return new WaitForSecondsRealtime(1.5f);

        Destroy(_player);
    }
    public void StartHp(float plusValue)
    {
        _hp += plusValue;
    }
}
