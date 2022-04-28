using Zenject;

public class SquadFormationInstaller : MonoInstaller
{
    public SquadFormation SquadFormation;
        
    public override void InstallBindings()
    {
        BindSquadFormation();
    }

    private void BindSquadFormation()
    {
        Container
            .Bind<SquadFormation>()
            .FromInstance(SquadFormation);
    }
}