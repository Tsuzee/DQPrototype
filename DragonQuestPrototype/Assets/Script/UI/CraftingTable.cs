using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CraftingTable : MonoBehaviour {

    [SerializeField]
    private CraftableItem prefab;

    [SerializeField]
    private RectTransform content;

    private float itemHeight = 0.0f;
    private List<CraftableItem> list = new List<CraftableItem>();

    void Awake()
    {
        itemHeight = prefab.GetComponent<RectTransform>().rect.height;
    }

	// Use this for initialization
	void Start () {
        FillInDebugData();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void AddCraftableItem(CraftingFormula formula)
    {
        var item = Instantiate(prefab);
        item.transform.SetParent(content, false);
        list.Add(item);
        
        item.transform.localPosition = new Vector3(0, - itemHeight * (list.Count - 1));

        item.Formula = formula;
        
        content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, itemHeight * list.Count);
    }

#if UNITY_EDITOR
    void FillInDebugData()
    {
        AddCraftableItem(null);
        AddCraftableItem(null);
        AddCraftableItem(null);
        AddCraftableItem(null);
        AddCraftableItem(null);
        AddCraftableItem(null);
        AddCraftableItem(null);
        AddCraftableItem(null);
        AddCraftableItem(null);
        AddCraftableItem(null);
    }
#endif

}
