using UnityEngine;

public class HeroAbility : MonoBehaviour, IHeroAbility
{
    public int Cost { get; }
    
    public void Activate()
    {
        Debug.Log($"Ability activated");
    }
}