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
        _animator.SetBool("MoveHorizontal", true);
        _animator.SetBool("MoveUp", false);
        _animator.SetBool("MoveDown", false);

        _spriteRenderer.flipX = true;
    }

    public void MoveRight()
    {
        _animator.SetBool("MoveHorizontal", true);
        _animator.SetBool("MoveUp", false);
        _animator.SetBool("MoveDown", false);
        
        _spriteRenderer.flipX = false;
    }

    public void MoveUp()
    {
        _animator.SetBool("MoveHorizontal", false);
        _animator.SetBool("MoveUp", true);
        _animator.SetBool("MoveDown", false);
    }

    public void MoveDown()
    {
        _animator.SetBool("MoveHorizontal", false);
        _animator.SetBool("MoveUp", false);
        _animator.SetBool("MoveDown", true);
    }

    public void Stop()
    {
        _animator.SetTrigger("OnStop");
        _animator.SetBool("MoveHorizontal", false);
        _animator.SetBool("MoveUp", false);
        _animator.SetBool("MoveDown", false);
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
