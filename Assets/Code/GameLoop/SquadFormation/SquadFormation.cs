using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SquadFormation : MonoBehaviour
{
    [SerializeField] private HeroData _testHeroData;
    [SerializeField] private List<SquadSlot> _slots = new List<SquadSlot>();
    private GameFactory _gameFactory;

    [Inject]
    public void Construct(GameFactory gameFactory)
    {
        _gameFactory = gameFactory;
    }

    public void LoadHeroes()
    {
        var testHero = _gameFactory.CreateHero(_testHeroData, Vector3.zero);
        SetHeroToSlot(testHero, _slots[0]);
    }

    public void SetHeroToSlot(Hero hero, SquadSlot slot)
    {
        slot.SetHero(hero);
    }
}