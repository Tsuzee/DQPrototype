using UnityEngine;
using UnityEngine.UI;

public class DraggedItemManager : MonoBehaviour
{
    [SerializeField]
    private Image draggedItem;

    private ItemSlot dragSource = null;

    // TODO Data here

    void BeginDragItem(ItemSlot slot)
    {
        if (!dragSource)
        {
            dragSource = slot;
            draggedItem.gameObject.SetActive(true);

            draggedItem.sprite = slot.Icon.sprite;
            slot.PickUpItem();

            draggedItem.rectTransform.position = slot.Icon.rectTransform.position;
        }
    }

    void EndDragItem(ItemSlot slot)
    {
        if (dragSource)
        {
            slot.Icon.sprite = draggedItem.sprite;
            slot.DropItem();

            draggedItem.gameObject.SetActive(false);
            dragSource = null;
        }
    }

    void UpdateMousePosition()
    {
        if (draggedItem.IsActive())
        {
            draggedItem.rectTransform.position = Input.mousePosition;
        }
    }

    void CancelDragItem()
    {
        if (dragSource)
        {
            dragSource.DropItem();

            draggedItem.gameObject.SetActive(false);
            dragSource = null;
        }
    }
}
