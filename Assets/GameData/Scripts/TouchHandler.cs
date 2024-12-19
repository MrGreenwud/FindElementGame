using System;
using UnityEngine;

public class TouchHandler : MonoBehaviour, IRestartable
{
    private bool _isEnable = true;

    public Action<Vector2> OnTouch;

    private void Update()
    {
        if (_isEnable == false)
            return;

        if(Input.GetMouseButtonDown(0))
            OnTouch?.Invoke(Input.mousePosition);

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
                OnTouch?.Invoke(touch.position);
        }
    }

    private void Enable()
    {
        _isEnable = true;
    }

    public void Disable()
    {
        _isEnable = false;
    }

    public void Restart()
    {
        Enable();
    }
}
