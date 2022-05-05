using System.Collections.Generic;
using UnityEngine;

public class SquadFormationTester : MonoBehaviour
{
    [SerializeField] private HeroData _heroData1;
    [SerializeField] private HeroData _heroData2;
    [SerializeField] private UIUnitSlot _turretSlot;
    [SerializeField] private UIUnitSlot[] _heroSlots;

    private void Start()
    {
        var allSlots = new List<UIUnitSlot>(_heroSlots);
        allSlots.Add(_turretSlot);

        _turretSlot.gameObject.name = "TurretSlot";

        for (int i = 0; i < _heroSlots.Length; i++)
            _heroSlots[i].gameObject.name = $"HeroSlot{i+1}";

        foreach (var slot in allSlots)
        {
            slot.SetSlot(new InventorySlot());
            slot.Refresh();
            slot.Button.onClick.AddListener((() => SelectSlot(slot)));
        }

        var heroItem1 = new UnitItem(_heroData1);
        _heroSlots[0].Slot.SetItem(heroItem1);
        _heroSlots[0].Refresh();
        
        var heroItem2 = new UnitItem(_heroData2);
        _heroSlots[1].Slot.SetItem(heroItem2);
        _heroSlots[1].Refresh();
    }

    private void SelectSlot(UIUnitSlot slot)
    {
        Debug.Log($"{slot.gameObject.name} selected");
    }
}
