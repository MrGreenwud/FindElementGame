using UnityEngine;

[CreateAssetMenu(fileName = "Grid Data", menuName = "Game/Data/Grid")]
public class GridData : ScriptableObject
{
    [SerializeField] private int _row;
    [SerializeField] private int _column;

    [SerializeField] private float _cellSize;
    [SerializeField] private float _elementSpacing;

    public int Row => _row;
    public int Column => _column;

    public float CellSize => _cellSize;
    public float ElementSpacing => _elementSpacing;

    public void OnValidate()
    {
        _row = _row < 0 ? 1 : _row;
        _column = _column < 0 ? 1 : _column;
    }
}