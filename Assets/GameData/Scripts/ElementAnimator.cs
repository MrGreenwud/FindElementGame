using DG.Tweening;
using UnityEngine;

public class ElementAnimator : MonoBehaviour
{
    [SerializeField] private float _maxOffset;
    public float moveDuration = 1f;

    Tween _tween;

    public void Move(Cell cell, bool isValid)
    {
        if (isValid)
            return;

        Vector3 originPosition = cell.Element.transform.position;

        _tween = cell.Element.transform
            .DOShakePosition(moveDuration, new Vector3(_maxOffset, 0, 0))
            .SetEase(Ease.InBounce).OnComplete(() => 
            { cell.Element.transform.DOMove(originPosition, 1); });
    }
}