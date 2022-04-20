public class StartLevelState : GameLoopState
{
    private LevelLoop _levelLoop;
    
    public StartLevelState(GameLoop gameLoop, StateMachine stateMachine) : base(gameLoop, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        _levelLoop = new LevelLoop();
        gameLoop.SetCurrentLevelLoop(_levelLoop);
        _levelLoop.StartLevel();
    }
}