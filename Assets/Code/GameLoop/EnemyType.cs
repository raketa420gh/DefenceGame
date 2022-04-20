using UnityEngine;

[CreateAssetMenu(menuName = "Enemies/Enemy", fileName = "Enemy", order = 51)]
public class EnemyType : ScriptableObject
{
    public string Name;
    public string PrefabPath;
    public int Health;
    public float MoveSpeed;
}