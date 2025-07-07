using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class FandJBlock : MonoBehaviour
{
    [SerializeField] GameObject _f;
    [SerializeField] GameObject _j;
    [SerializeField] private BoxCollider2D _colliderF;
    [SerializeField] private BoxCollider2D _colliderJ;
    float _timerF = 0;
    float _timerJ = 0;

    private Sequence _sqe;
    //private TMP_Text text;
    //int firstNum = 0;
    //int secNum = 0;
    //int thirdNum = 0;
    private void Awake()
    {
        _sqe = DOTween.Sequence();
        //text.text = "asd";
        //if (firstNum > 9)
        //{
        //    firstNum = 0;
        //    secNum += 1;
        //}
        //if (secNum > 9)
        //{
        //    thirdNum += 1;
        //}
        //text.text = $"{thirdNum}{secNum}{firstNum}";
        _colliderF.enabled = false;
        _colliderJ.enabled = false;

    }
    private void Update()
    {
        if (Keyboard.current.fKey.isPressed)
        {
            _timerF += Time.deltaTime;
            if (_timerF >= 0.5f)
            {
                _colliderF.enabled = false;
            }
        }
        if (Keyboard.current.jKey.isPressed)
        {
            _timerJ += Time.deltaTime;
            if (_timerJ >= 0.5f)
            {
                _colliderJ.enabled = false;
            }
        }
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            _colliderF.enabled = true;
            _timerF = 0;
            if (_f.TryGetComponent<SpriteRenderer>(out SpriteRenderer color))
            {
                color.color = Color.red;
            }

        }
        if (Keyboard.current.jKey.wasPressedThisFrame)
        {
            _colliderJ.enabled = true;
            _timerJ = 0;
            if (_j.TryGetComponent<SpriteRenderer>(out SpriteRenderer color))
            {
                color.color = Color.red;
            }
        }
        if (Keyboard.current.fKey.wasReleasedThisFrame)
        {
            if (_f.TryGetComponent<SpriteRenderer>(out SpriteRenderer color))
            {
                color.color = Color.white;
                _colliderF.enabled = false;
            }
        }
        if (Keyboard.current.jKey.wasReleasedThisFrame)
        {
            if (_j.TryGetComponent<SpriteRenderer>(out SpriteRenderer color))
            {
                color.color = Color.white;
                _colliderJ.enabled = false;
            }
        }

    }
}
