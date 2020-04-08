using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory inst;
    public float maxWeight = 5f;
    public float currentWeight;
    public PlayerProfile playerStats;
   
    [SerializeField]
    private GameObject itemSlotPrefab = null;
    private List<Item> InventoryItems;
    [SerializeField]
    private GameObject inventoryPanel = null;
    

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
        if (currentWeight + item.Weight > maxWeight)
        {
            Debug.Log("Inventory full");
            return false;
        }
        else
        {
                InventoryItems.Add(item);
                AddVisualItemSlot(item);
                currentWeight += item.Weight;

                if(item is Item_Bonus)
                {
                playerStats.AddPoints(10);
                }
                return true;
          
        }
    }

    //Removes Item + item Weight.
    public void RemoveItem(Item item)
    {
       if(InventoryItems.Remove(item))
       {
            currentWeight -= item.Weight;
            RemoveVisualItemSlot(item);
            Debug.Log(item.Name + " has been removed");
       }
       else
       {
            Debug.Log("Could not Remove Item");
            return;
       }
       return;
    }

    //Add Visual From Inventory
    public void AddVisualItemSlot(Item item)
    {
        GameObject newSlot = (GameObject)Instantiate(itemSlotPrefab, inventoryPanel.transform,false);
        newSlot.GetComponent<RawImage>().texture = item.InventoryTexture;
        newSlot.GetComponent<RectTransform>().localPosition = new Vector3(newSlot.GetComponent<RectTransform>().localPosition.x, newSlot.GetComponent<RectTransform>().localPosition.y, 0);
        item.itemSlot = newSlot;
    }
    
    //Remove Visual From Inventory
    public void RemoveVisualItemSlot(Item item)
    {
        Destroy(item.itemSlot.gameObject);
    }

    //Check for key 
    public Item_Access ContainsKey(int UnlockId)
    {

        for (int x = 0; x < InventoryItems.Count; x++)
        {
            if (InventoryItems[x] is Item_Access)
            {
                Item_Access a = (Item_Access)InventoryItems[x];
                if(a.UnlockID == UnlockId)
                {
                    return a;
                }
                
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
        Debug.Log("Current Inventory Weight: " + currentWeight + "/" + maxWeight);
    }

    //Check for GateParts
    public int CheckGateParts()
    {
        int i = 0;
        
            for (int x = 0; x < InventoryItems.Count; x++)
            {
                if (InventoryItems[x] is Item_Gate)
                {
                    i++;
                }
            }
        return i;
    }
}
