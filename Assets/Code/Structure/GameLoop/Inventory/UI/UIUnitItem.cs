using UnityEngine;
using UnityEngine.UI;

public class UIUnitItem : MonoBehaviour
{
    [SerializeField] private Image _imageIcon;
    
    public IInventoryItem Item { get; private set; }

    public void Refresh(IInventorySlot slot)
    {
        if (slot.IsEmpty)
        {
            CleanUp();
            return;
        }
        
        Item = slot.Item;
        _imageIcon.sprite = Item.Info.SpriteIcon;
        _imageIcon.gameObject.SetActive(true);
        
    }
    
    private void CleanUp()
    {
        _imageIcon.gameObject.SetActive(false);
    }
}