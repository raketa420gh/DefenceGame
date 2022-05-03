using System;

public class HeroInventoryItem : IInventoryItem
{
    public IInventoryItemInfo Info { get; }
    public IInventoryItemState State { get; }
    public Type Type => GetType();

    public HeroInventoryItem(IInventoryItemInfo info)
    {
        Info = info;
        State = new InventoryItemState();
    }
    
    public IInventoryItem Clone()
    {
        var clonedHero = new HeroInventoryItem(Info);
        clonedHero.State.Amount = State.Amount;
        return clonedHero;
    }
}