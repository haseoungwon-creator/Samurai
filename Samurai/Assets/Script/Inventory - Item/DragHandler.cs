using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    SlotUI slotUI;
    static GameObject dragIcon;
    [SerializeField] Canvas rootCanvas;

    private void Awake()
    {
        slotUI = GetComponent<SlotUI>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (slotUI.slot.IsEmpty)
        {
            return;
        }

        dragIcon = new GameObject("DragIcon");

        dragIcon.transform.SetParent(rootCanvas.transform);

        Image image = dragIcon.AddComponent<Image>();
        image.sprite = slotUI.slot.itemData.icon;
        image.raycastTarget = false;

        dragIcon.GetComponent<RectTransform>().sizeDelta = new Vector2(50, 50);

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragIcon == null) return;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rootCanvas.transform as RectTransform,
            eventData.position,
            rootCanvas.worldCamera,
            out Vector2 localPos);

        dragIcon.transform.localPosition = localPos;
    }

    public void OnEndDrag(PointerEventData eventData) 
    {
        Destroy(dragIcon);
    }


}
    
