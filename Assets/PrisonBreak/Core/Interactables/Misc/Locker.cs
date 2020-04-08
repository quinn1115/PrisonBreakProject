using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : MonoBehaviour
{
    private bool DoorOpen = false;

    [SerializeField]
    private Vector3 OpenLocation = new Vector3(0,0,0);

    void Start() => DoorOpen = false;

    void Update()
    {
        if (DoorOpen)
        {
            transform.position = Vector3.Lerp(transform.position, OpenLocation, Time.deltaTime);
        }
    }

   public void Open()
    {
        DoorOpen = true;
    }
}
