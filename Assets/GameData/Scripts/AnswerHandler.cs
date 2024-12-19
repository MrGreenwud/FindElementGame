using System;
using UnityEngine;

public class AnswerHandler : MonoBehaviour
{
    [SerializeField] CardGenerator _cardGenerator;

    public Action<bool> OnProcessed;

    public void Process(Cell cell)
    {
        if (cell.CardData == _cardGenerator.Answer)
            OnProcessed?.Invoke(true);

        OnProcessed?.Invoke(false);
    }
}