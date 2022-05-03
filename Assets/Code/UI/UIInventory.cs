using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private InventoryItemInfo _appleInfo;
    [SerializeField] private InventoryItemInfo _lemonInfo;

    private UIInventoryTester _inventoryTester; 
    
    public InventoryWithSlots Inventory => _inventoryTester.Inventory;

    private void Start()
    {
        var uiSlots = GetComponentsInChildren<UIInventorySlot>();
        _inventoryTester = new UIInventoryTester(_appleInfo, _lemonInfo, uiSlots);
        _inventoryTester.FillSlotsRandom();
    }
}