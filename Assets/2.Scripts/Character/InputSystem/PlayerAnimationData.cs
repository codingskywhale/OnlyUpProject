using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class PlayerAnimationData
{
    [SerializeField] private string groundParameterName = "@Ground";
    [SerializeField] private string idleParameterName = "Idle";
    [SerializeField] private string walkParameterName = "Walk";
    [SerializeField] private string runParameterName = "Run";
    [SerializeField] private string airParameterName = "@Air";
    [SerializeField] private string jumpParameterName = "Jump";
    [SerializeField] private string fallParameterName = "Fall";

    public int GroundParameterHash {  get; private set; }
    public int IdleParameterHash { get; private set; }
    public int WalkParameterHash { get; private set; }
    public int RunParameterHash { get; private set; }
    public int AirParameterHash { get; private set; }
    public int JumpParameterHash { get; private set; }
    public int FallParameterHash { get; private set; }

    public void Initialize()
    {
        GroundParameterHash = Animator.StringToHash(groundParameterName);
        Debug.Log(GroundParameterHash);
        IdleParameterHash = Animator.StringToHash(idleParameterName);
        Debug.Log(IdleParameterHash);
        WalkParameterHash = Animator.StringToHash(walkParameterName);
        Debug.Log(WalkParameterHash);
        RunParameterHash = Animator.StringToHash(runParameterName);
        Debug.Log(RunParameterHash);

        AirParameterHash = Animator.StringToHash(airParameterName);
        Debug.Log(AirParameterHash);
        JumpParameterHash = Animator.StringToHash(jumpParameterName);
        Debug.Log(JumpParameterHash);
        FallParameterHash = Animator.StringToHash(fallParameterName);
        Debug.Log(FallParameterHash);

    }

}

