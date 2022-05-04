using UnityEngine;

public class UISquadInventoryController : MonoBehaviour
{
    [SerializeField] private UIInventorySlot[] _uiHeroSlots;
    [SerializeField] private UIInventorySlot[] _uiSquadHeroSlots;
    [SerializeField] private HeroData _hero1Data;
    [SerializeField] private HeroData _hero2Data;

    private UISquadInventory _squadInventory;
    private SquadFormation _squadFormation;

    public InventoryWithSlots Inventory => _squadInventory.Inventory;

    private void Start()
    {
        _squadInventory = new UISquadInventory(_uiHeroSlots, _uiHeroSlots.Length);
        _squadInventory.OnAddedHeroToSquadSlot += OnAddedHeroToSquadSlot;
        _squadInventory.FillHeroSlot(_hero1Data, 4);
        _squadInventory.FillHeroSlot(_hero2Data, 5);
    }

    private void OnAddedHeroToSquadSlot(HeroData heroData, IInventorySlot slot)
    {
        
    }
}