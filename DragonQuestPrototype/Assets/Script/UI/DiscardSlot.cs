using UnityEngine;
using System.Collections;

public class DiscardSlot : MonoBehaviour
{

    [SerializeField]
    private ItemDropper dropper;

    void OnItemDropped(ItemSlot slot)
    {
        dropper.Drop(slot.Item);
        slot.Item = null;
    }
}
