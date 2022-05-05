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

        SetSlotsNames("TurretSlot", "HeroSlot", "InventorySlot");

        var heroItem1 = new UnitItem(_heroData1);
        SetHeroToUIUnitSlot(heroItem1, 0);
        _squadFormater.SetHeroToSlot(_heroData1, 0);

        var heroItem2 = new UnitItem(_heroData2);
        SetHeroToUIUnitSlot(heroItem2, 1);
        _squadFormater.SetHeroToSlot(_heroData2, 1);
    }
    
    private void SetHeroToUIUnitSlot(UnitItem unitItem, int slotIndex)
    {
        _heroSlots[slotIndex].Slot.SetItem(unitItem);
        _heroSlots[slotIndex].Refresh();
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
        if (!slot.Slot.IsEmpty)
            Debug.Log($"{slot.gameObject.name} with Unit Item {slot.Slot.ItemType} selected");
    }
}
