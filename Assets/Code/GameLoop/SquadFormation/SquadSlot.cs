using UnityEngine;

public class SquadSlot : MonoBehaviour
{
    private Hero _currentHero;
    private bool isEmpty = true;

    public void SetHero(Hero hero)
    {
        _currentHero = hero;
        isEmpty = false;

        hero.transform.position = transform.position;
    }
}
