using System.Collections.Generic;

using UnityEngine;

public class CellAnimator : MonoBehaviour
{
    [SerializeField] private bool _onlyFirstTime = true;

    private bool _isAnimated;

    public void Show(List<Cell> cells, CardData cardData)
    {
        if (_onlyFirstTime || _isAnimated)
            return;

        //foreach (Cell cell in cells)
        //    cell.transform.DOShakeScale(2, 2, 100);

        _isAnimated = true;
    }
}
