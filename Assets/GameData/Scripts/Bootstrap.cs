using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private LevelLoader _loader;
    [SerializeField] private TouchHandler _touchHandler;
    [SerializeField] private AnswerSelector _answerSelector;
    [SerializeField] private AnswerHandler _answerHandler;

    [SerializeField] private FindTextView _findTextView;
    [SerializeField] private CellAnimator _cellView;

    public void Start()
    {
        _touchHandler.OnTouch += _answerSelector.Select;
        _answerSelector.OnSelect += _answerHandler.Process;
        
        _answerHandler.OnProcessed += (x) => 
        { 
            if(x)
                _loader.Next();
        };

        _loader.LoadedLevel += _findTextView.Show;
        _loader.LoadedLevel += _cellView.Show;

        _loader.Next();
    }
}
