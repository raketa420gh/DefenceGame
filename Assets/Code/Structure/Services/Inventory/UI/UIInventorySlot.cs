using UnityEngine;
using UnityEngine.EventSystems;

public class UIInventorySlot : UISlot
{
    [SerializeField] private UIInventoryItem _uiInventoryItem;
    public IInventorySlot Slot { get; private set; }

    private UISquadInventoryController _uiInventoryController;

    private void Awake() => _uiInventoryController = GetComponentInParent<UISquadInventoryController>();

    public override void OnDrop(PointerEventData eventData)
    {
        base.OnDrop(eventData);
        
        var otherUIItem = eventData.pointerDrag.GetComponent<UIInventoryItem>();
        var otherUISlot = otherUIItem.GetComponentInParent<UIInventorySlot>();
        var otherSlot = otherUISlot.Slot;
        var inventory = _uiInventoryController.Inventory;
        
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