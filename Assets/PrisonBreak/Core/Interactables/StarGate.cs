using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGate : MonoBehaviour, IInteraction
{
    public int partsNeeded = 0;
    [HideInInspector]
    public bool gateEnabled = false;

    [SerializeField]
    private Material GateOnMaterial = null;
    [SerializeField]
    private GameObject wormHole = null;

    public void Use()
    {       
        if (Inventory.inst.CheckGateParts() >= partsNeeded)
        {
            var Mats = gameObject.GetComponent<MeshRenderer>().materials;
            Mats[3] = GateOnMaterial;
            gameObject.GetComponent<MeshRenderer>().materials = Mats;
            wormHole.SetActive(true);
            gateEnabled = true;
            
        }
    }

   
}
