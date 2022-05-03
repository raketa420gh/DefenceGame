using System.Collections.Generic;
using UnityEngine;

public class UIInventoryTester
{
    private InventoryItemInfo _appleInfo;
    private InventoryItemInfo _lemonInfo;
    private UIInventorySlot[] _uiSlots;
    
    public InventoryWithSlots Inventory { get; }

    public UIInventoryTester(InventoryItemInfo appleInfo, InventoryItemInfo lemonInfo, UIInventorySlot[] uiSlots)
    {
        _appleInfo = appleInfo;
        _lemonInfo = lemonInfo;
        _uiSlots = uiSlots;

        Inventory = new InventoryWithSlots(16);
        Inventory.OnInventoryStateChanged += OnInventoryStateChanged;
    }

    public void FillSlotsRandom()
    {
        var allSlots = Inventory.GetAllSlots();
        var availableSlots = new List<IInventorySlot>(allSlots);

        var filledSlots = 5;

        for (int i = 0; i < filledSlots; i++)
        {
            var filledSlot = AddRandomApplesIntoRandomSlot(availableSlots);
            availableSlots.Remove(filledSlot);
            
            filledSlot = AddRandomLemonsIntoRandomSlot(availableSlots);
            availableSlots.Remove(filledSlot);
        }
        
        SetupInventoryUI(Inventory);
    }

    private IInventorySlot AddRandomLemonsIntoRandomSlot(List<IInventorySlot> slots)
    {
        var randomSlotIndex = Random.Range(0, slots.Count);
        var randomSlot = slots[randomSlotIndex];
        var randomCount = Random.Range(1, 5);
        var lemon = new Lemon(_lemonInfo);
        
        lemon.State.Amount = randomCount;
        Inventory.TryToAddToSlot(this, randomSlot, lemon);
        
        return randomSlot;
    }

    private IInventorySlot AddRandomApplesIntoRandomSlot(List<IInventorySlot> slots)
    {
        var randomSlotIndex = Random.Range(0, slots.Count);
        var randomSlot = slots[randomSlotIndex];
        var randomCount = Random.Range(1, 5);
        var apple = new Apple(_appleInfo);
        
        apple.State.Amount = randomCount;
        Inventory.TryToAddToSlot(this, randomSlot, apple);
        
        return randomSlot;
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
        {
            uiSlot.Refresh();
        }
    }
}


