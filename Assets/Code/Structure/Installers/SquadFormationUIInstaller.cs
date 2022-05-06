using Zenject;

public class SquadFormationUIInstaller : MonoInstaller
{
    public SquadFormationUI SquadFormationUI; 
        
    public override void InstallBindings()
    {
        BindSquadFormationUI();
    }

    private void BindSquadFormationUI()
    {
        Container
            .Bind<SquadFormationUI>()
            .FromInstance(SquadFormationUI)
            .AsSingle();
    }
}