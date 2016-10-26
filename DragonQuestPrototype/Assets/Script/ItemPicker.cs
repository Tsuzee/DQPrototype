using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemPicker : MonoBehaviour
{
    [SerializeField]
    private InventoryHandler inventory;
    private HashSet<SceneItem> pickableItem = new HashSet<SceneItem>();

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Pick"))
        {
            foreach (var sceneItem in pickableItem)
            {
                Item item = sceneItem.Item;
                if (null != item)
                {
                    inventory.Add(item);
                }

                Destroy(sceneItem.gameObject);
            }
            pickableItem.Clear();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var item = other.GetComponent<SceneItem>();
        if (null == item)
            return;

        pickableItem.Add(item);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        var item = other.GetComponent<SceneItem>();
        if (null == item)
            return;

        pickableItem.Remove(item);
    }
}
