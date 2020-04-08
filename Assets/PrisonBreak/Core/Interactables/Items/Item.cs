using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item
{
    
    public string Name = "Default Name";
    public float Weight = 1.0f;
    public Texture InventoryTexture;
    public GameObject itemSlot;
    

    public Item(string name, float weight, Texture itemTexture)
    {
        this.Name = name;
        this.Weight = weight;
        this.InventoryTexture = itemTexture;
    }
  
}
