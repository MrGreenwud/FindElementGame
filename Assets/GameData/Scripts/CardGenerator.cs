using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using Random = UnityEngine.Random;

public class CardGenerator : MonoBehaviour
{
    [SerializeField] private CardBundleData[] _cardBundleData;

    private List<CardData> _answersHistory = new List<CardData>();

    public CardData Answer => _answersHistory.Last();

    public void GenerateCards(List<Cell> cells)
    {
        CardBundleData cardBundleData = GetRandomCardBundle();

        CardData answer = GetRandomCard(cardBundleData, (x) => 
        { 
            return _answersHistory.Contains(x) == false;
        });

        _answersHistory.Add(answer);

        foreach (Cell cell in cells)
        {
            CardData cardData = GetRandomCard(cardBundleData, (x) =>
            {
                return answer != x;
            });

            cell.Construct(cardData);
        }

        int answerCellIndex = Random.Range(0, cells.Count);
        cells[answerCellIndex].Construct(answer);
    }

    private CardData GetRandomCard(Func<CardData, bool> onValid)
    {
        CardBundleData cardBundleData = GetRandomCardBundle();
        return GetRandomCard(cardBundleData, onValid);
    }

    private CardData GetRandomCard(CardBundleData cardBundleData, Func<CardData, bool> onValid)
    {
        int maxAttempts = 100;

        for (int i = 0; i < maxAttempts; i++)
        {
            CardData result = GetRandomCard(cardBundleData);

            if (onValid.Invoke(result))
                return result;
        }

        throw new InvalidOperationException($"{maxAttempts} attempts made! Failed to " +
            $"get a card that satisfies the condition in {nameof(onValid)}");
    }

    private CardData GetRandomCard(int bundleDataIndex)
    {
        return GetRandomCard(_cardBundleData[bundleDataIndex]);
    }

    private CardData GetRandomCard(CardBundleData cardBundleData)
    {
        int cardDataIndex = Random.Range(0, cardBundleData.Count);
        return cardBundleData.GetCardData(cardDataIndex);
    }

    private CardData GetRandomCard()
    {
        CardBundleData cardBundleData = GetRandomCardBundle();
        return GetRandomCard(cardBundleData);
    }

    private CardBundleData GetRandomCardBundle()
    {
        int bundleIndex = Random.Range(0, _cardBundleData.Length);
        return _cardBundleData[bundleIndex];
    }
}