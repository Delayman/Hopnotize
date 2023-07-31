using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : Interactable
{
    public Material activatedColor;
    public Material deActivatedColor;
    public bool isOn = false;

    private SafePuzzleController safeCtrl;

    private void Start() 
    {
        safeCtrl = FindObjectOfType<SafePuzzleController>();
    }

    public override string GetDescription()
    {
        return "Press [E] to press button";
    }

    public override void Interact()
    {
        isOn = !isOn;

        Activate();
    }

    private void Activate()
    {
        safeCtrl.CheckCorrection();

        this.GetComponent<Renderer>().material = isOn ? activatedColor : deActivatedColor;
    }
}
