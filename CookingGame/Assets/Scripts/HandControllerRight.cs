using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(ActionBasedController))]
public class HandControllerRight : MonoBehaviour
{
    ActionBasedController controller;
    public Hand hand;
    void Start()
    {
        controller = GetComponent<ActionBasedController>();
    }

    void Update()
    {
        hand.SetGripRight(controller.selectAction.action.ReadValue<float>());
        hand.SetTriggerRight(controller.activateAction.action.ReadValue<float>());
    }

   
}








