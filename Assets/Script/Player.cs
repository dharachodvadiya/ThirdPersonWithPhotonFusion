using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Player : StateMachine, IPlayerLeft
{
    public static Player Local { get; set; }

    public GameObject objPlayer;         // player's reference
    public Collider collider;           //player's colider
   // public Rigidbody rigidbody;           //player's rigidbody
    public Transform transformCamera;   //followed camera reference
    public float MovementSpeed { get; private set; } = 5f;
    public float JumpForce { get; private set; } = 5f;
    public float LookRotationDampFactor { get; private set; } = 10f;
    public InputReader InputReader { get; set; }    //input system refeence

    [HideInInspector]
    public Vector3 PlayerLookDirection = Vector3.forward;   //current direction of player

    private void Start()
    {
        InputReader = GetComponent<InputReader>();
        SwitchState(new PlayerMoveState(this));

    }

    public override void Spawned()
    {
        if (Object.HasInputAuthority)
        {
            Local = this;

            Debug.Log("Spawned local player");
            Spawner.instance.myPlayer = this;
        }
        else
        {
            Destroy(transformCamera.gameObject);
            Debug.Log("Spawned remote player");
        }

    }

    public void PlayerLeft(PlayerRef player)
    {
        if (player == Object.InputAuthority)
        {
            Runner.Despawn(Object);
            
        }
           
    }
}
