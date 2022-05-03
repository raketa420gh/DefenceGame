using System;

public class InventorySlot : IInventorySlot
{
    public bool IsFull => Amount == Capacity;
    public bool IsEmpty => Item == null;
    public IInventoryItem Item { get; private set; }
    public Type ItemType => Item.Type;
    public int Amount => IsEmpty ? 0 : Item.Amount;
    public int Capacity { get; private set; }

    public void SetItem(IInventoryItem item)
    {
        if (!IsEmpty)
            return;

        Item = item;
        Capacity = item.MaxItemsInInvetorySlot;
    }

    public void Clear()
    {
        if (!IsEmpty)
            return;

        Item.Amount = 0;
        Item = null;
    }
}