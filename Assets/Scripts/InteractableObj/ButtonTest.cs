using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : Interactable
{
    public Material activatedColor;
    public override string GetDescription()
    {
        return "press [E]";
    }

    public override void Interact()
    {
        Debug.Log("Heyyyy");
        Activate();

    }

    private void Activate()
    {
        this.GetComponent<Renderer>().material = activatedColor;
    }
}