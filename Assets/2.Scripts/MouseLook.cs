using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    private float xRotation = 0f;
    private bool isMouseControlEnabled = true;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        ToggleMouseControl();

        if (isMouseControlEnabled)
        {
            LookAround();
        }
    }

    void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    void ToggleMouseControl()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            isMouseControlEnabled = !isMouseControlEnabled;
            Cursor.lockState = isMouseControlEnabled ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }
}
