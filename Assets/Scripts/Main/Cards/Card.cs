using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{
    private const int Y_ANCHOR = -15;
    [SerializeField] private TextMeshProUGUI cardName;

    private SpritesManager _spritesManager;
    private Animator _animator;

    private bool _isEatable;

    private void Awake()
    {
        _spritesManager = GetComponentInParent<SpritesManager>();
        _animator = GetComponent<Animator>();
    }

    public void MoveByMouse(float pointerXPos)
    {
        transform.position = new Vector2(pointerXPos, transform.right.y * pointerXPos);
        transform.up = (Vector2)transform.position - new Vector2(0, Y_ANCHOR);
    }

    public void ReturnCardPosition(Vector3 pos)
    {
        transform.position = pos;
        transform.up = Vector2.up;
    }

    public void DestroyCard()
    {
        transform.SetParent(transform.parent.parent);
        _spritesManager.UnloadCardSprites();
        _animator.SetTrigger("Destroy");
    }

    public bool GetEatable()
    {
        return _isEatable;
    }

    public CardImage ChildSprite()
    {
        return GetComponentInChildren<CardImage>();
    }

    public void SetCardName(string name) => cardName.text = name;

    public void SetEatable(bool isEatable) => _isEatable = isEatable;

    public void DestroyAfterEndOfAnimation() => Destroy(this.gameObject);

}
