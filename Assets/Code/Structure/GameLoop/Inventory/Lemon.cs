using System;

public class Lemon : IInventoryItem
{
    public IInventoryItemInfo Info { get; }
    public IInventoryItemState State { get; }
    public Type Type => GetType();
    
    public Lemon(IInventoryItemInfo info)
    {
        Info = info;
        State = new InventoryItemState();
    }
    
    public IInventoryItem Clone()
    {
        var clonedLemon = new Lemon(Info);
        clonedLemon.State.Amount = State.Amount;
        return clonedLemon;
    }
}