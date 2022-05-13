using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIAbilityButton : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Button _button;

    private GameObject _debugObject;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log($"OnBeginDrag {eventData}");

        _debugObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        _debugObject.GetComponent<Collider>().enabled = false;
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
        _debugObject.transform.position = hit.point;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log($"OnEndDrag {eventData}");
    }
}