using System;
using UnityEngine;

public class TouchHandler : MonoBehaviour
{
    public Action<Vector2> OnTouch;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
            OnTouch?.Invoke(Input.mousePosition);

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
                OnTouch?.Invoke(touch.position);
        }
    }
}
