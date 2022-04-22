using Zenject;

public class TurretInstaller : MonoInstaller
{
    public Turret Turret;

    public override void InstallBindings()
    {
        BindTurret();
    }

    private void BindTurret()
    {
        Container
            .Bind<Turret>()
            .FromInstance(Turret)
            .AsSingle();
    }
}