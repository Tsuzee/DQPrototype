using System;

[Serializable]
public class CraftingFormula
{
    public ItemTemplate result = null;
    public ItemName material1 = ItemName.Null;
    public ItemName material2 = ItemName.Null;
    public ItemName material3 = ItemName.Null;
    
    public bool Valid()
    {
        return (null != result && material1 != ItemName.Null);
    }
}
