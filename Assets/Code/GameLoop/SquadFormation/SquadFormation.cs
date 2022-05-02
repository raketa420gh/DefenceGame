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
        //_slots[0].SetHero();
        //_slots[1].SetHero();
        //_slots[2].SetHero();
        //_slots[3].SetHero();
    }

    public void LoadSquadPreset()
    {
        var hero1 = _gameFactory.CreateHero(_testHeroData1, Vector3.zero);
        var hero2 = _gameFactory.CreateHero(_testHeroData2, Vector3.zero);
        var turret = _gameFactory.CreateTurret(_testTurretData, Vector3.zero);
        SetHeroToSlot(hero1, _heroSlots[0]);
        SetHeroToSlot(hero2, _heroSlots[1]);
        SetTurretToSlot(turret, _turretSlot);
    }

    private void SetHeroToSlot(Hero hero, SquadHeroSlot heroSlot)
    {
        heroSlot.SetHero(hero);
    }

    private void SetTurretToSlot(Turret turret, SquadTurretSlot turretSlot)
    {
        turretSlot.SetTurret(turret);
    }
}