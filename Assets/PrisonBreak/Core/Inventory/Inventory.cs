using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static Inventory inst;

    private List<Item> InventoryItems;

    public float MaxWeight = 5f;
    public float CurrentWeight;



    private void Awake()
    {
        //if Instance already exists destroy new one else create new Instance.
        if (inst)
        {
            Destroy(this);
        }
        else
        {
            inst = this;
            DontDestroyOnLoad(this.gameObject);
        }

        InventoryItems = new List<Item>();
    }

    //Adds item to inventory + it's weight to the currentWeight value.
    public bool AddItem(Item item)
    {
        if (CurrentWeight + item.Weight > MaxWeight)
        {
            Debug.Log("Inventory full");
            return false;
        }
        else
        {
            InventoryItems.Add(item);
            CurrentWeight += item.Weight;
            return true;
        }
    }

    //Removes Item + item Weight.
    public void RemoveItem(Item item)
    {
        
       if(InventoryItems.Remove(item))
       {
            CurrentWeight -= item.Weight;
            Debug.Log(item + " has been removed");
       }
       else
       {
            Debug.Log("Could not Remove Item");
            return;
       }
       return;
    }

    //Check for key 
    public Item_Access ContainsKey(int DoorID)
    {

        foreach (Item_Access item in InventoryItems)
        {
            if (item.DoorID == DoorID)
            {
                return item;
            }
            
            
        }
        return null;

    }

    //Prints all Items in the inventory to the log
    public void PrintItemsToLog()
    {
        foreach (Item item in InventoryItems)
        {
            Debug.Log(item.Name + " Item Weight: " + item.Weight);
        }
        Debug.Log("Current Inventory Weight: " + CurrentWeight + "/" + MaxWeight);
    }
}
