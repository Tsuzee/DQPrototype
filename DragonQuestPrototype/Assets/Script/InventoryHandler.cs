using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Creates and manages a player inventory.
/// </summary>
public class InventoryHandler : MonoBehaviour {

    public delegate void UpdateCallback();

    //A list for items in the inventory
    private List<Item> inventory;
    [SerializeField]
    private List<CraftingFormula> craftables;
    private Dictionary<string, Item> equipedItems;
    [SerializeField]
    private int maxSize;   //max size of inventory    

    public UpdateCallback InventoryUpdateCallback { get; set; }
    public UpdateCallback EquipmentUpdateCallback { get; set; }

    /// <summary>
    /// Setup an inventory
    /// </summary>
    void Awake()
    {
        inventory = new List<Item>();
        for (int i = 0; i < maxSize; i++)
        {
            inventory.Add(Item.NullItem);
        }
        
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

    /// <summary>
    /// Add items to inventory
    /// </summary>
    /// <param name="item">Item to add</param>
    public void Add(Item item, int index = -1)
    {
        if (index < 0 || index > inventory.Count)
        {
            for (index = 0; index < inventory.Count; index++)
            {
                if (inventory[index] == Item.NullItem)
                {
                    break;
                }
            }
        }

        if(index >= 0 && index < inventory.Count)
        {
            inventory[index] = item;
            if (null != InventoryUpdateCallback)
                InventoryUpdateCallback();
        }
    }//end of add item

    /// <summary>
    /// Remove itmes from inventory
    /// </summary>
    /// <param name="item">Item to remove</param>
    public void Remove(Item item)
    {
        if (Item.NullItem == item)
            return;

        if (inventory.Count > 0)
        {
            int index = inventory.IndexOf(item);
            if (index < 0)
            {
                return;
            }
            inventory[index] = Item.NullItem;
            if (null != InventoryUpdateCallback)
                InventoryUpdateCallback();
        }
    }//end of remove item

    /// <summary>
    /// Use an item
    /// </summary>
    /// <param name="item">Item to use and remove</param>
    public void Use(Item item)
    {
        //Do thing with item
        
        //Then remove item from inventory
        Remove(item);
    }//end use item

    /// <summary>
    /// Equip item on player
    /// </summary>
    /// <param name="item">Item to equip</param>
    /// <param name="slot">Slot to equip to</param>
    public void Equip(Item item, string slot)
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
                        if (item.Slot != Item.EquipmentType.Hands)
                        { return; }
                        else
                        { item.EquipedTo = Item.EquipSlots.LHand; }
                        break;
                    }
                case "RHand":
                    {
                        if (item.Slot != Item.EquipmentType.Hands)
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


            if (null != InventoryUpdateCallback)
                InventoryUpdateCallback();

            if (null != EquipmentUpdateCallback)
                EquipmentUpdateCallback();

            //if the temp item is not null, unquip it
            if (oldItem != null)
            {
                Unquip(oldItem, true);
            }
        }//end if not equiped already
    }//end equip item

    /// <summary>
    /// Unequip an item
    /// </summary>
    /// <param name="item">Item to unquip</param>
    /// <param name="wasReplaced">Was item replaced by another item</param>
    public void Unquip(Item item, bool wasReplaced = false)
    {
        item.IsEquiped = false;
        if (!wasReplaced)
        {
            equipedItems[item.EquipedTo.ToString()] = null;
            item.EquipedTo = Item.EquipSlots.None;

            if (null != InventoryUpdateCallback)
                InventoryUpdateCallback();

            if (null != EquipmentUpdateCallback)
                EquipmentUpdateCallback();
        }
    }//end unequip item

    /// <summary>
    /// Get the Item List
    /// </summary>
    /// <returns>Returns List(Item) of items in inventory</returns>
    public List<Item> GetItemList()
    {
        return inventory;
    }//end of get items

    /// <summary>
    /// Get a dictionary of equiped items
    /// </summary>
    /// <returns>Returns Dictionary(string, Item) of equiped items</returns>
    public Dictionary<string, Item> GetEquipedItems()
    {
        return equipedItems;
    }//end of get equiped items

    /// <summary>
    /// Get a list of craftable items
    /// </summary>
    /// <returns>Returns List(Item) of craftable items</returns>
    public List<CraftingFormula> GetCraftingList()
    {
        return craftables;
    }//end of get crafting list

    public Item FindItemByName(ItemName item)
    {
        if (ItemName.Null == item)
            return Item.NullItem;

        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].Name == item)
                return inventory[i];
        }
        return null;
    }

    /// <summary>
    /// Craft an item
    /// </summary>
    /// <param name="item">Item to craft</param>
    /// <returns>Returns if crafting was successful</returns>
    public bool Craft(CraftingFormula formula)
    {
        if (null == formula || !formula.Valid())
            return false;

        var mat1 = FindItemByName(formula.material1);
        var mat2 = FindItemByName(formula.material2);
        var mat3 = FindItemByName(formula.material3);

        if (null == mat1 || null == mat2 || null == mat3)
        {
            return false;
        }

        Remove(mat1);
        Remove(mat2);
        Remove(mat3);
        Add(formula.result.Generate());

        return true;
    }//end of craft
	
}//end Inventory Handler class
