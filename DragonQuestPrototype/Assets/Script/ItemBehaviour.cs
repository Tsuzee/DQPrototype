using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemBehaviour : MonoBehaviour
{
    public static ItemBehaviour Instance { get; private set; }

    private delegate bool ItemDelegate(ItemName item);

    [SerializeField]
    private List<ItemTemplate> itemTemplates;

    private Dictionary<ItemName, ItemTemplate> itemTable = new Dictionary<ItemName, ItemTemplate>();
    private Dictionary<ItemName, ItemDelegate> itemBehaviours = new Dictionary<ItemName, ItemDelegate>();

    void Awake()
    {
        Instance = this;
        itemBehaviours[ItemName.HealthPotion] = AddPlayerHealth;

        foreach (ItemTemplate i in itemTemplates)
        {
            itemTable[i.itemName] = i;
        }
    }

    public bool UseItem(ItemName item)
    {
        if (itemBehaviours.ContainsKey(item) && itemBehaviours[item] != null)
        {
            return itemBehaviours[item](item);
        }
        return false;
    }

    bool AddPlayerHealth(ItemName item)
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        if (null == go)
            return false;

        var combat = go.GetComponent<PlayerCombat>();
        if (null == combat)
            return false;

        combat.Heal(itemTable[item].hp);

        return true;
    }
}

