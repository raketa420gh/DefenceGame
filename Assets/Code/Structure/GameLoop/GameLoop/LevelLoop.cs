using System;
using UnityEngine;

public class LevelLoop
{
    public event Action OnLevelStarted;
    public event Action OnLevelWon;
    public event Action OnLevelLose;

    private SquadFormationUI _squadFormationUI;

    public LevelLoop(SquadFormationUI squadFormationUI)
    {
        _squadFormationUI = squadFormationUI;

        _squadFormationUI.OnPlayButtonPressed += StartLevel;
    }

    public void StartLevel()
    {
        //Debug.Log($"OnLevelStarted");
        OnLevelStarted?.Invoke();
    }

    public void Win()
    {
        //Debug.Log($"OnLevelWon");
        OnLevelWon?.Invoke();
    }

    public void Lose()
    {
        //Debug.Log($"OnLevelLosed");
        OnLevelLose?.Invoke();
    }
}