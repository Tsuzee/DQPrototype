using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneItem : MonoBehaviour
{
    public ItemTemplate template;

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
                icon.sprite = InventoryTextures.Instance.GetItemSprite((int)value.Name);
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
        if (null != template)
            Item = template.Generate();
    }

}
