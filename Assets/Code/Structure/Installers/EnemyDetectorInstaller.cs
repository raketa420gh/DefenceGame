using Zenject;

public class EnemyDetectorInstaller : MonoInstaller
{
    public EnemyDetector EnemyDetector;

    public override void InstallBindings()
    {
        BindEnemyDetector();
    }

    private void BindEnemyDetector()
    {
        Container
            .Bind<EnemyDetector>()
            .FromInstance(EnemyDetector)
            .AsSingle();
    }
}