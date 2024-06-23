using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbableWall : MonoBehaviour
{
    public float climbSpeed = 3f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                playerRigidbody.useGravity = false;
                playerRigidbody.velocity = Vector3.zero;
                other.gameObject.AddComponent<ClimbingController>().Initialize(climbSpeed, playerRigidbody, transform);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ClimbingController climbingController = other.GetComponent<ClimbingController>();
            if (climbingController != null)
            {
                climbingController.StopClimbing();
                Destroy(climbingController);
            }
        }
    }
}

public class ClimbingController : MonoBehaviour
{
    private float climbSpeed;
    private Rigidbody playerRigidbody;
    private PlayerMovement playerMovement;
    private Transform wallTransform;

    public void Initialize(float speed, Rigidbody rb, Transform wall)
    {
        climbSpeed = speed;
        playerRigidbody = rb;
        wallTransform = wall;
        playerMovement = rb.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * climbSpeed;
        float moveY = Input.GetAxis("Vertical") * climbSpeed;

        Vector3 right = wallTransform.right;
        Vector3 up = Vector3.up;

        Vector3 climbMovement = right * moveX + up * moveY;
        playerRigidbody.velocity = climbMovement;
    }

    public void StopClimbing()
    {
        playerRigidbody.useGravity = true;
        playerRigidbody.velocity = Vector3.zero;

        if (playerMovement != null)
        {
            playerMovement.enabled = true;
        }
    }
}
