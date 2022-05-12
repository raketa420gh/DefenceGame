using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SquadFormationUI : MonoBehaviour
{
    public event Action OnPlayButtonPressed;
    
    [SerializeField] private HeroData _heroData1;
    [SerializeField] private HeroData _heroData2;
    [SerializeField] private TurretData _turretData;
    [SerializeField] private UIUnitSlot[] _turretSquadSlots;
    [SerializeField] private UIUnitSlot[] _heroSquadSlots;
    [SerializeField] private UIUnitSlot[] _unitsInventorySlots;
    [SerializeField] private SquadFormater _squadFormater;
    [SerializeField] private Button _playButton;

    private string _turretSlotName = "TurretSlot";
    private string _heroSlotName = "HeroSlot";
    private string _inventorySlotName = "InventorySlot";


    private void Start()
    {
        _playButton.onClick.AddListener((HandlePlayButton));
        SetupSquadSlots();

        var heroItem1 = new UnitItem(_heroData1);
        SetItemToUISlot(heroItem1, _unitsInventorySlots, 0);

        var heroItem2 = new UnitItem(_heroData2);
        SetItemToUISlot(heroItem2, _unitsInventorySlots, 1);

        var turretItem = new UnitItem(_turretData);
        SetItemToUISlot(turretItem, _turretSquadSlots, 0);

    }

    private void HandlePlayButton()
    {
        gameObject.SetActive(false);
        OnPlayButtonPressed?.Invoke();
    }

    private void SetupSquadSlots()
    {
        var allSlots = new List<UIUnitSlot>(_heroSquadSlots);
        allSlots.AddRange(_unitsInventorySlots);
        allSlots.AddRange(_turretSquadSlots);

        foreach (var slot in allSlots)
            slot.Button.onClick.AddListener((() => SelectSlot(slot)));

        foreach (var slot in _unitsInventorySlots)
            SetNewSlot(slot, UIUnitSlotType.Inventory);

        foreach (var slot in _heroSquadSlots)
            SetNewSlot(slot, UIUnitSlotType.HeroSquad);
        
        foreach (var slot in _turretSquadSlots)
            SetNewSlot(slot, UIUnitSlotType.HeroSquad);

        SetSlotsNames(_turretSlotName, _heroSlotName, _inventorySlotName);
        
        SelectTurret();
    }

    private void SetItemToUISlot(UnitItem unitItem, UIUnitSlot[] slots, int slotIndex)
    {
        slots[slotIndex].Slot.SetItem(unitItem);
        slots[slotIndex].Refresh();
    }

    private void SetNewSlot(UIUnitSlot slot, UIUnitSlotType slotType)
    {
        slot.SetSlot(new InventorySlot(), slotType);
        slot.Refresh();
    }

    private void SetSlotsNames(string turretSlotName, string heroSlotName, string inventorySlotName)
    { 
        for (int i = 0; i < _turretSquadSlots.Length; i++)
            _turretSquadSlots[i].gameObject.name = $"{turretSlotName}{i + 1}";

        for (int i = 0; i < _heroSquadSlots.Length; i++)
            _heroSquadSlots[i].gameObject.name = $"{heroSlotName}{i + 1}";

        for (int i = 0; i < _unitsInventorySlots.Length; i++)
            _unitsInventorySlots[i].gameObject.name = $"{inventorySlotName}{i + 1}";
    }

    private void SelectSlot(UIUnitSlot slot)
    {
        Debug.Log($"{slot.SlotType}");
        
        if (slot.Slot.Item != null)
        {
            if (slot.SlotType == UIUnitSlotType.HeroSquad)
                TransitFromSlotToSlot(slot.Slot, GetRandomSlot(GetAvailableInventorySlot()).Slot);
            
            if (slot.SlotType == UIUnitSlotType.Inventory)
                SelectHeroTest(slot, GetRandomSlot(GetAvailableHeroSlots()));
        }
    }

    private UIUnitSlot GetRandomSlot(List<UIUnitSlot> slots)
    {
        var randomIndex = Random.Range(0, slots.Count);
        return slots[randomIndex];
    }

    private List<UIUnitSlot> GetAvailableHeroSlots()
    {
        var availableSlots = new List<UIUnitSlot>(_heroSquadSlots);
        return availableSlots;
    }

    private List<UIUnitSlot> GetAvailableInventorySlot()
    {
        var availableSlots = new List<UIUnitSlot>(_unitsInventorySlots);
        return availableSlots;
    }

    private void SelectHeroTest(UIUnitSlot slot, UIUnitSlot availableSlot)
    {
            TransitFromSlotToSlot(slot.Slot, availableSlot.Slot);

            slot.Refresh();
            availableSlot.Refresh();
            
            _squadFormater.SetHeroToSlot(_heroData1, availableSlot.Index-1);
    }

    private void SelectTurret()
    {
        _squadFormater.SetTurretToSlot(_turretData);
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