using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDoor : Interactable
{
    private ItemStatus itemStatus;
    private Dialogue dialogue;

    private void Start() 
    {
        itemStatus = FindObjectOfType<ItemStatus>();
    }

    public override string GetDescription()
    {
        return "Press [E] to open";
    }

    public override void Interact()
    {
        Activate();
    }

    private void Activate()
    {
        if(!itemStatus.isCollectGoldKey)
        {
            dialogue.StartCoroutine(dialogue.CantOpenTextNarrator());
            return;
        }

        Debug.Log("yay");
    
        //Change to you win screen
    } 
}
