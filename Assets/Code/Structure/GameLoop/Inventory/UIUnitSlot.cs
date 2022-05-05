using UnityEngine;
using UnityEngine.UI;

public class UIUnitSlot : MonoBehaviour
{
    [SerializeField] private UIUnitItem _uiInventoryItem;
    private Button _button;
    private bool _isSelected;

    public IInventorySlot Slot { get; private set; }
    public Button Button => _button;
    public bool IsSelected => _isSelected;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void SetSlot(IInventorySlot newSlot)
    {
        Slot = newSlot;
    }

    public void Refresh()
    {
        if (Slot != null)
            _uiInventoryItem.Refresh(Slot);
    }
}