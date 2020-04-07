using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Access : Item
{
    
    
    public int DoorID; // ID of the Door that this items should open

   

    public Item_Access(string newName, float newWeight, int newDoorID) : base(newName, newWeight)
    {
        this.DoorID = newDoorID;
        
    }
}
