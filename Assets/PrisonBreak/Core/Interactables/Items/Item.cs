using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{

    public string Name = "Default Name";
    public float Weight = 1.0f;

    public Item(string name, float weight)
    {
        this.Name = name;
        this.Weight = weight;
    }
  
}
