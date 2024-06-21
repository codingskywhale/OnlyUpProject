using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field:SerializeField] public PlayerSO Data { get; private set; }

    [field:Header("Animations")]
    [field:SerializeField]public PlayerAnimationData animationData { get; private set; }
    public Animator animator { get; private set; }
    public PlayerController controller { get; private set; }
    public CharacterController characterController { get; private set; }
    private PlayerStateMachine stateMachine;
    void Awake()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<PlayerController>();
        characterController = GetComponent<CharacterController>();
        stateMachine = new PlayerStateMachine(this);
        stateMachine.ChangeState(stateMachine.playerIdleState);
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        stateMachine.HandleInput();
        stateMachine.Update();
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }
}
