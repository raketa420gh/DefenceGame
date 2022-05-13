using UnityEngine;

public class SquadHeroSlot : MonoBehaviour
{
    private Hero _currentHero;
    private bool isEmpty = true;

    public void SetHero(Hero hero, float yOffset)
    {
        _currentHero = hero;
        isEmpty = false;

        hero.transform.position =
            new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z);
        hero.transform.parent = transform;
    }
}