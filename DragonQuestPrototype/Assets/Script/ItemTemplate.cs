using UnityEngine;
using System.Collections;

public class ItemTemplate : MonoBehaviour
{
    public ItemName itemName;
    public Item.EquipmentType itemType;
    public float damage;
    public float armaor;
    public float hp;

    public Item Generate()
    {
        return new Item(itemName, itemType, damage, armaor, hp);
    }
}
