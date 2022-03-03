using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VRHEADMAP
{
    public Transform vrTarget;
    public Transform rigTarget;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;

    public void Map()
    {
        rigTarget.position = vrTarget.TransformPoint(trackingPositionOffset);
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);
    }

}

public class VRHead : MonoBehaviour
{
    public VRHEADMAP head;
    public VRHEADMAP lefthand;
    public VRHEADMAP righthand;

    public Transform headConstraint;
    public Vector3 headBodyOffset;
    public float turnSmoothness;

    void Start()
    {
        headBodyOffset = transform.position - headConstraint.position;
    }

    void LateUpdate()
    {
        transform.position = headConstraint.position + headBodyOffset;
        //transform.forward = Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized;
        transform.forward = Vector3.Lerp(transform.forward,
            Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized, Time.deltaTime * turnSmoothness);

        head.Map();
        lefthand.Map();
        righthand.Map();
    }
}
