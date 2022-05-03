using UnityEngine;

[CreateAssetMenu(menuName = "Units/Hero", fileName = "Hero", order = 52)]

public class HeroData : ScriptableObject
{
    public string PrefabPath;
    public int Damage;
    public float AttackSpeed;
    public HeroAbility Ability;
}