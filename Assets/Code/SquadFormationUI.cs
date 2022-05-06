using System.Collections.Generic;
using UnityEngine;

public class SquadFormationUI : MonoBehaviour
{
    [SerializeField] private HeroData _heroData1;
    [SerializeField] private HeroData _heroData2;
    [SerializeField] private UIUnitSlot _turretSlot;
    [SerializeField] private UIUnitSlot[] _heroSlots;
    [SerializeField] private UIUnitSlot[] _unitsInventorySlots;
    [SerializeField] private SquadFormater _squadFormater;

    private string _turretSlotName = "TurretSlot";
    private string _heroSlotName = "HeroSlot";
    private string _inventorySlotName = "InventorySlot";


    private void Start()
    {
        var allSlots = new List<UIUnitSlot>(_heroSlots);
        allSlots.AddRange(_unitsInventorySlots);
        allSlots.Add(_turretSlot);

        foreach (var slot in allSlots)
        {
            SetNewSlot(slot);
            slot.Button.onClick.AddListener((() => SelectSlot(slot)));
        }

        SetSlotsNames(_turretSlotName, _heroSlotName, _inventorySlotName);

        var heroItem1 = new UnitItem(_heroData1);
        SetHeroItemToUISlot(heroItem1, _unitsInventorySlots, 0);

        var heroItem2 = new UnitItem(_heroData2);
        SetHeroItemToUISlot(heroItem2, _unitsInventorySlots, 1);
    }

    private void SetHeroItemToUISlot(UnitItem unitItem, UIUnitSlot[] slots, int slotIndex)
    {
        slots[slotIndex].Slot.SetItem(unitItem);
        slots[slotIndex].Refresh();
    }

    private void SetNewSlot(UIUnitSlot slot)
    {
        slot.SetSlot(new InventorySlot());
        slot.Refresh();
    }

    private void SetSlotsNames(string turretSlotName, string heroSlotName, string inventorySlotName)
    {
        _turretSlot.gameObject.name = $"{turretSlotName}";

        for (int i = 0; i < _heroSlots.Length; i++)
            _heroSlots[i].gameObject.name = $"{heroSlotName}{i + 1}";

        for (int i = 0; i < _unitsInventorySlots.Length; i++)
        {
            _unitsInventorySlots[i].gameObject.name = $"{inventorySlotName}{i + 1}";
        }
    }

    private void SelectSlot(UIUnitSlot slot)
    {
        if (!slot.Slot.IsEmpty && slot.Slot.Item != null)
        {
            SelectHeroTest(slot, 1, 1);
            SelectHeroTest(slot, 2, 2);
        }
    }

    private void SelectHeroTest(UIUnitSlot slot, int inventorySlotNumber, int heroSlotNumber)
    {
        if (slot.gameObject.name == $"{_inventorySlotName}{inventorySlotNumber}")
        {
            TransitFromSlotToSlot(slot.Slot, _heroSlots[heroSlotNumber-1].Slot);

            slot.Refresh();
            _heroSlots[heroSlotNumber-1].Refresh();
            
            _squadFormater.SetHeroToSlot(_heroData1, heroSlotNumber-1);
        }
    }

    private void TransitFromSlotToSlot(IInventorySlot fromSlot, IInventorySlot toSlot)
    {
        if (fromSlot.IsEmpty)
            return;
        if (toSlot.IsFull)
            return;
        if (!toSlot.IsEmpty && fromSlot.ItemType != toSlot.ItemType)
            return;

        if (toSlot.IsEmpty)
        {
            toSlot.SetItem(fromSlot.Item);
            fromSlot.Clear();
        }

        fromSlot.Clear();
    }
}