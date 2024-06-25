using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void JumpSetBool()
    {
        animator.SetBool("Jump", false);
    }

    public void StandSetBool()
    {
        animator.SetBool("StandUp", false);
    }
}
