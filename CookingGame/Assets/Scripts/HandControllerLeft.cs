using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(ActionBasedController))]
public class HandControllerLeft : MonoBehaviour
{
    ActionBasedController controller;
    public Hand hand;
    void Start()
    {
        controller = GetComponent<ActionBasedController>();
    }

    void Update()
    {
        hand.SetGripLeft(controller.selectAction.action.ReadValue<float>());
        hand.SetTriggerLeft(controller.activateAction.action.ReadValue<float>());
    }

   
}








