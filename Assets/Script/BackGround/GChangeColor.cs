using UnityEngine;
using UnityEngine.InputSystem;

public class GChangeColor : MonoBehaviour
{
    [SerializeField] GameObject _f;
    [SerializeField] GameObject _j;
    SpriteRenderer _color;
    Color _originalColor;
    Color HexToColor(string hex)
    {
        Color color;
        if (ColorUtility.TryParseHtmlString(hex, out color))
        {
            return color;
        }
        return Color.white;
    }
    private void Awake()
    {
        _color = GetComponent<SpriteRenderer>();
        _originalColor = HexToColor("#1E1E1E");


    }
    private void Start()
    {

    }
    private void Update()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            if (_f.TryGetComponent<SpriteRenderer>(out SpriteRenderer f))
            {
                f.color = Color.white;
            }
        }

        else if (Keyboard.current.fKey.wasReleasedThisFrame)
        {
            if (_f.TryGetComponent<SpriteRenderer>(out SpriteRenderer f))
            {
                f.color = _originalColor;
            }
        }


        if (Keyboard.current.jKey.wasPressedThisFrame)
        {
            if (_j.TryGetComponent<SpriteRenderer>(out SpriteRenderer j))
            {
                j.color = Color.white;
            }
        }

        else if (Keyboard.current.jKey.wasReleasedThisFrame)
        {
            if (_j.TryGetComponent<SpriteRenderer>(out SpriteRenderer j))
            {
                j.color = _originalColor;
            }
        }


    }
}
