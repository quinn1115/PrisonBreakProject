using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [HideInInspector]
    public bool DisableInput;

    [SerializeField]
    private float maxDist = 100;
    [SerializeField]
    private float speed = 2;
    [SerializeField]
    private float rotSpeed = 2;
    [SerializeField]
    private Camera playerCam = null;
    [SerializeField]
    private Canvas InventoryCanvas = null;
    [SerializeField]
    private Canvas HudCanvas = null;

    private CharacterController cc;
    private RaycastHit hit;
    private float MouseAxisHor;
    private float MouseAxisVert;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
    }

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

            if (Input.GetKeyDown(KeyCode.I))
            {
                OpenInventory();
            }
        }
    }

    void CastInteractionRay()
    {
        Ray ray = new Ray(playerCam.transform.position, (playerCam.transform.forward * maxDist));
        Debug.DrawRay(playerCam.transform.position, (playerCam.transform.forward * maxDist), Color.red);
        Physics.Raycast(ray, out hit, 8);
    }

    void Interact()
    {
      if(hit.collider != null)
      {
            IInteraction Interface = hit.collider.gameObject.GetComponent<IInteraction>();

            if (Interface != null)
            {
                Interface.Use();
            }
      }
    }

    void OpenInventory()
    {
        DisableInput = true;
        HudCanvas.gameObject.SetActive(false);
        InventoryCanvas.gameObject.SetActive(true);
    }

    public void CloseInventory()
   {
        DisableInput = false;
        HudCanvas.gameObject.SetActive(true);
        InventoryCanvas.gameObject.SetActive(false);
   }
    
    void PlayerMovement()
    {
        //Movement Axis
        float HorizontalAxis = Input.GetAxis("Horizontal") * speed;
        float VerticalAxis = Input.GetAxis("Vertical") * speed;

        //Rotation Axis
        MouseAxisHor += Input.GetAxis("Mouse X") * rotSpeed;
        MouseAxisVert += Input.GetAxis("Mouse Y") * rotSpeed;
        MouseAxisVert = Mathf.Clamp(MouseAxisVert, -90, 90);

        //Player Movement
        cc.Move(transform.forward * VerticalAxis * Time.deltaTime );
        cc.Move(transform.right * HorizontalAxis * Time.deltaTime);
        cc.Move(-transform.up * 9.81f * Time.deltaTime);
        
        
        //Camera Rotation
        transform.rotation = Quaternion.Euler(0f, MouseAxisHor, 0f);
        playerCam.transform.localRotation = Quaternion.Euler(-MouseAxisVert, 0f, 0f);     
    }
}
