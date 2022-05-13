using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class UIAbilityButton : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public event Action OnAbilityActivated;
    
    private GameFactory _factory;
    private Button _button;
    private Image _image;

    private GameObject _pointerObject;

    [Inject]
    public void Construct(GameFactory factory)
    {
        _factory = factory;
    }

    private void Awake()
    {
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _pointerObject = _factory.CreateAbilityPointerSphere(transform.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform hitTransform = hit.transform;
        }

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.green);
        _pointerObject.transform.position = hit.point;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(_pointerObject);
        OnAbilityActivated?.Invoke();
    }
}

public class DamageDealer
{
    public event Action<int> OnDamageInflicted;
    
    public void InflictDamage(int amount)
    {
        OnDamageInflicted?.Invoke(amount);
    }
}

public enum AbilityType
{
    Undirected = 0,
    Directed = 1,
    Regionally = 2
}