using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player_ Player { get; }
    public Vector2 MovementInput { get; set; }
    public float MovementSpeed { get; private set; }
    public float RotationDamping { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1f;
    public float JumpForce { get; set; }

    public Transform MainCamTransform { get; set; }

    public PlayerIdleState playerIdleState { get; private set; }
    public PlayerWalkState playerWalkState { get; private set; }
    public PlayerRunState playerRunState { get; private set; }
    public PlayerJumpState playerJumpState { get; private set; }

    public PlayerStateMachine(Player_ player)
    {
        this.Player = player;
        MainCamTransform = Camera.main.transform;

        playerIdleState = new PlayerIdleState(this);
        playerWalkState = new PlayerWalkState(this);
        playerRunState = new PlayerRunState(this);
        playerJumpState = new PlayerJumpState(this);
        MovementSpeed = player.Data.GroundData.BaseSpeed;
        RotationDamping = player.Data.GroundData.BaseRotation;
    }
   
}
