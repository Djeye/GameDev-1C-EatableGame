using UnityEngine;

public class MagicCircle : Effect
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        EndAnimation();
    }

    override public void StartAnimation()
    {
        _spriteRenderer.enabled = true;
        _animator.SetTrigger("Animate");
    }

    override public void EndAnimation()
    {
        _spriteRenderer.enabled = false;
    }
}
