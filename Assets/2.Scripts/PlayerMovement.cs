using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float runSpeed;
    public float jumpForce;

    private Rigidbody rb;
    private bool isGrounded;

    AudioSource audioSource;
    public AudioClip clip;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = move * runSpeed + new Vector3(0, rb.velocity.y, 0);
        }
        else
        {
            rb.velocity = move * moveSpeed + new Vector3(0, rb.velocity.y, 0);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            audioSource.PlayOneShot(clip);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
