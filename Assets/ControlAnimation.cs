using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAnimation : MonoBehaviour
{
    [SerializeField]private Animator animator;

    public void Freeze()
    {
        animator.speed = 0;
    }
    
    public void Play()
    {
        animator.speed = 1;
    }
}
