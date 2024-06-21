using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceReceiver : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;

    private float vertiaclVelocity;

    public Vector3 Movement => Vector3.up * vertiaclVelocity;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if(characterController.isGrounded) 
        { 
            vertiaclVelocity = Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            vertiaclVelocity += Physics.gravity.y * Time.deltaTime;
        }
    }

    public void Jump(float jumpForce)
    {
        vertiaclVelocity += jumpForce;
    }
}
