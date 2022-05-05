using Zenject;

public class SquadFormationInstaller : MonoInstaller
{
    public SquadFormater squadFormater;
        
    public override void InstallBindings()
    {
        BindSquadFormation();
    }

    private void BindSquadFormation()
    {
        Container
            .Bind<SquadFormater>()
            .FromInstance(squadFormater);
    }
}