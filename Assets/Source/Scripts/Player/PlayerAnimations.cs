using UnityEngine;


[RequireComponent(typeof(Animator))]
public class PlayerAnimations : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void MoveLeft()
    {
        _animator.SetTrigger("OnMoveHorizontal");
        _spriteRenderer.flipX = true;
    }

    public void MoveRight()
    {
        _animator.SetTrigger("OnMoveHorizontal");
        _spriteRenderer.flipX = false;
    }

    public void Stop()
    {
        _animator.SetTrigger("OnStop");
        _spriteRenderer.flipX = false;
    }

    public void StartJeckLeft()
    {
        _animator.SetBool("IsDashing", true);
        _animator.SetTrigger("OnDash");
        _spriteRenderer.flipX = true;
    }
    public void StartJeckRight()
    {
        _animator.SetBool("IsDashing", true);
        _animator.SetTrigger("OnDash");
        _spriteRenderer.flipX = false;
    }

    public void StopJeck()
    {
        _animator.SetBool("IsDashing", false);
        _spriteRenderer.flipX = false;
    }
}
