using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class UIButtonAbilityRegionally : MonoBehaviour, IUIButtonAbilityRegionally
{
    public event Action OnPointerDragEnd;

    private GameFactory _factory;
    private GameObject _pointerObject;

    [Inject]
    public void Construct(GameFactory factory)
    {
        _factory = factory;
    }

    private void Start()
    {
        _pointerObject = _factory.CreateAbilityPointerSphere(transform.position);
        _pointerObject.SetActive(false);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _pointerObject.SetActive(true);
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
        _pointerObject.SetActive(false);
        OnPointerDragEnd?.Invoke();
    }
}