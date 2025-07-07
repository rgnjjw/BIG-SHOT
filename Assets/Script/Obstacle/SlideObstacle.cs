using DG.Tweening;
using UnityEngine;

public class SlideObstacle : OrinSlideOB
{
    public Vector2 overlapSize = new Vector2(2, 10);  // ���� 10, ���� 2
    public float verticalOffset = -2f;                // �Ʒ��� ������
    private bool hasStartedAnimation = false;         // �ִϸ��̼� �ߺ� ���� ����

    protected override void Start()
    {
        // �ʱ� �ӵ��� 0���� ���� (�ִϸ��̼� �Ϸ� ������ �̵����� ����)
        _speed = 0f;
        base.Start();

        // ���� �� �� ���� �ִϸ��̼� ����
        StartSlideAnimation();
    }

    private void StartSlideAnimation()
    {
        if (hasStartedAnimation) return;
        hasStartedAnimation = true;

        // ������ �ִϸ��̼�
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

        // ��ֹ� ���� (�� �����Ӹ��� �����ص� ������)
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position + (Vector3)Vector2.up * verticalOffset, overlapSize, 0);
        foreach (var c in colliders)
        {
            if (c.gameObject.CompareTag("Obs"))
            {
                Destroy(c.gameObject);
            }
        }
    }

    // �ð�ȭ�� �����
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 center = transform.position + (Vector3)Vector2.up * verticalOffset;
        center.z = 0;
        Vector3 size = new Vector3(overlapSize.x, overlapSize.y, 0);
        Gizmos.DrawWireCube(center, size);
    }
}