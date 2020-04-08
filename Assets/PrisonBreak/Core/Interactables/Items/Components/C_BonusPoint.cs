using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_BonusPoint : C_PickupItem
{
    public string itemName;
    public Texture itemTexture; 
    protected override Item CreateItem()
    {
       
        return new Item_Bonus(itemName, 1, itemTexture);
    }
}
