using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteraction
{
    [SerializeField]
    private int DoorId;
    bool doorOpen;

    [SerializeField]
    private Vector3 OpenLocation;
    private Vector3 ClosedLocation;

    private void Awake()
    {
        ClosedLocation = transform.position;
    }

    public void Use()
    {
        if(Inventory.inst.ContainsKey(DoorId) !=null)
        {
            Debug.Log("Opening Door");
            doorOpen = true;
            StartCoroutine(DoorDelay());
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
            transform.position = Vector3.Lerp(transform.position, OpenLocation, Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, ClosedLocation, Time.deltaTime);
        }
       
    }


    IEnumerator DoorDelay()
    {
        yield return new WaitForSeconds(15);
        doorOpen = false;
    }

}
