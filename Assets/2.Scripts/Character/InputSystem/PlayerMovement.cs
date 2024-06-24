using System;
using System.Collections;
using System.Linq;
using System.Threading;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;



public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float jumpPower;
    private Vector2 curMovementInput;
    private Vector2 prevMovementInput;
    public LayerMask groundLayerMask;

    private Rigidbody rigidbody;

    [Header("Look")]
    public Transform cameraContainer;
    public float minXLook;
    public float maxXLook;
    private float camCurXRot;
    public float lookSensitivity;
    private Vector2 mouseDelta;
    public bool canLook = true;

    [Header("Animatior")]
    private Animator animator;
    public Transform player;


    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rigidbody = GetComponent<Rigidbody>();

    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        animator.SetBool("Idle", true);
    }

    void FixedUpdate()
    {
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        Move(isRunning);

        Vector3 cameraForward = cameraContainer.forward;
        cameraForward.y = 0;

        Vector3 moveDirection = Quaternion.Euler(0, cameraContainer.eulerAngles.y, 0) * new Vector3(curMovementInput.x, 0, curMovementInput.y);

        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, targetRotation, 0.15f);
        }
    }

    private void LateUpdate()
    {
         CameraLook();       
    }

    void Move(bool isRunning)
    {
        float currentSpeed = moveSpeed;
        if (isRunning)
        {
            animator.SetBool("Run",true);
            currentSpeed *= 2;
        }
        else
        {
            animator.SetBool("Run", false);
        }
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= currentSpeed * Time.deltaTime;
        Vector3 targetPosition = transform.position + dir;
        rigidbody.MovePosition(targetPosition);
    }

    void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);
        float yRotation = transform.localEulerAngles.y + mouseDelta.x * lookSensitivity;
        transform.localEulerAngles = new Vector3(0, yRotation, 0);
    }


    public void OnMove_(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
            prevMovementInput = curMovementInput;
            animator.SetBool("Walk", true);
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
            animator.SetBool("Walk", false);
        }
    }

    public void OnLook_(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    public void OnJump_(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && (IsGrounded()))
        {
            animator.SetBool("Jump", true);
            rigidbody.AddForce(Vector2.up * (jumpPower), ForceMode.Impulse);
        }
    }

    public void OnHanging_(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && (IsHanging()))
        {
            animator.SetBool("Hanging", true);
            
        }
    }

    bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) +(transform.up * 0.01f), Vector3.down)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 1f, groundLayerMask))
            {
                return true;
            }
        }
        return false;
    }

    bool IsHanging()
    {
        Vector3 headDirection = player.transform.up + transform.forward * 0.2f;

        Ray[] rays = new Ray[4]
        {
        new Ray(transform.position + headDirection, Vector3.down),
        new Ray(transform.position - headDirection, Vector3.down),
        new Ray(transform.position + transform.right * 0.2f, Vector3.down),
        new Ray(transform.position - transform.right * 0.2f, Vector3.down)
        };
        for (int i = 0; i < rays.Length; i++)
        {
            RaycastHit hitInfo;
            bool isHit = Physics.Raycast(rays[i], out hitInfo, 1f, groundLayerMask);


            Color rayColor = isHit ? Color.green : Color.red; 
            Debug.DrawRay(rays[i].origin, rays[i].direction * 1f, rayColor);

            if (isHit)
            {
                return true;
            }
        }
        return false;
    }
}
