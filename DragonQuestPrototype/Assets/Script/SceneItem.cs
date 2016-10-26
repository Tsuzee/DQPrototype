using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneItem : MonoBehaviour
{
    public bool defaultItem;
    public string itemName;
    public int iconID;
    public Item.EquipmentType itemType;
    public float damage;
    public float armaor;
    public float hp;


    private Item item;
    public Item Item
    {
        get
        {
            return item;
        }

        set
        {
            if (item != value)
            {
                icon.sprite = InventoryTextures.Instance.GetItemSprite(value.IconID);
            }
            item = value;
        }
    }
    
    private SpriteRenderer icon;

    void Awake()
    {
        icon = GetComponentInChildren<SpriteRenderer>();
    }

    void OnEnable()
    {
        Item = new Item(itemName, iconID, itemType, damage, armaor, hp);
    }

}
