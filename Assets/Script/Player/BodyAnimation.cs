using UnityEngine;

public class BodyAnimation : MonoBehaviour
{
    private static readonly int runHash = Animator.StringToHash("Run");
    private static readonly int standHash = Animator.StringToHash("Stand");
    private static readonly int slideHash = Animator.StringToHash("Slide");
    private static readonly int jumpHash = Animator.StringToHash("Jump");
    private int _currentHash = 0;
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        ChangeState(runHash);
    }
    private void ChangeState(int animationHash)
    {
        if (_currentHash != 0) _animator.SetBool(_currentHash, false);
        _animator.SetBool(animationHash, true);
        _currentHash = animationHash;
    }
    public void AnimationEndTrigger()
    {
        ChangeState(runHash);
    }
    public void JumpTrigger()
    {
        ChangeState(jumpHash);
    }

    public void SlideTrigger()
    {
        ChangeState(slideHash);
    }
    public void StandTrigger()
    {
        ChangeState(standHash);
    }
    public void RunTrigger()
    {
        ChangeState(runHash);
    }

}
