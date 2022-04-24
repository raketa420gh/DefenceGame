using System;
using UnityEngine;

public class LevelLoop
{
    public event Action OnLevelStarted;
    public event Action OnLevelWon;
    public event Action OnLevelLosed;

    private EnemySpawner _enemySpawner;

    public LevelLoop(EnemySpawner enemySpawner) => _enemySpawner = enemySpawner;

    public void StartLevel()
    {
        _enemySpawner.StartSpawningEnemies(EnemyTier.Tier3, 1f);
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