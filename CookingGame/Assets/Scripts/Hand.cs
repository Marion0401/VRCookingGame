using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hand : MonoBehaviour
{
    Animator animator;
    private float gripTarget;
    private float triggerTarget;

    private float gripCurrent;
    private float triggerCurrent;
    public float speed;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        AnimateHand();
    }

    internal void SetTrigger(float v)
    {
        gripTarget = v;
    }

    internal void SetGrip(float v)
    {
        triggerTarget = v;
    }

    void AnimateHand()
    {
        if (gripCurrent != gripTarget)
        {
            gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * speed);
            animator.SetFloat("Grip", gripCurrent);

        }

        if (triggerCurrent != triggerTarget)
        {
            triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * speed);
            animator.SetFloat("Trigger", triggerCurrent);
        }
    }
}
