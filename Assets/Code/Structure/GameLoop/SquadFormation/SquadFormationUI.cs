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

    private Turret _turret;
    private Hero _hero1;
    private Hero _hero2;

    private string _turretSlotName = "TurretSlot";
    private string _heroSlotName = "HeroSlot";
    private string _inventorySlotName = "InventorySlot";


    private void Start()
    {
        _playButton.onClick.AddListener((HandlePlayButton));
        SetupSquadSlots();

        var heroItem1 = new UnitItem(_heroData1);
        SetItemToUISlot(heroItem1, _heroSquadSlots, 0);

        var heroItem2 = new UnitItem(_heroData2);
        SetItemToUISlot(heroItem2, _heroSquadSlots, 3);

        var turretItem = new UnitItem(_turretData);
        SetItemToUISlot(turretItem, _turretSquadSlots, 0);
    }

    private void HandlePlayButton()
    {
        gameObject.SetActive(false);
        StartSquadShooting();
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
        
        SetupSquadTest();
    }

    private void SetupSquadTest()
    {
        _turret = _squadFormater.SetTurretToSlot(_turretData);
        _hero1 = _squadFormater.SetHeroToSlot(_heroData1, 0);
        _hero2 = _squadFormater.SetHeroToSlot(_heroData2, 3);
    }

    private void StartSquadShooting()
    {
        _turret.StartShooting();
        _hero1.StartShooting();
        _hero2.StartShooting();
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
    }
}