using UnityEngine;

public class ScoreJelley : MonoBehaviour
{
    Vector2 _target = new Vector2(-15, -1.4f);
    [SerializeField] float _speed = 5f;

    void Update()
    {
        // 현재 위치에서 목표 위치로 일정 속도로 이동
        transform.position = Vector2.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        // 도착하면 파괴
        if (Vector2.Distance(transform.position, _target) < 0.01f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            SoundManager.Instance.PlaySFX("JELLY");
            ScoreManager.Instance.AddScore(ScoreManager.Instance.CanAdd);
            Destroy(gameObject);
        }
    }
}
