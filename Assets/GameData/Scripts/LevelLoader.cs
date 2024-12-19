using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour, IRestartable
{
    [SerializeField] private GridData[] _gridData;

    [SerializeField] private GridGenerator _gridGenerator;
    [SerializeField] private CardGenerator _cardGenerator;

    private int _currentGridLoadedIndex = -1;

    public Action<List<Cell>, CardData> OnLoadedLevel;
    public Action OnLevelsEnded;

    public void Next()
    {
        _currentGridLoadedIndex++;

        if (_currentGridLoadedIndex > _gridData.Length - 1)
        {
            OnLevelsEnded?.Invoke();
            return;
        }

        _gridGenerator.RemoveCells();
        List<Cell> cells = _gridGenerator.GenerateGrid(_gridData[_currentGridLoadedIndex]);
        _cardGenerator.GenerateCards(cells);

        OnLoadedLevel?.Invoke(cells, _cardGenerator.Answer);
    }

    public void Restart()
    {
        _currentGridLoadedIndex = -1;
    }
}
