using UnityEngine;
using System.Collections.Generic;

public class InventoryHandler : MonoBehaviour {

    //A list for items in the inventory
    private List<Item> inventory;
    private List<Item> craftables;
    private Dictionary<string, Item> equipedItems;
    private int maxSize;   //max size of inventory    
    
    //Class Functions
    InventoryHandler(int setSize)
    {
        maxSize = setSize;
        inventory = new List<Item>();
        craftables = new List<Item>();
        equipedItems = new Dictionary<string, Item>();
        equipedItems.Add("Head", null);
        equipedItems.Add("Body", null);
        equipedItems.Add("Hands", null);
        equipedItems.Add("Feet", null);
        equipedItems.Add("LHand", null);
        equipedItems.Add("RHand", null);
        equipedItems.Add("QSlot1", null);
        equipedItems.Add("QSlot2", null);
        equipedItems.Add("QSlot3", null);
        equipedItems.Add("QSlot4", null);
    }//end constructor

    void Add(Item item)
    {
        if(inventory.Count < maxSize)
        {
            inventory.Add(item);
        }
    }//end of add item

    void Remove(Item item)
    {
        if (inventory.Count > 0)
        {
            inventory.Remove(item);
        }
    }//end of remove item

    void Use(Item item)
    {
        //Do thing with item
        
        //Then remove item from inventory
        Remove(item);
    }//end use item

    void Equip(Item item, string slot)
    {
        //setup temp for item to be unquiped.
        Item oldItem = equipedItems[slot];

        if(!item.IsEquiped)
        {
            //safty switch to ensure items match the slot
            switch (slot)
            {
                case "Head":
                    {
                        if (item.Slot != Item.EquipmentType.Head)
                             {return;}
                        else
                             {item.EquipedTo = Item.EquipSlots.Head;}
                        break;
                    }
                case "Body":
                    {
                        if (item.Slot != Item.EquipmentType.Body)
                            { return; }
                        else
                            { item.EquipedTo = Item.EquipSlots.Body; }
                        break;
                    }
                case "Hands":
                    {
                        if (item.Slot != Item.EquipmentType.Hands)
                             { return; }
                        else
                              { item.EquipedTo = Item.EquipSlots.Hands; }
                        break;
                    }
                case "Feet":
                    {
                        if (item.Slot != Item.EquipmentType.Feet)
                        { return; }
                        else
                        { item.EquipedTo = Item.EquipSlots.Feet; }
                        break;
                    }
                case "LHand":
                    {
                        if (item.Slot != Item.EquipmentType.Weapon)
                        { return; }
                        else
                        { item.EquipedTo = Item.EquipSlots.LHand; }
                        break;
                    }
                case "RHand":
                    {
                        if (item.Slot != Item.EquipmentType.Weapon)
                        { return; }
                        else
                        { item.EquipedTo = Item.EquipSlots.RHand; }
                        break;
                    }
                case "QSlot1":
                    {
                        if (item.Slot != Item.EquipmentType.Component)
                        { return; }
                        else
                        { item.EquipedTo = Item.EquipSlots.QSlot1; }
                        break;
                    }
                case "QSlot2":
                    {
                        if (item.Slot != Item.EquipmentType.Component)
                        { return; }
                        else
                        { item.EquipedTo = Item.EquipSlots.QSlot2; }
                        break;
                    }
                case "QSlot3":
                    {
                        if (item.Slot != Item.EquipmentType.Component)
                        { return; }
                        else
                        { item.EquipedTo = Item.EquipSlots.QSlot3; }
                        break;
                    }
                case "QSlot4":
                    {
                        if (item.Slot != Item.EquipmentType.Component)
                        { return; }
                        else
                        { item.EquipedTo = Item.EquipSlots.QSlot4; }
                        break;
                    }
            }//end switch

            equipedItems[slot] = item;
            item.IsEquiped = true;

            //if the temp item is not null, unquip it
            if(oldItem != null)
            {
                Unquip(oldItem, true);
            }
        }//end if not equiped already
    }//end equip item

    void Unquip(Item item, bool wasReplaced)
    {
        item.IsEquiped = false;
        if (!wasReplaced)
        {
            equipedItems[item.EquipedTo.ToString()] = null;
            item.EquipedTo = Item.EquipSlots.None;
        }
    }//end unequip item

    List<Item> GetItemList()
    {
        return inventory;
    }//end of get items

    Dictionary<string, Item> GetEquipedItems()
    {
        return equipedItems;
    }//end of get equiped items

    List<Item> GetCraftingList()
    {
        return craftables;
    }//end of get crafting list

    bool Craft(Item item)
    {
        //try to craft item, return if successful
        return false;
    }//end of craft
}//end Inventory Handler class
