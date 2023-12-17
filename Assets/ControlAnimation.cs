using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private Rigidbody[] rbs;

    private void Start()
    {
        rbs = GetComponentsInChildren<Rigidbody>();
    }

    public void Freeze()
    {
        animator.speed = 0;
    }

    public void Play()
    {
        animator.speed = 1;
    }

    public void Explode()
    {
        foreach (Rigidbody rb in rbs)
        {
            rb.isKinematic = false;
            rb.AddExplosionForce(10, Vector3.zero, 20, 1f, ForceMode.Impulse);
        }
    }
}