using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemBehaviour : MonoBehaviour
{
    public static ItemBehaviour Instance { get; private set; }

    public delegate bool ItemDelegate(ItemTemplate item);

    [SerializeField]
    private List<ItemTemplate> itemTemplates;

    private Dictionary<ItemName, ItemTemplate> itemTable = new Dictionary<ItemName, ItemTemplate>();
    private Dictionary<ItemName, ItemDelegate> itemBehaviours = new Dictionary<ItemName, ItemDelegate>();

    void Awake()
    {
        Instance = this;

        foreach (ItemTemplate i in itemTemplates)
        {
            itemTable[i.itemName] = i;
        }
        
        RegisterItemBehaviour(ItemName.HealthPotion, AddPlayerHealth);
    }

    public void RegisterItemBehaviour(ItemName itemName, ItemDelegate behaviour)
    {
        if (!itemTable.ContainsKey(itemName))
        {
            throw new System.Exception("[ItemBehaviour] Cannot find data of this item.");
        }
        itemBehaviours[itemName] = behaviour;
    }

    public bool UseItem(ItemName item)
    {
        if (itemBehaviours.ContainsKey(item) && itemBehaviours[item] != null)
        {
            return itemBehaviours[item](itemTable[item]);
        }
        return false;
    }

    bool AddPlayerHealth(ItemTemplate item)
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        if (null == go)
            return false;

        var combat = go.GetComponent<PlayerCombat>();
        if (null == combat)
            return false;

        combat.Heal(item.hp);

        return true;
    }
}

