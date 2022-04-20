using System;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    public StateMachine GameLoopStateMachine;
    public LoadLevelState LoadLevelState;
    public StartLevelState StartLevelState;
    public EndLevelState EndLevelState;

    private LevelLoop _currentLevelLoop;

    private void Start()
    {
        InitializeStateMachine();
    }

    public void SetCurrentLevelLoop(LevelLoop levelLoop)
    {
        _currentLevelLoop = levelLoop;
    }

    private void InitializeStateMachine()
    {
        GameLoopStateMachine = new StateMachine();

        LoadLevelState = new LoadLevelState(this, GameLoopStateMachine);
        StartLevelState = new StartLevelState(this, GameLoopStateMachine);
        EndLevelState = new EndLevelState(this, GameLoopStateMachine);

        GameLoopStateMachine.ChangeState(LoadLevelState);
    }
}