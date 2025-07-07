using DG.Tweening;
using UnityEngine;
public class UIMove : MonoBehaviour
{
    [SerializeField] float _movevalue = 5;
    [SerializeField] float _fast = 1.5f;
    [SerializeField] Ease _ease;
    private void Start()
    {
        transform.DOMoveY(_movevalue, _fast).SetEase(_ease).SetUpdate(true); ;
    }
}
