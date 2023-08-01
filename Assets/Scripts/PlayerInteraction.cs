using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance;

    public TextMeshProUGUI interactionText;

    public Camera cam;

    int mapLayer = 7;
    int btnLayer = 6;
    private int layerAsLayerMask;


    private void Start()
    {
        interactionText = GameObject.FindGameObjectWithTag("InteractTextField").GetComponent<TextMeshProUGUI>();

        layerAsLayerMask = (1 << mapLayer);
        layerAsLayerMask |= (1 << btnLayer); 
    }

    private void Update()
    {
        var ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));

        var successfulHit = false;
        
        if (Physics.Raycast(ray, out var _hit, interactionDistance ,layerAsLayerMask))
        {
            var interactable = _hit.collider.GetComponent<Interactable>();
            var objCheck = _hit.collider.gameObject;
            
            if (interactable != null)
            {
                interactionText.text = interactable.GetDescription();
                HandleInteraction(interactable);
                successfulHit = true;
            }
        }

        if (!successfulHit && interactionText != null)
        {
            interactionText.text = "";
        }
    }

    private void HandleInteraction(Interactable interactable)
    {
        const KeyCode key = KeyCode.E;

        switch (interactable.interactionType)
        {
            case Interactable.InteractionType.Click:
                if (Input.GetKeyDown(key))
                {
                    interactable.Interact();
                }
                break;
            case Interactable.InteractionType.Hold:
                if (Input.GetKey(key))
                {
                    interactable.IncreaseHoldTime();
                    if (interactable.GetHoldTime() > 1f) 
                    {
                        interactable.Interact();
                        interactable.ResetHoldTime();
                    }
                }
                else
                {
                    interactable.ResetHoldTime();
                }
                break;
            default:
                throw new System.Exception("Unsupported type of interactable.");
        }
    }
}