using System;
using System.Collections;
using UnityEngine;

public class LevelSwitcher : MonoBehaviour
{
    [SerializeField] private float _delay;

    private WaitForSeconds _delayWaitForSeconds;

    public Action OnSwitched;

    private void Awake()
    {
        _delayWaitForSeconds = new WaitForSeconds(_delay);
    }

    public void Switch(Cell cell, bool isSwitch)
    {
        if (isSwitch == false)
            return;

        Switch();
    }

    public void Switch()
    {
        StartCoroutine(nameof(DelayCoroutine));
    }

    private IEnumerator DelayCoroutine()
    {
        yield return _delayWaitForSeconds;
        OnSwitched?.Invoke();
    }
}
