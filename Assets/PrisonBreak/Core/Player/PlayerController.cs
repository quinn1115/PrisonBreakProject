using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float maxDist;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CastMouseRay();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Interact();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Inventory.inst.PrintItemsToLog();
        }
    }


    void CastMouseRay()
    {
        
        Ray ray = (Camera.main.ScreenPointToRay(Input.mousePosition));
        Physics.Raycast(ray, out hit);
    }
    void Interact()
    {
        IInteraction Interface = hit.collider.gameObject.GetComponent<IInteraction>();
        if (Interface != null)
        {
            Interface.Use();
        }
    }
}
