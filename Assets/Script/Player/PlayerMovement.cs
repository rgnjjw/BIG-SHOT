using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector3 _moveDir;
    private bool _isGround;
    private bool _isCanSlid = true;
    private bool _isCanJump = true;
    [SerializeField] private int _jumpPower = 2;
    [SerializeField] private int _jumpPower2 = 1;
    [SerializeField] private float _sildSpeed = 0.5f;
    private int _jumpCount;
    private BodyAnimation _bodyAnimation;
    Animator _jumpAni;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _jumpAni = GetComponentInChildren<Animator>();
        _bodyAnimation = GetComponentInChildren<BodyAnimation>();
    }

    private void Start()
    {
        _isGround = true;
        _jumpCount = 0;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGround = true;
            _jumpCount = 0;
            _jumpAni.enabled = true;
            _isCanSlid = true;
            _bodyAnimation.RunTrigger();

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGround = true;
            _jumpCount = 0;
            _jumpAni.enabled = true;
            _isCanSlid = true;
            _bodyAnimation.RunTrigger();

        }
    }
    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Jump();
        }

        if (Keyboard.current.shiftKey.isPressed)
        {
            Slid1();
        }
        if (Keyboard.current.shiftKey.wasReleasedThisFrame)
        {
            Slid2();
        }
    }

    private void Jump()
    {
        _bodyAnimation.JumpTrigger();
        _isCanSlid = false;

        if (_isGround == true && _jumpCount == 0 && _isCanJump == true)
        {
            _rb.linearVelocityY = 0;
            _rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
            _jumpCount++;
            _isGround = false;
        }
        else if (_isGround == false && _jumpCount == 1 && _isCanJump == true)
        {
            _rb.linearVelocityY = 0;
            _rb.AddForce(Vector2.up * _jumpPower2, ForceMode2D.Impulse); _jumpCount = 0;
        }
    }
    private void Slid1()
    {
        _isCanJump = false;
        _bodyAnimation.SlideTrigger();
        CapsuleCollider2D collider = GetComponentInChildren<CapsuleCollider2D>();
        collider.size = new Vector2(2.3f, 1.3f);
        CapsuleCollider2D collider2 = GetComponent<CapsuleCollider2D>();
        collider.offset = new Vector2(0.46f, -1.34f);
    }
    private void Slid2()
    {
        _bodyAnimation.StandTrigger();
        _isCanJump = true;
        CapsuleCollider2D collider = GetComponentInChildren<CapsuleCollider2D>();
        collider.size = new Vector2(1.3f, 2.3f);
        CapsuleCollider2D collider2 = GetComponent<CapsuleCollider2D>();
        collider.offset = new Vector2(0.15f, -0.43f);
    }
}
