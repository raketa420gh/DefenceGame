using System;
using UnityEngine;

public class LevelLoop
{
    public event Action OnLevelStarted;
    public event Action OnLevelWon;
    public event Action OnLevelLose;

    private EnemyDetector _enemyDetector;

    public LevelLoop(EnemyDetector enemyDetector)
    {
        _enemyDetector = enemyDetector;
    }

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
        OnLevelLose?.Invoke();
    }
}