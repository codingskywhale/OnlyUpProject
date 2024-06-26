using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWalkState : PlayerGroundState
{
    public PlayerWalkState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = groundData.WalkSpeedModifier;
        base.Enter();
        StartAnimation(stateMachine.Player.animationData.WalkParameterHash);
    }

    public override void Exit() 
    { 
        base.Exit();
        StopAnimation(stateMachine.Player.animationData.WalkParameterHash);
    }

    protected override void OnRunStartd(InputAction.CallbackContext context)
    {
        base.OnRunStartd(context);
        stateMachine.ChangeState(stateMachine.playerRunState);
    }
}
