using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    [SerializeField]
    private Image icon;

    public Image Icon { get { return icon; } }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PickUpItem()
    {
        icon.gameObject.SetActive(false);
    }

    public void DropItem()
    {
        icon.gameObject.SetActive(true);
    }



    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!icon.IsActive())
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
