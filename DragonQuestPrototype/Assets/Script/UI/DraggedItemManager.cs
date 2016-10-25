using UnityEngine;
using UnityEngine.UI;

public class DraggedItemManager : MonoBehaviour
{
    [SerializeField]
    private Image draggedItem;

    private ItemSlot dragSource = null;
    private Item draggedItemData = null;

    void BeginDragItem(ItemSlot slot)
    {
        if (!dragSource)
        {
            dragSource = slot;

            draggedItem.sprite = slot.Icon.sprite;
            draggedItem.gameObject.SetActive(true);

            draggedItemData = slot.PickUpItem();
            
            draggedItem.rectTransform.position = slot.Icon.rectTransform.position;
        }
    }

    void EndDragItem(ItemSlot slot)
    {
        if (dragSource)
        {
            slot.DropItem(draggedItemData);

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
            dragSource.DropItem(draggedItemData);

            draggedItem.gameObject.SetActive(false);
            dragSource = null;
        }
    }
}
