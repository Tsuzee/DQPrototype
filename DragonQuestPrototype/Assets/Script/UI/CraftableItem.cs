using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CraftableItem : MonoBehaviour
{
    [SerializeField]
    private Image resultItemIcon;

    [SerializeField]
    private GameObject[] materialItems;

    [SerializeField]
    private Button craftButton;

    private CraftingFormula formula = null;

    public CraftingFormula Formula
    {
        get
        {
            return formula;
        }

        set
        {
            if (formula != value)
            {
                formula = value;
                UpdateUI();
            }
        }
    }

    private void UpdateUI()
    {
        if (null == formula)
        {

        }
        else
        {
            resultItemIcon.sprite = InventoryTextures.Instance.GetItemSprite(formula.result.itemName);
            UpdateMaterial(0, formula.material1);
            UpdateMaterial(1, formula.material2);
            UpdateMaterial(2, formula.material3);
        }
    }

    private void UpdateMaterial(int index, ItemName name)
    {
        if (ItemName.Null == name)
        {
            materialItems[index].SetActive(false);
        }
        else
        {
            materialItems[index].SetActive(true);
            Image icon = materialItems[index].GetComponentInChildren<Image>();
            icon.sprite = InventoryTextures.Instance.GetItemSprite(name);
        }
    }

    public void OnCraftButton()
    {
        if (null != Formula)
            SendMessageUpwards("OnCraft", Formula);
    }
}
