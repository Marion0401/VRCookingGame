using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportManager : MonoBehaviour
{
    [Header("Left Hand Teleportation Controller")]
    [SerializeField] private XRRayInteractor rayInteractor;
    [SerializeField] private TeleportationProvider teleportationProvider;

    [SerializeField] private InteractionLayerMask TeleportationLayers;

    [SerializeField] private InputActionProperty teleportModeActivate;
    [SerializeField] private InputActionProperty teleportModeCancel;
    [SerializeField] private InputActionProperty thumMove;
    [SerializeField] private InputActionProperty GripModeActivate;

    private bool isTeleportationActivate;
    private InteractionLayerMask initialInteractionLayers;
    private List<IXRInteractable> interactables = new List<IXRInteractable>();

    void Start()
    {
        teleportModeActivate.action.Enable();
        thumMove.action.Enable();
        teleportModeCancel.action.Enable();
        GripModeActivate.action.Enable();

        teleportModeActivate.action.performed += OnTeleportActivate;
        teleportModeCancel.action.performed += OnTeleportCancel;

        initialInteractionLayers = rayInteractor.interactionLayers;
    }

    void Update()
    {
        if (!isTeleportationActivate)
            return;
        if (thumMove.action.triggered)
            return;
        rayInteractor.GetValidTargets(interactables);
        if (interactables.Count == 0 )
        {
            TurnOffTeleportation();
            return;
        }
        rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit);
        TeleportRequest request = new TeleportRequest();
        if (interactables[0].interactionLayers == 2 )
        {
            request.destinationPosition = hit.point;
        }
        else if (interactables[0].interactionLayers == 4)
        {
            request.destinationPosition = hit.transform.GetChild(0).transform.position;
        }

        teleportationProvider.QueueTeleportRequest(request);
        TurnOffTeleportation();
    }

    private void OnTeleportActivate(InputAction.CallbackContext obj)
    {
        if (GripModeActivate.action.phase != InputActionPhase.Performed)
        {
            isTeleportationActivate = true;
            rayInteractor.lineType = XRRayInteractor.LineType.ProjectileCurve;
            rayInteractor.interactionLayers = TeleportationLayers;
        }
    }

    private void OnTeleportCancel(InputAction.CallbackContext obj)
    {
        TurnOffTeleportation();
    }

    private void TurnOffTeleportation()
    {
        isTeleportationActivate = false;
        rayInteractor.lineType = XRRayInteractor.LineType.StraightLine;
        rayInteractor.interactionLayers = initialInteractionLayers;
    }



}
