using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldKeyPickUp : Interactable
{
    private ItemStatus itemStatus;

    private void Start() 
    {
        itemStatus = FindObjectOfType<ItemStatus>();
    }

    public override string GetDescription()
    {
        return "Press [E] to Collect golden key";
    }

    public override void Interact()
    {
        Activate();
    }

    private void Activate()
    {
        itemStatus.CollectGoldKey();
        
        Destroy(this.gameObject);
    }
}
