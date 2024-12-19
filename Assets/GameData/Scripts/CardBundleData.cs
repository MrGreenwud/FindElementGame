using UnityEngine;

[CreateAssetMenu(fileName = "CardBundleData", menuName = "Game/Data/CardBundle")]
public class CardBundleData : ScriptableObject
{
    [SerializeField] private CardData[] _cardData;

    public int Count => _cardData.Length;

    public CardData GetCardData(int index) => _cardData[index];
}