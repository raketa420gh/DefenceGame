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
        var allSlots = Inventory.GetAllSlots();
        var availableSlots = new List<IInventorySlot>(allSlots);
        
        var heroSlot = AddHeroIntoSlot(heroData, availableSlots, index);
        availableSlots.Remove(heroSlot);
        
        SetupInventoryUI(Inventory);

        return heroSlot;
    }

    private IInventorySlot AddHeroIntoSlot(HeroData heroData, List<IInventorySlot> slots, int slotIndex)
    {
        var heroInfo = new HeroInventoryItem(heroData);
        var slot = slots[slotIndex];

        Inventory.TryToAddToSlot(heroData, slot, heroInfo);

        return slot;
    }

    private void SetupInventoryUI(InventoryWithSlots inventory)
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


