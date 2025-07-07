using DG.Tweening;
using UnityEngine;

public class Gear : MonoBehaviour
{
    [SerializeField] int _spin = 359;
    [SerializeField] float _spinSpeed = 0.01f;
    private void Start()
    {
        transform.DORotate(new Vector3(0, 0, _spin), _spinSpeed, RotateMode.Fast).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
    }
}
