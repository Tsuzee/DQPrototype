using UnityEngine;
using System.Collections;

public class ItemTemplate : MonoBehaviour
{
    public ItemName itemName;
    [SerializeField]
    private Item.EquipmentType itemType;
    [SerializeField]
    private float damage;
    [SerializeField]
    private float armaor;
    [SerializeField]
    private float hp;

    public Item Generate()
    {
        return new Item(itemName, itemType, damage, armaor, hp);
    }
}
