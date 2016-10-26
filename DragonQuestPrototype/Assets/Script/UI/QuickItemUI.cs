using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuickItemUI : MonoBehaviour
{
    [SerializeField]
    private InventoryHandler inventory;

    [SerializeField]
    private Item.EquipSlots[] slotTypes;

    [SerializeField]
    private Item.EquipmentType[] filterTypes;

    private GridList gridList;

    private Dictionary<Item.EquipSlots, ItemSlot> slots = new Dictionary<Item.EquipSlots, ItemSlot>();

    void OnEnable()
    {
        gridList = GetComponent<GridList>();
        gridList.Init();
        if (slots.Count == 0)
        {
            for (int i = 0; i < slotTypes.Length; i++)
            {
                slots[slotTypes[i]] = gridList.GetElement<ItemSlot>(i);
                slots[slotTypes[i]].Index = (int)slotTypes[i];
                slots[slotTypes[i]].Filter = filterTypes[i];
            }
        }
        inventory.EquipmentUpdateCallback += Refresh;
    }

    void OnDisable()
    {
        inventory.EquipmentUpdateCallback -= Refresh;
    }

    void Start()
    {
        Refresh();
    }

    void Refresh()
    {
        var equips = inventory.GetEquipedItems();
        foreach (var equip in equips)
        {
            Item.EquipSlots slotType = (Item.EquipSlots)System.Enum.Parse(typeof(Item.EquipSlots), equip.Key, true);
            if (slotType == Item.EquipSlots.None)
            {
                throw new System.Exception("Invalid Slot Type");
            }

            if (!slots.ContainsKey(slotType))
                continue;
            slots[slotType].Item = equip.Value;
        }
    }

    public bool UseItem(Item.EquipSlots slot)
    {
        if (!slots.ContainsKey(slot) || slots[slot].Item == null)
            return false;

        return inventory.Use(slots[slot].Item);
    }

    // Update is called once per frame
    void OnItemPickedUp(Item item)
    {
        if (null == item || Item.NullItem == item)
            return;

        inventory.Unquip(item);
    }

    void OnItemDropped(ItemSlot slot)
    {
        inventory.Equip(slot.Item, ((Item.EquipSlots)slot.Index).ToString());
    }
}
