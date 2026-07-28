using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler,IEndDragHandler
{
    SlotUI slotUI;

    Canvas canvas;

    GameObject dragIcon;

    RectTransform dragRect;

    Image dragImage;

    public static SlotUI DragSlot;

    private void Awake()
    {
        slotUI = GetComponent<SlotUI>();

        canvas = GetComponentInParent<Canvas>();

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (slotUI.Slot == null) return;

        if (slotUI.Slot.IsEmpty) return;

        DragSlot = slotUI;

        dragIcon = new GameObject("DragIcon");

        dragIcon.transform.SetParent(canvas.transform);

        dragIcon.transform.SetAsLastSibling();

        dragRect = dragIcon.AddComponent<RectTransform>();

        dragRect.sizeDelta = new Vector2(100,100);

        dragImage = dragIcon.AddComponent<Image>();

        dragImage.sprite = slotUI.Slot.itemData.icon;

        dragImage.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragIcon == null) return;

        dragRect.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(dragIcon != null)
            Destroy(dragIcon);

        DragSlot = null;
    }
}
