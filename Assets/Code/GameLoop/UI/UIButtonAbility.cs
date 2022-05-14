using UnityEngine;
using UnityEngine.UI;

public class UIButtonAbility : MonoBehaviour, IUIButtonAbility
{
    private Button _button;
    private Image _image;
    
    private void Awake()
    {
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();
    }

    public void SetIcon(Sprite sprite)
    {
        _image.sprite = sprite;
    }

    public void SetupAbility(AbilityType abilityType)
    {
        if (abilityType == AbilityType.Regionally)
        {
            gameObject.AddComponent<UIButtonAbilityRegionally>();
        }
    }
}