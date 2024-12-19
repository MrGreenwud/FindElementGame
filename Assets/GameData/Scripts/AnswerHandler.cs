using System;
using UnityEngine;

public class AnswerHandler : MonoBehaviour
{
    [SerializeField] CardGenerator _cardGenerator;

    public Action<Cell, bool> OnProcessed;

    public void Process(Cell cell)
    {
        bool result = cell.CardData == _cardGenerator.Answer;
        OnProcessed?.Invoke(cell, result);
    }
}