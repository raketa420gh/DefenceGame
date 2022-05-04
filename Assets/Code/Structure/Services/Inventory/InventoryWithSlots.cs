using System;
using System.Collections.Generic;
using System.Linq;

public class InventoryWithSlots : IInventory
{
    public event Action<object, IInventoryItem, int> OnItemAdded;
    public event Action<object, Type, int> OnItemRemoved;
    public event Action<object> OnInventoryStateChanged;
    
    private List<IInventorySlot> _slots;
    
    public int Capacity { get; set; }
    public bool IsFull => _slots.All(slot => slot.IsFull);

    public InventoryWithSlots(int capacity)
    {
        Capacity = capacity;

        _slots = new List<IInventorySlot>(capacity);
        for (int i = 0; i < capacity; i++)
            _slots.Add(new InventorySlot());
    }
    
    public IInventoryItem GetItem(Type itemType) => _slots.Find(slot => slot.ItemType == itemType).Item;

    public IInventoryItem[] GetAllItems() => (from slot in _slots where !slot.IsEmpty select slot.Item).ToArray();

    public IInventoryItem[] GetAllItems(Type itemType)
    {
        var slotsOfType = _slots.FindAll(slot => !slot.IsEmpty && slot.ItemType == itemType);
        return slotsOfType.Select(slot => slot.Item).ToArray();
    }

    public IInventoryItem[] GetEquippedItems()
    {
        var requiredSlots = _slots.FindAll(slot => !slot.IsEmpty && slot.Item.State.IsEquipped);
        return requiredSlots.Select(slot => slot.Item).ToArray();
    }

    public int GetItemAmount(Type itemType)
    {
        var allItemSlots = _slots.FindAll(slot => !slot.IsEmpty && slot.ItemType == itemType);
        return allItemSlots.Sum(itemSlot => itemSlot.Amount);
    }

    public bool TryToAdd(object sender, IInventoryItem item)
    {
        var slotWithSameItemButNotEmpty =
            _slots.Find(slot => !slot.IsEmpty && slot.ItemType == item.Type && !slot.IsFull);

        if (slotWithSameItemButNotEmpty != null)
            return TryToAddToSlot(sender, slotWithSameItemButNotEmpty, item);

        var emptySlot = _slots.Find(slot => slot.IsEmpty);
        if (emptySlot != null)
            TryToAddToSlot(sender, emptySlot, item);

        return false;
    }

    public void TransitFromSlotToSlot(object sender, IInventorySlot fromSlot, IInventorySlot toSlot)
    {
        if (fromSlot.IsEmpty)
            return;
        if (toSlot.IsFull)
            return;
        if (!toSlot.IsEmpty && fromSlot.ItemType != toSlot.ItemType)
            return;

        var slotCapacity = fromSlot.Capacity;
        var fits = fromSlot.Amount + toSlot.Amount <= slotCapacity;
        var amountToAdd = fits ? fromSlot.Amount : slotCapacity - toSlot.Amount;
        var amountLeft = fromSlot.Amount - amountToAdd;

        if (toSlot.IsEmpty)
        {
            toSlot.SetItem(fromSlot.Item);
            fromSlot.Clear();
            OnInventoryStateChanged?.Invoke(sender);
        }
        
        toSlot.Item.State.Amount += amountToAdd;
        
        if (fits) 
            fromSlot.Clear();
        else
            fromSlot.Item.State.Amount = amountLeft;
        OnInventoryStateChanged?.Invoke(sender);
    }

    public void Remove(object sender, Type itemType, int amount = 1)
    {
        var slotsWithItem = GetAllSlots(itemType);
        if (slotsWithItem.Length == 0) 
            return;

        var amountToRemove = amount;
        var count = slotsWithItem.Length;

        for (int i = count - 1; i >= 0; i--)
        {
            var slot = slotsWithItem[i];
            
            if (slot.Amount >= amountToRemove)
            {
                if (slot.Amount <= 0)
                    slot.Clear();
                
                OnItemRemoved?.Invoke(sender, itemType, amountToRemove);
                OnInventoryStateChanged?.Invoke(sender);
                break;
            }

            var amountRemoved = slot.Amount;
            amountToRemove -= slot.Amount;
            slot.Clear();
            
            OnItemRemoved?.Invoke(sender, itemType, amountRemoved);
            OnInventoryStateChanged?.Invoke(sender);
        }
    }

    public bool HasItem(Type itemType, out IInventoryItem item)
    {
        item = GetItem(itemType);
        return item != null;
    }

    public bool TryToAddToSlot(object sender, IInventorySlot slot, IInventoryItem item)
    {
        var fits = slot.Amount + item.State.Amount <= item.Info.MaxItemsInInventorySlot;
        var amountToAdd = fits ? item.State.Amount : item.Info.MaxItemsInInventorySlot - slot.Amount;
        var amountLeft = item.State.Amount - amountToAdd;
        var clonedItem = item.Clone();
        clonedItem.State.Amount = amountToAdd;

        if (slot.IsEmpty)
            slot.SetItem(clonedItem);
        else
            slot.Item.State.Amount += amountToAdd;
        
        OnItemAdded?.Invoke(sender, item, amountToAdd);
        OnInventoryStateChanged?.Invoke(sender);

        if (amountLeft <= 0) 
            return true;

        item.State.Amount = amountLeft;
        return TryToAdd(sender, item);
    }

    public IInventorySlot[] GetAllSlots() => _slots.ToArray();

    private IInventorySlot[] GetAllSlots(Type itemType) => _slots.FindAll(slot => !slot.IsEmpty && slot.ItemType == itemType).ToArray();
}