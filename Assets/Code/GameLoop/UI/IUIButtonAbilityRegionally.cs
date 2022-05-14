using System;
using UnityEngine.EventSystems;

public interface IUIButtonAbilityRegionally : IDragHandler, IBeginDragHandler, IEndDragHandler
{
    event Action OnPointerDragEnd;
    void OnBeginDrag(PointerEventData eventData);
    void OnDrag(PointerEventData eventData);
    void OnEndDrag(PointerEventData eventData);
}