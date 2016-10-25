using UnityEngine;
using System.Collections;

public class EquipmentUI : MonoBehaviour
{
    [SerializeField]
    private InventoryHandler inventory;

    void OnEnable()
    {
        inventory.EquipmentUpdateCallback = Refresh;
    }

    void OnDisable()
    {
        inventory.EquipmentUpdateCallback = null;
    }

    // Use this for initialization
    void Start()
    {
        Refresh();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Refresh()
    {

    }
}
