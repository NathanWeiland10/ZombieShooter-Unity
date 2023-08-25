using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class RendererAnimator : MonoBehaviour
{
    Vector2 movement;
    public Animator animator;

    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(movement.x) + Mathf.Abs(movement.y));

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

    }
}
