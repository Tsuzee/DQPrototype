using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerClickHandler, GridListElement
{
    [SerializeField]
    private Image icon;

    [SerializeField]
    private Item.EquipmentType filter;

    public Item.EquipmentType Filter
    {
        get { return filter; }
        set { filter = value; }
    }

    public Image Icon { get { return icon; } }

    private Item item;
    public Item Item
    {
        get { return item; }
        set
        {
            if (item != value && null != icon)
            {
                if (null == value)
                {
                    icon.sprite = null;
                    icon.gameObject.SetActive(false);
                }
                else
                {
                    icon.sprite = InventoryTextures.Instance.GetItemSprite((int)value.Name);
                    icon.gameObject.SetActive(true);
                }
            }

            item = value;
        }
    }
    
    public int Index { get; set; }

    public Item PickUpItem()
    {
        var i = Item;
        Item = null;
        SendMessageUpwards("OnItemPickedUp", i);
        return i;
    }

    public bool DropItem(Item item)
    {
        if (filter != Item.EquipmentType.None)
        {
            if (item.Slot != filter)
                return false;
        }
        Item = item;
        SendMessageUpwards("OnItemDropped", this);
        return true;
    }
    

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (null == Item)
            return;

        SendMessageUpwards("BeginDragItem", this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        SendMessageUpwards("UpdateMousePosition");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (null == eventData.selectedObject)
        {
            SendMessageUpwards("CancelDragItem");
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        SendMessageUpwards("EndDragItem", this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2 && null != Item)
        {
            SendMessageUpwards("UseItem", this);
        }
    }
}
