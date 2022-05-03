using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public InventoryWithSlots Inventory { get; private set; }

    private void Awake()
    {
        Inventory = new InventoryWithSlots(16);
    }
}