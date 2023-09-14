using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    public PlayerMoveState(PlayerStateMachine stateMachine) : base(stateMachine) { }
    public override void Enter()
    {
       
    }

    public override void Exit()
    {
        
    }

    public override void Run()
    {       
        CalculateMoveDirection();
        FaceMoveDirection();
        Move();
    }
}
