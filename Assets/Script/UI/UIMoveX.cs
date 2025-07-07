using DG.Tweening;
using UnityEngine;
public class UIMoveX : MonoBehaviour
{
    [SerializeField] float _movevalue = 5;
    [SerializeField] float _fast = 1.5f;
    [SerializeField] Ease _ease;
    private void Start()
    {
        transform.DOMoveX(_movevalue, _fast).SetEase(_ease).SetUpdate(true); ;
    }
}
