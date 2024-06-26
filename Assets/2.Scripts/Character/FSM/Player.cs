using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field:SerializeField] public PlayerSO Data { get; private set; }

    [field: Header("Animations")]
    public PlayerAnimationData animationData;
    public Animator animator;
    public PlayerController controller { get; private set; }
    public CharacterController characterController { get; private set; }
    public ForceReceiver forceReceiver { get; private set; }
    private PlayerStateMachine stateMachine;
    void Awake()
    {
        animationData = new PlayerAnimationData();
        animationData.Initialize();
        animator = GetComponent<Animator>();
        controller = GetComponent<PlayerController>();
        characterController = GetComponent<CharacterController>();
        stateMachine = new PlayerStateMachine(this);
        stateMachine.ChangeState(stateMachine.playerIdleState);
        forceReceiver = GetComponent<ForceReceiver>();
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
