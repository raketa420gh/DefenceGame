using UnityEngine;

[CreateAssetMenu(menuName = "Units/Hero", fileName = "Hero", order = 52)]

public class HeroData : ScriptableObject, IInventoryItemInfo
{
    [SerializeField] private string _id;
    [SerializeField] private string _title;
    [SerializeField] private string _description;
    [SerializeField] private int _maxItemsInInventorySlot = 1;
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _prefabPath;
    [SerializeField] private int _damage;
    [SerializeField] private float _attackSpeed;
    public string Id => _id;
    public string Title => _title;
    public string Description => _description;
    public int MaxItemsInInventorySlot => _maxItemsInInventorySlot;
    public Sprite SpriteIcon => _icon;
    public string PrefabPath => _prefabPath;
    public int Damage => _damage;
    public float AttackSpeed => _attackSpeed;
    //public HeroAbility Ability;
}