using DG.Tweening;
using UnityEngine;

public class SlideObstacle : OrinSlideOB
{
    public Vector2 overlapSize = new Vector2(2, 10);  // 가로 10, 세로 2
    public float verticalOffset = -2f;                // 아래로 오프셋
    private bool hasStartedAnimation = false;         // 애니메이션 중복 실행 방지

    protected override void Start()
    {
        // 초기 속도를 0으로 설정 (애니메이션 완료 전까지 이동하지 않음)
        _speed = 0f;
        base.Start();

        // 시작 시 한 번만 애니메이션 실행
        StartSlideAnimation();
    }

    private void StartSlideAnimation()
    {
        if (hasStartedAnimation) return;
        hasStartedAnimation = true;

        // 움직임 애니메이션
        Sequence sqe = DOTween.Sequence();
        sqe.Append(transform.DOMoveY(1.8f, 0.5f).SetEase(Ease.Linear));
        sqe.OnComplete(() =>
        {
            _speed = 6;
        });
    }

    protected override void Update()
    {
        base.Update();

        // 장애물 감지 (매 프레임마다 실행해도 괜찮음)
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position + (Vector3)Vector2.up * verticalOffset, overlapSize, 0);
        foreach (var c in colliders)
        {
            if (c.gameObject.CompareTag("Obs"))
            {
                Destroy(c.gameObject);
            }
        }
    }

    // 시각화용 기즈모
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 center = transform.position + (Vector3)Vector2.up * verticalOffset;
        center.z = 0;
        Vector3 size = new Vector3(overlapSize.x, overlapSize.y, 0);
        Gizmos.DrawWireCube(center, size);
    }
}