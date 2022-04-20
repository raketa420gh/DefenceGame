using System;
using UnityEngine;

public class LevelLoop
{
    public event Action OnLevelStarted;
    public event Action OnLevelWon;
    public event Action OnLevelLosed;

    public void StartLevel()
    {
        Debug.Log($"OnLevelStarted");
        OnLevelStarted?.Invoke();
    }

    public void Win()
    {
        Debug.Log($"OnLevelWon");
        OnLevelWon?.Invoke();
    }

    public void Lose()
    {
        Debug.Log($"OnLevelLosed");
        OnLevelLosed?.Invoke();
    }
}