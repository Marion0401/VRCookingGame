using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hand : MonoBehaviour
{
    Animator animator;
    private float gripTargetRight;
    private float triggerTargetRight;

    private float gripCurrentRight;
    private float triggerCurrentRight;


    private float gripTargetLeft;
    private float triggerTargetLeft;

    private float gripCurrentLeft;
    private float triggerCurrentLeft;


    public float speed;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        AnimateHand();
    }

    internal void SetTriggerLeft(float v)
    {
        gripTargetLeft = v;
    }

    internal void SetGripLeft(float v)
    {
        triggerTargetLeft = v;
    }

    internal void SetTriggerRight(float v)
    {
        gripTargetRight = v;
    }

    internal void SetGripRight(float v)
    {
        triggerTargetRight = v;
    }


    void AnimateHand()
    {
        if (gripCurrentLeft != gripTargetLeft)
        {
            gripCurrentLeft = Mathf.MoveTowards(gripCurrentLeft, gripTargetLeft, Time.deltaTime * speed);
            animator.SetFloat("GripLeft", gripCurrentLeft);

        }

        if (triggerCurrentLeft != triggerTargetLeft)
        {
            triggerCurrentLeft = Mathf.MoveTowards(triggerCurrentLeft, triggerTargetLeft, Time.deltaTime * speed);
            animator.SetFloat("TriggerLeft", triggerCurrentLeft);
        }

        if (gripCurrentRight != gripTargetRight)
        {
            gripCurrentRight = Mathf.MoveTowards(gripCurrentRight, gripTargetRight, Time.deltaTime * speed);
            animator.SetFloat("GripRight", gripCurrentRight);

        }

        if (triggerCurrentRight != triggerTargetRight)
        {
            triggerCurrentRight = Mathf.MoveTowards(triggerCurrentRight, triggerTargetRight, Time.deltaTime * speed);
            animator.SetFloat("TriggerRight", triggerCurrentRight);
        }
    }
}
