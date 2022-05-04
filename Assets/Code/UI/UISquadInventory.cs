using UnityEngine;

public class UISquadInventory : MonoBehaviour
{
    [SerializeField] private UIInventorySlot[] uiHeroSlots;
    [SerializeField] private HeroData _hero1Data;
    [SerializeField] private HeroData _hero2Data;

    private UIInventoryHandler _inventoryHandler;

    public InventoryWithSlots Inventory => _inventoryHandler.Inventory;

    private void Start()
    {
        _inventoryHandler = new UIInventoryHandler(uiHeroSlots, uiHeroSlots.Length);
        _inventoryHandler.FillHeroSlot(_hero1Data, 4);
        _inventoryHandler.FillHeroSlot(_hero2Data, 5);
    }
}