using UnityEngine;
using Zenject;

public class SquadFormater : MonoBehaviour
{
    [SerializeField] private SquadHeroSlot[] _heroSlots = new SquadHeroSlot[4];
    private GameFactory _gameFactory;

    [Inject]
    public void Construct(GameFactory gameFactory)
    {
        _gameFactory = gameFactory;
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