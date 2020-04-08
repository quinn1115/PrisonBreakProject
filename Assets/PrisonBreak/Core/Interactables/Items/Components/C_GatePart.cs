using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_GatePart : C_PickupItem
{

    public string itemName;
    public int itemWeight;
    public Texture itemTexture;

    protected override Item CreateItem()
    {
        return new Item_Gate(itemName, itemWeight,itemTexture);
    }

    
}
