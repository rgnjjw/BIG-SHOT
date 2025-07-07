using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class OrinSlideOB : MonoBehaviour
{
    public float Damage = 0.2f;
    public bool CanDamage = true;
    protected Rigidbody2D _rb;
    protected Health _health;
    protected Vector2 _target = new Vector2(-15, 2f);
    [SerializeField] protected float _speed = 5f;
    [SerializeField] protected float _radius;
    [SerializeField] protected CinemachineImpulseSource _camera;
    public GameObject _redPanel;

    protected void Awake()
    {
        _health = GetComponent<Health>();
    }

    protected virtual void Start()
    {
        // Rigidbody2D 사용 여부에 따라 물리 이동 필요시 대비
        _rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        // 문법 오류 수정: *target -> _target, *speed -> _speed
        transform.position = Vector2.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        Damage = Values.Instance.DamageValue;

        if (Vector2.Distance(transform.position, _target) < 0.01f)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health health))
        {
            if (CanDamage == true)
            {
                health.Damage(Damage);
                _camera.GenerateImpulse();
                StartCoroutine(RedPanel());
            }
        }
    }

    protected IEnumerator RedPanel()
    {
        SoundManager.Instance.PlaySFX("HIT");
        _redPanel.SetActive(true);
        yield return new WaitForSeconds(0.43f);
        _redPanel.SetActive(false);
        Destroy(gameObject);
    }
}