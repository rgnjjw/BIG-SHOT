using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float Damage = 0.2f;
    public bool CanDamage = true;
    protected Rigidbody2D _rb;
    protected Health _health;
    protected Vector2 _target = new Vector2(-15, -2f);
    protected PolygonCollider2D _collider;
    [SerializeField] protected CinemachineImpulseSource _carmara;
    [SerializeField] protected float _speed = 5f;
    [SerializeField] protected float _radius;
    public GameObject redPanel;


    protected void Awake()
    {
        _health = GetComponent<Health>();
        _collider = GetComponent<PolygonCollider2D>();
    }

    protected virtual void Start()
    {
        // Rigidbody2D 사용 여부에 따라 물리 이동 필요시 대비
        _rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        JelleyCut();
        transform.position = Vector2.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        Damage = Values.Instance.DamageValue;
        if (Vector2.Distance(transform.position, _target) < 0.01f)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obs"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.TryGetComponent<Health>(out Health health))
        {
            if (CanDamage == true)
            {
                health.Damage(Damage);
                _carmara.GenerateImpulse();
                StartCoroutine(Red());
            }

        }
    }
    private void JelleyCut()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _radius);
        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Jelley"))
            {
                Destroy(hit.gameObject);
            }
        }
    }

    private IEnumerator Red()
    {
        SoundManager.Instance.PlaySFX("HIT");
        redPanel.SetActive(true);
        yield return new WaitForSeconds(0.43f);
        redPanel.SetActive(false);
        Destroy(gameObject);
    }

}
