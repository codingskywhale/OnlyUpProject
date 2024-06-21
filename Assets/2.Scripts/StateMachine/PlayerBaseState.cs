using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerBaseState : IState
{
    protected PlayerStateMachine stateMachine;
    protected readonly PlayerGroundData groundData;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
        groundData = stateMachine.Player.Data.GroundData;
    }

    public virtual void Enter()
    {
        AddInputActionsCallbacks();
    }

    

    public virtual void Exit()
    {

    }
    protected virtual void AddInputActionsCallbacks()
    {
        PlayerController input = stateMachine.Player.controller;
    }

    public virtual void HandleInput()
    {
        ReadMovementInput();
    }

    public virtual void PhysicsUpdate()
    {
        
    }    

    public virtual void Update()
    {
        Move();
    }

    protected void StartAnimation(int animatorHash)
    {
        stateMachine.Player.animator.SetBool(animatorHash, true);
    }

    protected void StopAnimation(int animatorHash)
    {
        stateMachine.Player.animator.SetBool(animatorHash, false);
    }

    private void ReadMovementInput()
    {
        stateMachine.MovementInput = stateMachine.Player.controller.playerActions.Move.ReadValue<Vector2>();
    }


    private void Move()
    {
        Vector3 movementDirection = GetMovementDirection();

        Move(movementDirection);

        Rotate(movementDirection);

    }

    private Vector3 GetMovementDirection()
    {
        Vector3 forward = stateMachine.MainCamTransform.forward;
        Vector3 right = stateMachine.MainCamTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        forward.Normalize();

        return forward * stateMachine.MovementInput.y + right * stateMachine.MovementInput.x;
    }

    private void Move(Vector3 direction)
    {
        float movementSpeed = GetMovementSpeed();
        stateMachine.Player.characterController.Move((direction * movementSpeed) * Time.deltaTime);
    }

    private float GetMovementSpeed()
    {
        float moveSpeed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;

        return moveSpeed;
    }

    private void Rotate(Vector3 direction)
    {
        if(direction != Vector3.zero)
        {
            Transform playerTransform = stateMachine.Player.transform;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, stateMachine.RotationDamping * Time.deltaTime);
        }
    }
}
