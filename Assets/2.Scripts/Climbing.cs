using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Climbing : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    private Rigidbody rb;
    public LayerMask wall;

    [Header("Climbing")]
    public float climbSpeed;
    public float maxClimbTime;
    public float climbTime;

    private bool climbing;
    private bool climbingCoolTime;

    [Header("Cooldown")]
    public float climbCooldown;
    public float climbCooldownTimer;

    [Header("Dection")]
    public float detectionLength;
    public float sphereCastRadius;
    public float maxWallLookAngle;
    private float wallLookAngle;

    private RaycastHit frontWallHit;
    private bool wallFront;
    private PlayerMovement playerMovement;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        WallCheck();
        StateMachine();
        if (climbing) ClimbingMovement();
    }
    public void StateMachine()
    {
        if (climbingCoolTime)
        {
            climbCooldownTimer -= Time.deltaTime;
            if (climbCooldownTimer <= 0) climbingCoolTime = false;
        }
        else if (wallFront && Input.GetKey(KeyCode.E) && wallLookAngle < maxWallLookAngle)
        {
            if (!climbing && climbTime > 0) StartClimbing();

            if (climbing)
            {
                if (climbTime > 0) climbTime -= Time.deltaTime;
                if (climbTime <= 0) StopClimbing();
            }
        }
        else
        {
            if (climbing) StopClimbing();
        }
    }

    private void WallCheck()
    {
        wallFront = Physics.SphereCast(transform.position, sphereCastRadius, player.forward, out frontWallHit, detectionLength, wall);
        wallLookAngle = Vector3.Angle(player.forward , -frontWallHit.normal);

        if (playerMovement.IsHanging())
        {
            climbTime = maxClimbTime;
        }
    }

    private void StartClimbing()
    {
        climbing = true;
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        animator.SetBool("Climbing", true);
    }

    private void ClimbingMovement()
    {
        Vector3 moveDirection = new Vector3(0, climbSpeed, 0);
        rb.velocity = moveDirection;
    }

    private void StopClimbing()
    {
        climbing = false;
        rb.useGravity = true;
        rb.velocity = Vector3.zero;
        StartCooldown();
        animator.SetBool("Climbing", false);
    }

    private void StartCooldown()
    {
        climbingCoolTime = true;
        climbCooldownTimer = climbCooldown;
    }

}
