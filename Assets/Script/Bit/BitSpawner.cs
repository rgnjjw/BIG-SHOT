using UnityEngine;

public class BitSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _bit;

    private float _weight1 = 10;
    private float _weight2 = 10;
    private float _weight3 = 10;

    private float _levelTimer;
    private float _timer;
    private int _level = 1;
    private float _random;

    private void Start()
    {
        _random = Random.Range(1, 5f);
    }
    private void Update()
    {
        _levelTimer += Time.deltaTime;
        _timer += Time.deltaTime;
        if (_levelTimer >= 20)
        {
            _level++;
            _levelTimer = 0;
        }
        if (_timer >= _random)
        {
            SetRandomCount1();
            SetRandomCount2();
            Instantiate(_bit[CalculateWeight()], transform);
            SetRandom();
            _timer = 0;
        }
    }

    private void SetRandom()
    {
        _random = _level switch
        {
            1 => Random.Range(5f, 10f),
            2 => Random.Range(4.5f, 9.5f),
            3 => Random.Range(4f, 9f),
            4 => Random.Range(3.5f, 8.5f),
            5 => Random.Range(3f, 8f),
            6 => Random.Range(2.6f, 7.5f),
            7 => Random.Range(2.4f, 7f),
            8 => Random.Range(2.2f, 6.5f),
            9 => Random.Range(2f, 6f),
            10 => Random.Range(1.7f, 5.5f),
            _ => Random.Range(2f, 5f) // 이후는 고정 완화
        };
    }

    private void SetRandomCount1()
    {
        _weight2 = _level switch
        {
            _ when _level < 3 => 0f,
            3 => 1f,
            4 => 2f,
            5 => 3f,
            _ => _level * 2 - 6,
        };
    }
    private void SetRandomCount2()
    {
        _weight3 = _level switch
        {
            _ when _level < 3 => 0f,
            3 => 0.5f,
            4 => 1f,
            5 => 1.5f,
            _ => _level,
        };
    }
    private int CalculateWeight()
    {
        float all = _weight1 + _weight2 + _weight3;
        float random = Random.Range(0f, all);
        int bit = random switch
        {
            _ when random <= _weight1 => 0,
            _ when random <= _weight2 + _weight1 => 1,
            _ => 2
        };
        return bit;
    }
}
