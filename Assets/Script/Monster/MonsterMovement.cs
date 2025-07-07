using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public GameObject redPanel;
    public bool CanDamage = true;
    public float Damage = 0.2f;
    [SerializeField] GameObject _boomEft;
    [SerializeField] float _speed = 5;
    [SerializeField] CinemachineImpulseSource _carmara;

    Rigidbody2D _rb;
    Vector2 _moveDir;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _moveDir = Vector2.left;
    }

    private void Update()
    {
        _rb.linearVelocity = _moveDir * _speed;
        Damage = Values.Instance.DamageValue;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health health))
        {

            if (CanDamage == true)
            {
                Instantiate(_boomEft, transform.position, Quaternion.identity); // 부모 없이 생성
                health.Damage(Damage);
                _carmara.GenerateImpulse();
                StartCoroutine(RedThenDestroy());
            }

        }
    }

    private IEnumerator RedThenDestroy()
    {
        SoundManager.Instance.PlaySFX("BOOM");
        redPanel.SetActive(true);
        yield return new WaitForSeconds(0.43f);
        redPanel.SetActive(false);
        Destroy(gameObject);
    }

}
