using UnityEngine;

[CreateAssetMenu(menuName = "Heroes/Hero", fileName = "Hero", order = 52)]

public class HeroData : ScriptableObject
{
    public int Damage;
    public float AttackSpeed;
    public HeroAbility Ability;
}