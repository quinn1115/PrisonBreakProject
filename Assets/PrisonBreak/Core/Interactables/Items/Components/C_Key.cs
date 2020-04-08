using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Key : C_PickupItem
{
    public string itemName;
    public int itemWeight;
    public int doorId;
    public Texture itemTexture;

    protected override Item CreateItem()
    {
        return new Item_Access(itemName, itemWeight, doorId, itemTexture);
    }
}
