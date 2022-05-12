using TMPro;
using UnityEngine;
using Zenject;

public class SquadFormater : MonoBehaviour
{
    [SerializeField] private SquadTurretSlot _turretSlot;
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
        _heroSlots[slotIndex].SetHero(hero, 0.55f);
    }

    public void SetTurretToSlot(TurretData turretData)
    {
        var turret = _gameFactory.CreateTurret(turretData, Vector3.zero);
        _turretSlot.SetTurret(turret, 0.1f);
    }
}