using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGateWormHole : MonoBehaviour, IInteraction
{
    public StarGate Gate;
    public Transform endPoint;
    public GameObject player;

    public void Use()
    {
        player.GetComponent<PlayerController>().DisableInput = true;
        player.transform.position = endPoint.position;
        player.GetComponent<PlayerController>().DisableInput = false;
    }
}
