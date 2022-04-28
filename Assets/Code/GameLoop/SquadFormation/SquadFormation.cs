using UnityEngine;
using Zenject;

public class SquadFormation : MonoBehaviour
{
    private GameFactory _gameFactory;
    private SquadSlot _slot1;
    private SquadSlot _slot2;
    private SquadSlot _slot3;
    private SquadSlot _slot4;

    [Inject]
    public void Construct(GameFactory gameFactory)
    {
        _gameFactory = gameFactory;
    }

    public void SetHeroToSlot(Hero hero, SquadSlot slot)
    {
        slot.SetHero(hero);
    }
}