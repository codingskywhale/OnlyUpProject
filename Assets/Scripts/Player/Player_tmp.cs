using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_tmp : MonoBehaviour
{
    public PlayerMovement movementController;

    private void Awake()
    {
        movementController = GetComponent<PlayerMovement>();
        if (GameManager.Instance.player == null)
        {
            GameManager.Instance.player = this;
        }
    }
}
