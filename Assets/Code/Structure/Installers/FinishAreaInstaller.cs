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
            .BindInstance(FinishArea)
            .AsSingle();
    }
}