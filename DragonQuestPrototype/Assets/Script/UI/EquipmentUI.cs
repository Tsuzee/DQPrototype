using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EquipmentUI : MonoBehaviour
{
    [SerializeField]
    private InventoryHandler inventory;

    [SerializeField]
    private ItemSlot headSlot;
    [SerializeField]
    private ItemSlot bodySlot;
    [SerializeField]
    private ItemSlot feetSlot;
    [SerializeField]
    private ItemSlot handRSlot;
    [SerializeField]
    private ItemSlot handLSlot;

    private Dictionary<Item.EquipSlots, ItemSlot> slots = new Dictionary<Item.EquipSlots, ItemSlot>();

    void Awake()
    {
        slots[Item.EquipSlots.Head] = headSlot;
        slots[Item.EquipSlots.Body] = bodySlot;
        slots[Item.EquipSlots.Feet] = feetSlot;
        slots[Item.EquipSlots.RHand] = handRSlot;
        slots[Item.EquipSlots.LHand] = handLSlot;

        headSlot.Index = (int)Item.EquipSlots.Head;
        bodySlot.Index = (int)Item.EquipSlots.Body;
        feetSlot.Index = (int)Item.EquipSlots.Feet;
        handRSlot.Index = (int)Item.EquipSlots.RHand;
        handLSlot.Index = (int)Item.EquipSlots.LHand;
    }

    void OnEnable()
    {
        inventory.EquipmentUpdateCallback += Refresh;
        Refresh();
    }

    void OnDisable()
    {
        inventory.EquipmentUpdateCallback -= Refresh;
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

                