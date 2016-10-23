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
            CraftingFormula newFormula = null;
            if (null != value && value.resultItem >= 0 && value.materialItem1 >= 0)
            {
                newFormula = value;
            }

            if (newFormula != formula)
            {
                formula = newFormula;
                UpdateUI();
            }
        }
    }

    private void UpdateUI()
    {
        // TODO
    }

    public void OnCraftButton()
    {

    }
}
