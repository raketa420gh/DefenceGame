using System;

[Serializable]
public class InventoryItemState : IInventoryItemState
{
    public int ItemAmount;
    public bool IsItemEquipped;
    
    public int Amount { get => ItemAmount; set => ItemAmount = value; }
    public bool IsEquipped { get => IsItemEquipped; set => IsItemEquipped = value; }

    public InventoryItemState(int itemAmount = 0, bool isEquipped = false)
    {
        ItemAmount = 0;
        IsItemEquipped = false;
    }
}