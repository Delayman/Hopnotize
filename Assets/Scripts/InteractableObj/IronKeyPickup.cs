using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronKeyPickup : Interactable
{
    private ItemStatus itemStatus;

    private void Start() 
    {
        itemStatus = FindObjectOfType<ItemStatus>();
    }

    public override string GetDescription()
    {
        return "Press [E] to Collect iron key";
    }

    public override void Interact()
    {
        Activate();
    }

    private void Activate()
    {
        itemStatus.CollectIronKey();

        Destroy(this.gameObject);
    }
}
