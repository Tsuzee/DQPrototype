using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    [SerializeField]
    private Image icon;

    public Image Icon { get { return icon; } }

    private Item item;
    public Item Item
    {
        get { return item; }
        set
        {
            if (item != value)
            {
                if (null == value)
                {
                    icon.sprite = null;
                    icon.gameObject.SetActive(false);
                }
                else
                {
                    icon.sprite = InventoryTextures.Instance.GetItemSprite(value.IconID);
                    icon.gameObject.SetActive(true);
                }
            }

            item = value;
        }
    }

    public Item PickUpItem()
    {
        var i = Item;
        Item = null;
        return i;
    }

    public void DropItem(Item item)
    {
        Item = item;
    }
    

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (null == Item)
            return;

        gameObject.SendMessageUpwards("BeginDragItem", this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        gameObject.SendMessageUpwards("UpdateMousePosition");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (null == eventData.selectedObject)
        {
            gameObject.SendMessageUpwards("CancelDragItem");
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        gameObject.SendMessageUpwards("EndDragItem", this);
    }
}
