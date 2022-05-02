using UnityEngine;

[CreateAssetMenu(menuName = "Turrets/Turret", fileName = "Turret", order = 53)]

public class TurretData : ScriptableObject
{
    public string PrefabPath;
    public int Damage;
    public float AttackSpeed;
    //public HeroAbility Ability;
}