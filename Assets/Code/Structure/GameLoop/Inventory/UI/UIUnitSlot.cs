using UnityEngine;
using UnityEngine.UI;

public class UIUnitSlot : MonoBehaviour
{
    [SerializeField] private UIUnitItem _uiInventoryItem;
    private Button _button;

    public IInventorySlot Slot { get; private set; }
    public Button Button => _button;

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