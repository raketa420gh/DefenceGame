using UnityEngine;
using Zenject;

public class SquadFormation : MonoBehaviour
{
    [SerializeField] private HeroData _testHeroData1;
    [SerializeField] private HeroData _testHeroData2;
    [SerializeField] private TurretData _testTurretData;
    [SerializeField] private SquadHeroSlot[] _heroSlots = new SquadHeroSlot[4];
    [SerializeField] private SquadTurretSlot _turretSlot = new SquadTurretSlot();
    private GameFactory _gameFactory;

    [Inject]
    public void Construct(GameFactory gameFactory)
    {
        _gameFactory = gameFactory;
    }

    public void SaveHeroesPreset()
    {
    }

    public void LoadSquadPreset()
    {
        SetHeroToSlot(_testHeroData1, 0);
        SetTurretToSlot(_testTurretData, _turretSlot);
    }

    public void SetHeroToSlot(HeroData heroData, int slotIndex)
    {
        var hero = _gameFactory.CreateHero(heroData, Vector3.zero);
        _heroSlots[slotIndex].SetHero(hero);
    }

    public void SetTurretToSlot(TurretData turretData, SquadTurretSlot turretSlot)
    {
        var turret = _gameFactory.CreateTurret(turretData, Vector3.zero);
        turretSlot.SetTurret(turret);
    }
}