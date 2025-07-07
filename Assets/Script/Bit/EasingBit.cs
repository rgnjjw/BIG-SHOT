using DG.Tweening;
using UnityEngine;
public class EasingBit : MonoBehaviour
{
    [SerializeField] Ease easeType = Ease.InOutExpo;
    private void Start()
    {
        transform.DOMoveX(10, 3).SetEase(easeType).OnComplete(() => Destroy(gameObject));
        if (transform.position.x >= 15)
        {
            Destroy(gameObject);
        }
    }

}
