using UnityEngine;
using System.Collections;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private InventoryHandler inventory;

    private GridList gridList;

    void OnEnable()
    {
        gridList = GetComponent<GridList>();
        inventory.InventoryUpdateCallback = Refresh;
    }

    void OnDisable()
    {
        inventory.InventoryUpdateCallback = null;
    }

    // Use this for initialization
    void Start()
    {
        Refresh();
    }

    void Refresh()
    {
        var itemList = inventory.GetItemList();
        for (int i = 0; i < gridList.Count; i++)
        {
            ItemSlot slot = gridList.GetElement<ItemSlot>(i);
            if (i >= itemList.Count)
            {
                slot.Item = null;
            }
            else
            {
                slot.Item = (itemList[i] == Item.NullItem ? null : itemList[i]);
            }
        }
    }

    void OnItemPickedUp(Item item)
    {
        if (null == item || Item.NullItem == item)
            return;

        inventory.Remove(item);
    }

    void OnItemDropped(ItemSlot slot)
    {
        inventory.Add(slot.Item, slot.Index);
    }
}
