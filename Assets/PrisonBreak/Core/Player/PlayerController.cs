using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxDist;
    public float speed;

    RaycastHit hit;
    CharacterController Controller = null;
    
    public Camera playerCam;
    public bool DisableInput;

    private void Awake()
    {
        Controller = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!DisableInput)
        {

        
            PlayerMovement();
            CastInteractionRay();

            if (Input.GetKeyDown(KeyCode.E))
            {
             Interact();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Inventory.inst.PrintItemsToLog();
            }
        }
    }


    void CastInteractionRay()
    {
        
        Ray ray = new Ray(playerCam.transform.position, playerCam.transform.forward * maxDist + playerCam.transform.position);
        Debug.DrawRay(playerCam.transform.position, playerCam.transform.forward * maxDist + playerCam.transform.position, Color.red);
        Physics.Raycast(ray, out hit, 8);
        
    }
    void Interact()
    {
        Debug.Log(hit.collider.gameObject.ToString());
        IInteraction Interface = hit.collider.gameObject.GetComponent<IInteraction>();
        if (Interface != null)
        {
            Interface.Use();
        }
    }


    void PlayerMovement()
    {
        float HorizontalAxis = Input.GetAxis("Horizontal");
        float VerticalAxis = Input.GetAxis("Vertical");
        float MouseAxisHor = Input.GetAxis("Mouse X");
        float MouseAxisVert = Input.GetAxis("Mouse Y");

        
        //Move player to left or right
        Controller.Move(transform.forward * VerticalAxis / 100 * speed);
        Controller.Move(transform.right * HorizontalAxis / 100 * speed);

        //Rotate Player and CameraBoom for Camera Control
        transform.Rotate(Vector3.up, MouseAxisHor * 10);
        playerCam.transform.Rotate(Vector3.right, MouseAxisVert * -1 * 10);       
    }
}
