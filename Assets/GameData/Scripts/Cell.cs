using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _element;

    public CardData CardData { get; private set; }

    public GameObject Element => _element.gameObject;

    public void Construct(CardData cardData)
    {
        CardData = cardData;
        _element.sprite = CardData.Sprite;
    }
}
