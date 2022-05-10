using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Trigger is an XR element that behaves like a morse device, if its get pressed it sends an impulse and get back to its former state.
/// For a behaviour more like a switch look for XRButton.
/// </summary>
public class XRTrigger : XRSimpleInteractable
{
    [Header("Trigger Settings")]
    public GameObject triggerMovable;

    public float triggerTravel;

    [Tooltip("After this time the trigger is resetet to its default state")]
    public float releaseDelay = 0.1f;

    [Tooltip("Normally the button get pushed inside, inverse let it came out on activation")]
    public bool inversePositions;

    [Tooltip("Trigger will be reset when the controller leaves the button.")]
    public bool resetOnHoverExit = true;

    [Tooltip("Trigger will be reset after release of the controller trigger")]
    public bool resetOnSelectExit = true;

    private Vector3 upPosition;
    private Vector3 downPosition;

    private void Start()
    {
        upPosition = triggerMovable.transform.position;
        downPosition = upPosition;
        downPosition.y -= triggerTravel;

        if (inversePositions)
        {
            TriggerDown();
            activated.AddListener(TriggerUp);
        }
        else
            activated.AddListener(TriggerDown);

        if (resetOnHoverExit)
            hoverExited.AddListener(UnsetTrigger);
        if (resetOnHoverExit)
            selectExited.AddListener(UnsetTrigger);
    }

    private void UnsetTrigger(SelectExitEventArgs arg0)
    {
        UnsetTrigger();
    }

    private void UnsetTrigger(HoverExitEventArgs arg0)
    {
        UnsetTrigger();
    }

    private void UnsetTrigger()
    {
        if (!inversePositions)
            Invoke("TriggerUp", releaseDelay);
        else
            Invoke("TriggerDown", releaseDelay);
    }

    private void TriggerDown(ActivateEventArgs args)
    {
        TriggerDown();
    }

    private void TriggerDown()
    {
        triggerMovable.transform.position = downPosition;
    }

    private void TriggerUp(ActivateEventArgs args)
    {
        TriggerUp();
    }

    private void TriggerUp()
    {
        triggerMovable.transform.position = upPosition;
    }
}