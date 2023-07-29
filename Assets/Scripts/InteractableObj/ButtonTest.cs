using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : Interactable
{
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
        Destroy(this.gameObject);
    }
}
