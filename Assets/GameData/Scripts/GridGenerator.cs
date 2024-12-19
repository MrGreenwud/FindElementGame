using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour, IRestartable
{
    [SerializeField] private GameObject _cellPrefab;
    [SerializeField] private Vector2 _center;

    private List<Cell> _cells = new List<Cell>();

    public List<Cell> GenerateGrid(GridData gridData)
    {
        int cellCount = gridData.Column * gridData.Row;
        _cells = new List<Cell>(cellCount);
        
        float widthGrid = (gridData.Column - 1) * (gridData.CellSize + gridData.ElementSpacing);
        float heightGrid = (gridData.Row - 1) * (gridData.CellSize + gridData.ElementSpacing);

        Vector3 center = _center - new Vector2(widthGrid / 2, heightGrid / 2);

        for (int i = 0; i < gridData.Row; i++)
        {
            for(int j = 0; j < gridData.Column; j++)
            {
                float x = center.x + j * (gridData.CellSize + gridData.ElementSpacing);
                float y = center.y + i * (gridData.CellSize + gridData.ElementSpacing);

                Vector3 position = new Vector3(x, y, 0);
                
                GameObject gameObject = Instantiate(_cellPrefab, position, Quaternion.identity);
                _cells.Add(gameObject.GetComponent<Cell>());
            }
        }

        return _cells;
    }

    public void RemoveCells()
    {
        foreach(Cell cell in _cells)
            Destroy(cell.gameObject);
    }

    public void Restart()
    {
        RemoveCells();
    }
}