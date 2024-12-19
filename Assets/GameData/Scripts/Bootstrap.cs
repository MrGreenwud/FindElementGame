using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private LevelLoader _levelLoader;
    [SerializeField] private TouchHandler _touchHandler;
    [SerializeField] private AnswerSelector _answerSelector;
    [SerializeField] private AnswerHandler _answerHandler;
    [SerializeField] private LevelSwitcher _levelSwitcher;

    [Space(10)]

    [SerializeField] private FindTextView _findTextView;
    [SerializeField] private CellAnimator _cellView;
    [SerializeField] private ElementAnimator _elementAnimator;
    [SerializeField] private WinView _winView;
    [SerializeField] private RestartPanelView _restartPanelView;

    public void Start()
    {
        _touchHandler.OnTouch += _answerSelector.Select;
        _answerSelector.OnSelect += _answerHandler.Process;
        _answerHandler.OnProcessed += _levelSwitcher.Switch;
        _levelSwitcher.OnSwitched += _levelLoader.Next;
        _answerHandler.OnProcessed += _winView.Show;
        _levelSwitcher.OnSwitched += _winView.Hide;
        _levelLoader.OnLevelsEnded += _restartPanelView.Show;
        _levelLoader.OnLevelsEnded += _touchHandler.Disable;

        _levelLoader.OnLoadedLevel += _findTextView.Show;
        _levelLoader.OnLoadedLevel += _cellView.Show;
        _answerHandler.OnProcessed += _elementAnimator.Move;

        _levelLoader.Next();
    }
}
