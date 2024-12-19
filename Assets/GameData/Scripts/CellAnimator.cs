using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class CellAnimator : MonoBehaviour, IRestartable
{

    [SerializeField] private float duration = 2f;
    [SerializeField] private bool _onlyFirstTime = true;

    private Vector3 _initialScale = new Vector3(0.01f, 0.01f, 0.01f);

    private bool _isAnimated;

    public void Restart()
    {
        _isAnimated = false;
    }

    public void Show(List<Cell> cells, CardData cardData)
    {
        if (_onlyFirstTime && _isAnimated)
            return;

        foreach (Cell cell in cells)
        {
            cell.transform.localScale = _initialScale;
            cell.transform.DOScale(2, duration).SetEase(Ease.OutBack);
        }

        _isAnimated = true;
    }
}
