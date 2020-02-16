using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Access : Item
{
    // ID of the Door that this items should open
   public int DoorID;

    public Item_Access(string newName, float newWeight, int newDoorID) : base(newName, newWeight)
    {
        this.DoorID = newDoorID;
    }
}
