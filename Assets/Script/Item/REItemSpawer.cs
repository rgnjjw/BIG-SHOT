using UnityEngine;

public class REItemSpawer : MonoBehaviour
{
    [SerializeField] GameObject _healItem;
    [SerializeField] GameObject _coin;
    [SerializeField] GameObject ivs;
    [SerializeField] GameObject realDeadZone;
    [SerializeField] GameObject ivsEft;
    float _healTimer = 0;
    float _coinTimer = 0;
    float _ivsTimer = 0;
    private void Update()
    {
        _healTimer += Time.deltaTime;
        _coinTimer += Time.deltaTime;
        _ivsTimer += Time.deltaTime;
        if (_healTimer >= 30)
        {
            Instantiate(_healItem, transform);
            _healTimer = 0;
        }
        if (_coinTimer >= 5)
        {
            if (Random.value < 0.3f)
            {
                Instantiate(_coin, transform);
                _coinTimer = 0;
            }
        }
        if (_ivsTimer >= 17)
        {
            int radom = Random.Range(1, 3);
            if (radom == 2)
            {
                Invincibility invincibility = Instantiate(ivs, transform).GetComponent<Invincibility>();
                invincibility.eft = ivsEft;
                _ivsTimer = 0;
            }
        }
    }
}
