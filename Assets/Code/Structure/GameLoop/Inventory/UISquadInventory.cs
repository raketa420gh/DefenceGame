using System.Collections.Generic;

public class UISquadInventory
{
    private UIInventorySlot[] _uiSlots;
    
    public InventoryWithSlots Inventory { get; }

    public UISquadInventory(UIInventorySlot[] uiSlots, int capacity)
    {
        _uiSlots = uiSlots;

        Inventory = new InventoryWithSlots(capacity);
        Inventory.OnInventoryStateChanged += OnInventoryStateChanged;
        
        SetupInventoryUI(Inventory);
    }

    public IInventorySlot FillHeroSlot(HeroData heroData, int index)
    {
        var allSlots = new List<IInventorySlot>(Inventory.GetAllSlots());
        var heroSlot = AddHeroIntoSlot(heroData, allSlots, index);

        return heroSlot;
    }

    private IInventorySlot AddHeroIntoSlot(HeroData heroData, List<IInventorySlot> slots, int slotIndex)
    {
        var heroInfo = new InventoryItem(heroData);
        var slot = slots[slotIndex];

        Inventory.TryToAddToSlot(heroData, slot, heroInfo);

        return slot;
    }

    public void SetupInventoryUI(InventoryWithSlots inventory)
    {
        var allSlots = inventory.GetAllSlots();
        var allSlotsCount = allSlots.Length;

        for (int i = 0; i < allSlotsCount; i++)
        {
            var slot = allSlots[i];
            var uiSlot = _uiSlots[i];
            uiSlot.SetSlot(slot);
            uiSlot.Refresh();
        }
    }

    private void OnInventoryStateChanged(object obj)
    {
        foreach (var uiSlot in _uiSlots)
            uiSlot.Refresh();
    }
}


