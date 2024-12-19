using DG.Tweening;
using UnityEngine;

public class RestartPanelView : MonoBehaviour, IRestartable
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private CanvasGroup _background;
    [SerializeField] private float _duration;

    public void Restart()
    {
        Hide();
    }

    public void Show()
    {
        _panel.SetActive(true);
        _background.DOFade(1, _duration);
    }

    public void Hide()
    {
        _panel.SetActive(false);
        _background.DOFade(0, _duration);
    }
}
