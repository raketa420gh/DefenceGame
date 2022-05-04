using UnityEngine;

[CreateAssetMenu(menuName = "Units/Enemy", fileName = "Enemy", order = 51)]
public class EnemyData : ScriptableObject
{
    public string Name;
    public string PrefabPath;
    public EnemyTier Tier;
    public int Health;
    public float MoveSpeed;
}