using UnityEngine;

public class GameLoopState : BaseState
{
    protected GameLoop gameLoop;
    protected StateMachine stateMachine;

    protected GameLoopState(GameLoop gameLoop, StateMachine stateMachine)
    {
        this.gameLoop = gameLoop;
        this.stateMachine = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log($"Start {stateMachine.CurrentState} state");
    }
}