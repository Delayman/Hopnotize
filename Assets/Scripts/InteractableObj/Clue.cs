using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clue : Interactable
{
    public GameObject cluePaper;
    public bool isOn = false;

    public override string GetDescription()
    {
        return "Press [E] to read";
    }

    public override void Interact()
    {
        isOn = !isOn;

        Activate();
    }

    private void Activate()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        cluePaper.SetActive(isOn);
        this.gameObject.GetComponent<BoxCollider>().enabled = !isOn;
    }

    public void Close()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        isOn = false;
        cluePaper.SetActive(isOn);
        this.gameObject.GetComponent<BoxCollider>().enabled = !isOn;
    }
}
