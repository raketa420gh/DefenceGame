using UnityEngine;

[CreateAssetMenu(menuName = "Units/Turret", fileName = "Turret", order = 53)]

public class TurretData : ScriptableObject
{
    public string PrefabPath;
    public int Damage;
    public float AttackSpeed;
    //public HeroAbility Ability;
}