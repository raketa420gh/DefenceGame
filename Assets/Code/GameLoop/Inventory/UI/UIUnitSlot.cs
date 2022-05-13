using UnityEngine;
using UnityEngine.UI;

public class UIUnitSlot : MonoBehaviour
{
    [SerializeField] private UIUnitItem _uiInventoryItem;
    private Button _button;
    private int _index;
    private UIUnitSlotType _slotType = UIUnitSlotType.Inventory;

    public IInventorySlot Slot { get; private set; }
    public Button Button => _button;
    public int Index => _index;
    public UIUnitSlotType SlotType => _slotType;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void SetSlot(IInventorySlot newSlot, UIUnitSlotType slotType)
    {
        Slot = newSlot;
        _slotType = slotType;
        _index = gameObject.transform.GetSiblingIndex();
    }

    public void Refresh()
    {
        if (Slot != null)
            _uiInventoryItem.Refresh(Slot);
    }
}

public enum UIUnitSlotType
{
    Inventory = 0,
    HeroSquad = 1,
    TurretSquad = 2
}