using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Bonus : Item
{
    // amount of score that the player can receive from this item.
    int Points;

    public Item_Bonus(string newName, float newWeight, int newPoints) : base(newName, newWeight)
    {
        this.Points = newPoints;
    }
    
}
