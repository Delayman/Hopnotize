using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronKeyPickup : Interactable
{
    
    public override string GetDescription()
    {
        return "press [E]";
    }

    public override void Interact()
    {
        Debug.Log($"Pickup {this.gameObject.name}");
        Activate();

    }

    private void Activate()
    {
        Destroy(this.gameObject);
    }
}
