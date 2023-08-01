using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        SceneManager.LoadScene("Win_Scene");
    } 
}
