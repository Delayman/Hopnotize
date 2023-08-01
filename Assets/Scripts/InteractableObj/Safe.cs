using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : Interactable
{
    [SerializeField] private GameObject button;
    private ItemStatus itemStatus;
    private Dialogue dialogue;

    private void Start() 
    {
        itemStatus = FindObjectOfType<ItemStatus>();
        dialogue = FindObjectOfType<Dialogue>();
    }

    public override string GetDescription()
    {
        return "Press [E] to open safe";
    }

    public override void Interact()
    {
        Activate();
    }

    private void Activate()
    {
        if(itemStatus.ironKeyCount < 2)
        {
            dialogue.StartCoroutine(dialogue.CantOpenTextNarrator());
            return;
        }

        this.gameObject.GetComponent<BoxCollider>().enabled = false;

        button.SetActive(true);
    }
}
