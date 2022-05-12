using System.Collections.Generic;
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

    public Hero SetHeroToSlot(HeroData heroData, int slotIndex)
    {
        var hero = _gameFactory.CreateHero(heroData, Vector3.zero);
        _heroSlots[slotIndex].SetHero(hero, 0.55f);
        return hero;
    }

    public Turret SetTurretToSlot(TurretData turretData)
    {
        var turret = _gameFactory.CreateTurret(turretData, Vector3.zero);
        _turretSlot.SetTurret(turret, 0.1f);
        return turret;
    }
}