using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteraction
{
    [SerializeField]
    private int DoorId = 0;
    bool doorOpen;

    [SerializeField]
    private float openAmount = 0;
   
    private Vector3 OpenLocation;
    private Vector3 ClosedLocation;

    private void Awake()
    {
        ClosedLocation = transform.localPosition;
        
    }

    public void Use()
    {
        if(Inventory.inst.ContainsKey(DoorId) !=null)
        {
            Debug.Log("Opening Door");
            doorOpen = true;
            Inventory.inst.RemoveItem(Inventory.inst.ContainsKey(DoorId));
           
        }
        else
        {
            Debug.Log("Door is Locked");
            doorOpen = false;
        }
    }

    private void Update()
    {
        if (doorOpen)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, ClosedLocation + new Vector3(0, 0, openAmount), Time.deltaTime);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, ClosedLocation, Time.deltaTime);
        }
       
    }


   

}
