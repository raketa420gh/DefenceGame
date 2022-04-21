using Zenject;

public class FinishAreaInstaller : MonoInstaller
{
    public FinishArea FinishArea;
    
    public override void InstallBindings()
    {
        BindFinishArea();
    }

    private void BindFinishArea()
    {
        Container
            .Bind<FinishArea>()
            .FromInstance(FinishArea)
            .AsSingle();
    }
}