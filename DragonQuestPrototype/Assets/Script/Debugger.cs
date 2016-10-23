#if !UNITY_EDITOR
#error "remove me"
#endif

using UnityEngine;
using System.Collections;

public class Debugger : MonoBehaviour
{
    public bool auto = false;
    public bool addItem = false;
    public Sprite item;

    // Use this for initialization
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1.0f);
        if (auto)
        {
            addItem = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (addItem)
        {
            addItem = false;
            var slot = GetComponentInChildren<ItemSlot>();
            slot.Icon.sprite = item;
            slot.DropItem();
        }
    }
}
