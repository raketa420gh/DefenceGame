using UnityEngine;

public class SquadInventory : MonoBehaviour
{
    [SerializeField] private UIInventorySlot[] _uiHeroSlots;
    [SerializeField] private HeroData _hero1Data;
    [SerializeField] private HeroData _hero2Data;

    private readonly UIInventorySlot[] _uiSquadHeroSlots = new UIInventorySlot[4];
    private UISquadInventory _uiSquadInventory;
    private SquadFormater _squadFormater;

    public InventoryWithSlots Inventory => _uiSquadInventory.Inventory;

    private void Start()
    {
        _uiSquadInventory = new UISquadInventory(_uiHeroSlots, 16);
        _uiSquadInventory.FillHeroSlot(_hero1Data, 4);
        _uiSquadInventory.FillHeroSlot(_hero2Data, 5);
        
        _uiSquadHeroSlots[0] = _uiHeroSlots[0];
        _uiSquadHeroSlots[1] = _uiHeroSlots[1];
        _uiSquadHeroSlots[2] = _uiHeroSlots[2];
        _uiSquadHeroSlots[3] = _uiHeroSlots[3];

        foreach (var slot in _uiHeroSlots)
        {
            if (slot.Slot.Item != null)
                Debug.Log(
                    $"Slot name {slot.transform.name}. Slot Item {slot.Slot.Item}. Slot IsEmpty {slot.Slot.IsEmpty}.");
            else
                Debug.Log($"Slot name {slot.transform.name} .Slot IsEmpty {slot.Slot.IsEmpty}.");
        }
        
        _uiSquadInventory.SetupInventoryUI(_uiSquadInventory.Inventory);
    }

    private void OnItemSettedToSlot(IInventoryItem item)
    {
        Debug.Log($"Dropped {item}");
    }

    private void OnDroppedItemToSlot(IInventoryItem item, IInventorySlot slot)
    {
        Debug.Log($"Drop {item} to slot {slot}");
    }
}