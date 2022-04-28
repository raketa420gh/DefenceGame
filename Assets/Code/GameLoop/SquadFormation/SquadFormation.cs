using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SquadFormation : MonoBehaviour
{
    [SerializeField] private List<SquadSlot> _slots = new List<SquadSlot>();
    private GameFactory _gameFactory;

    [Inject]
    public void Construct(GameFactory gameFactory)
    {
        _gameFactory = gameFactory;
    }

    public void SetupHeroes()
    {
    }

    public void SetHeroToSlot(Hero hero, SquadSlot slot)
    {
        slot.SetHero(hero);
    }
}