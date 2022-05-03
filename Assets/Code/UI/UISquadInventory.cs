using UnityEngine;

public class UISquadInventory : MonoBehaviour
{
    [SerializeField] private Transform heroSlotsParent;
    [SerializeField] private HeroData _hero1Data;
    [SerializeField] private HeroData _hero2Data;

    private UIInventoryHandler _inventoryHandler;

    public InventoryWithSlots Inventory => _inventoryHandler.Inventory;

    private void Start()
    {
        var uiHeroSlots = heroSlotsParent.GetComponentsInChildren<UIInventorySlot>();
        _inventoryHandler = new UIInventoryHandler(uiHeroSlots, uiHeroSlots.Length);
        _inventoryHandler.FillHeroSlot(_hero1Data, 0);
        _inventoryHandler.FillHeroSlot(_hero2Data, 1);
    }
}