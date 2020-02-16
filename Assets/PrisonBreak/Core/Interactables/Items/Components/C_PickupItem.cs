using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class C_PickupItem : MonoBehaviour, IInteraction
{
    public void Use()
    {
        if (Inventory.inst.AddItem(CreateItem()))
        {
            Destroy(this.gameObject);
        }
    }

    protected abstract Item CreateItem();
}
