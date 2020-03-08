using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : MonoBehaviour
{
    private bool DoorOpen;

    [SerializeField]
    private Vector3 OpenLocation;

    // Start is called before the first frame update
    void Start() => DoorOpen = false;


    // Update is called once per frame
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
