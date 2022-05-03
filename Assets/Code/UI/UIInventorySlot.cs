using UnityEngine;
using UnityEngine.EventSystems;

public class UIInventorySlot : UISlot
{
    [SerializeField] private UIInventoryItem _uiInventoryItem;
    public IInventorySlot Slot { get; private set; }

    private UISquadInventory _uiInventory;

    private void Awake() => _uiInventory = GetComponentInParent<UISquadInventory>();

    public override void OnDrop(PointerEventData eventData)
    {
        base.OnDrop(eventData);
        
        var otherUIItem = eventData.pointerDrag.GetComponent<UIInventoryItem>();
        var otherUISlot = otherUIItem.GetComponentInParent<UIInventorySlot>();
        var otherSlot = otherUISlot.Slot;
        var inventory = _uiInventory.Inventory;
        
        inventory.TransitFromSlotToSlot(this, otherSlot, Slot);
        Refresh();
        otherUISlot.Refresh();
    }
    
    public void SetSlot(IInventorySlot newSlot)
    {
        Slot = newSlot;
    }

    public void Refresh()
    {
        if (Slot != null)
            _uiInventoryItem.Refresh(Slot);
    }
}