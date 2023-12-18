using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform cameraAnchor;
    [SerializeField] private float rotationSpeed;

    private Rigidbody[] rbs;

    private bool rotateCam;

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

    public void FreezeAndRotate()
    {
        foreach (var rigidbody in rbs)
        {
            rigidbody.isKinematic = true;
        }

        Time.timeScale = 1f;
        rotateCam = true;
    }

    private void Update()
    {
        if (!rotateCam) return;
        
        cameraAnchor.Rotate(Vector3.up, Time.deltaTime * rotationSpeed);
    }
}