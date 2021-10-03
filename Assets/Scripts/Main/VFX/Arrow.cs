using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Arrow : Effect
{
    private Animator _animator;
    private Image _image;
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _image = GetComponent<Image>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
        EndAnimation();
    }

    override public void EndAnimation()
    {
        _image.enabled = false;
        _text.enabled = false;
    }

    override public void StartAnimation()
    {
        _image.enabled = true;
        _text.enabled = true;
        _animator.SetTrigger("Animate");
    }
}
