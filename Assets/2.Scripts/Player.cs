using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field:Header("Animations")]
    [field:SerializeField]public PlayerAnimationData animationData { get; private set; }
    public Animator animator { get; private set; }
    public PlayerController controller { get; private set; }
    public CharacterController characterController { get; private set; }

    void Awake()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<PlayerController>();
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
