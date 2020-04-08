using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour, IInteraction
{
    public int ElevatorID;
    public Transform TeleportLoc;
    public GameObject player;
    
    public void Use()
    {
        if (Inventory.inst.ContainsKey(ElevatorID) != null)
        {
            player.GetComponent<PlayerController>().DisableInput = true;
            player.transform.position = TeleportLoc.position;
           
            player.GetComponent<PlayerController>().DisableInput = false;
        }
    }
}
