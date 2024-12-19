using DG.Tweening;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class FindTextView : MonoBehaviour, IRestartable
{
    [SerializeField] private CanvasGroup _grup;
    [SerializeField] private Image _image;
    [SerializeField] private bool _onlyFirstTimeAnimation = true;

    private RectTransform _rectTransform;
    private bool _isAnimated;

    private void Awake()
    {
        _rectTransform = _image.gameObject.GetComponent<RectTransform>();
    }

    public void Show(List<Cell> cells, CardData cardData)
    {
        _image.sprite = cardData.Sprite;

        float pixelsPerUnit = cardData.Sprite.pixelsPerUnit;

        float width = cardData.Sprite.bounds.size.x * pixelsPerUnit;
        float height = cardData.Sprite.bounds.size.y * pixelsPerUnit;

        _rectTransform.sizeDelta = new Vector2(width, height);

        if (_onlyFirstTimeAnimation && _isAnimated)
            return;

        _grup.DOFade(1, 1);

        _isAnimated = true;
    }

    public void Restart()
    {
        _isAnimated = false;
        _grup.alpha = 0;
    }
}