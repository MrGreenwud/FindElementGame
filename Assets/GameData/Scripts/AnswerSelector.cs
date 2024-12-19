using System;
using UnityEngine;

public class AnswerSelector : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    public Action<Cell> OnSelect;

    public void Select(Vector2 touchPosition)
    {
        Ray ray = _camera.ScreenPointToRay(touchPosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if(hit.collider != null && hit.collider.TryGetComponent(out Cell cell))
            OnSelect?.Invoke(cell);
    }
}