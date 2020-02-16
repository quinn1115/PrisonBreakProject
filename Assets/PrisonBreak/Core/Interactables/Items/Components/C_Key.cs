using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Key : C_PickupItem
{
    public int doorId;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override Item CreateItem()
    {
        return new Item_Access("Key", 1, doorId);
    }
}
