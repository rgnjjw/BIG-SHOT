using DG.Tweening;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    private void Start()
    {
        transform.DOMoveX(15, 0.5f).SetEase(Ease.Linear).OnComplete(() => Destroy(gameObject));
    }
}
