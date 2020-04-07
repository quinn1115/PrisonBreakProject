using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item
{
    
    public string Name = "Default Name";
    public float Weight = 1.0f;
    public Image InventoryTexture;

    public Item(string name, float weight)
    {
        this.Name = name;
        this.Weight = weight;
        
    }
  
}
