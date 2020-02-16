using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteraction
{
    [SerializeField]
    private int DoorId;

    public void Use()
    {
        if(Inventory.inst.ContainsKey(DoorId) !=null)
        {
            Debug.Log("Opening Door");
        }
        else
        {
            Debug.Log("Door is Locked");
        }
    }

}
