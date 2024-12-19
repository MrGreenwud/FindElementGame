using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private GridData[] _gridData;

    [SerializeField] private GridGenerator _gridGenerator;
    [SerializeField] private CardGenerator _cardGenerator;

    private int _currentGridLoadedIndex = -1;

    public Action<List<Cell>, CardData> LoadedLevel;

    public void Next()
    {
        _currentGridLoadedIndex++;

        if (_currentGridLoadedIndex > _gridData.Length - 1)
            return;

        _gridGenerator.RemoveCells();
        List<Cell> cells = _gridGenerator.GenerateGrid(_gridData[_currentGridLoadedIndex]);
        _cardGenerator.GenerateCards(cells);

        LoadedLevel?.Invoke(cells, _cardGenerator.Answer);
    }
}
