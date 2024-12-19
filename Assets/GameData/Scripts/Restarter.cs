using System.Collections.Generic;
using UnityEngine;

public class Restarter : MonoBehaviour
{
    private List<IRestartable> _restartables = new List<IRestartable>();

    private void Awake()
    {
        MonoBehaviour[] components = FindObjectsOfType<MonoBehaviour>();

        foreach (var component in components)
        {
            if(component is IRestartable restartable)
                _restartables.Add(restartable);
        }
    }

    public void Restart()
    {
        foreach (var restartable in _restartables)
            restartable.Restart();
    }
}