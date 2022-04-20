public class LoadLevelState : GameLoopState
{
    public LoadLevelState(GameLoop gameLoop, StateMachine stateMachine) : base(gameLoop, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.ChangeState(gameLoop.StartLevelState);
    }
}