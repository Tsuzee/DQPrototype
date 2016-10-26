using UnityEngine;
using System.Collections;

/// <summary>
/// Item base class for all in game items.
/// Defines an item's properties.
/// </summary>
public class Item
{
    //private variables to define items
    private ItemName itemName;
    private EquipmentType slot;
    private float damage;
    private float armor;
    private float hp;
    private bool isEquiped;
    private EquipSlots equipedTo;


    //public accessors
    public enum EquipmentType { None, Head, Body, Hands, Feet, Weapon, Component};
    public enum EquipSlots { None, Head, Body, Hands, Feet, LHand, RHand, QSlot1, QSlot2, QSlot3, QSlot4 };
    public ItemName Name
    {
        get { return itemName; }
    }
    public EquipmentType Slot
    {
        get { return slot; }
    }
    public float Damage
    {
        get { return damage; }
    }
    public float Armor
    {
        get { return armor; }
    }
    public float HP
    {
        get { return hp; }
    }
    public bool IsEquiped
    {
        get { return isEquiped; }
        set { isEquiped = value; }
    }
    public EquipSlots EquipedTo
    {
        get { return equipedTo; }
        set { equipedTo = value; }
    }

    /// <summary>
    /// Set up the item object. IsEquiped is false and EquipedTo is none by default.
    /// </summary>
    /// <param name="setName">Item name</param>
    /// <param name="setSlot">Type of item</param>
    /// <param name="setDamage">How much damage, zero for non-weapons</param>
    /// <param name="setArmor">How much defense, zero for non-armor</param>
    /// <param name="setHP">How much recovery, zero for non-potions</param>
    public Item(ItemName setName, EquipmentType setSlot, float setDamage, float setArmor, float setHP)
    {
        itemName = setName;
        slot = setSlot;
        damage = setDamage;
        armor = setArmor;
        hp = setHP;
        isEquiped = false;
        equipedTo = EquipSlots.None;
    }//end constructor

    public static readonly Item NullItem = new Item(ItemName.Null, EquipmentType.None, 0, 0, 0);

}//end of item class
