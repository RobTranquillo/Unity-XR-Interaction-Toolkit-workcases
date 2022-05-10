using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Button is an XR element that behaves like a light switch where you can choose between two different states.
/// The button can be set up for one-time or repeatable use.
/// For a behaviour more like a trigger look for XRTrigger.
/// </summary>
public class XRButton : XRSimpleInteractable
{
    [Header("Button Settings")]
    public GameObject buttonMovable;

    public float buttonTravel;

    public bool pressedOnStart = false;

    [Tooltip("If the button is resetable, a second aktivation pushes de button back to its former state.")]
    public bool resetable = true;

    private Vector3 upPosition;
    private Vector3 downPosition;

    private void Start()
    {
        upPosition = buttonMovable.transform.position;
        downPosition = upPosition;
        downPosition.y -= buttonTravel;

        if (pressedOnStart)
        {
            ButtonDown();
            activated.AddListener(ButtonUp);
        }
        else
            activated.AddListener(ButtonDown);
    }

    private void ButtonDown(ActivateEventArgs args)
    {
        ButtonDown();
    }

    private void ButtonDown()
    {
        buttonMovable.transform.position = downPosition;
        if (resetable)
        {
            activated.RemoveListener(ButtonDown);
            activated.AddListener(ButtonUp);
        }
    }

    private void ButtonUp(ActivateEventArgs args)
    {
        buttonMovable.transform.position = upPosition;

        if (resetable)
        {
            activated.RemoveListener(ButtonUp);
            activated.AddListener(ButtonDown);
        }
    }
}