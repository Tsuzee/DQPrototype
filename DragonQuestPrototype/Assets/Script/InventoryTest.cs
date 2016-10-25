using UnityEngine;
using System.Collections;

public class InventoryTest : MonoBehaviour {

    [SerializeField]
    private InventoryHandler inventory;

	// Use this for initialization
	void Start () {
        AddTestItems();
    }

    // Update is called once per frame
    void Update () {
	
	}

    void AddTestItems()
    {
        inventory.Add(new Item("Sword", 0, Item.EquipmentType.Hands, 50, 0, 0));
        inventory.Add(new Item("Crossbow", 1, Item.EquipmentType.Hands, 20, 0, 0));
        inventory.Add(new Item("Pistol1", 2, Item.EquipmentType.Hands, 30, 0, 0));
        inventory.Add(new Item("Pistol2", 3, Item.EquipmentType.Hands, 40, 0, 0));
    }
}
