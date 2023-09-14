using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class PlayerStateMachine : StateMachine
{
    public GameObject objPlayer;         // player's reference
    public Collider collider;           //player's colider
    public Transform transformCamera;   //followed camera reference
    public float MovementSpeed { get; private set; } = 5f;
    public float JumpForce { get; private set; } = 5f;
    public float LookRotationDampFactor { get; private set; } = 10f;
    public InputReader InputReader { get; private set; }    //input system refeence

    [HideInInspector]
    public Vector3 PlayerLookDirection = Vector3.forward;   //current direction of player

    private void Start()
    {
        InputReader = GetComponent<InputReader>();
        SwitchState(new PlayerMoveState(this));
    }
}
