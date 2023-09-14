using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected readonly PlayerStateMachine stateMachine;     //player's reference
    private Vector3 colExtents;                             //player's colider reference

    protected PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
        colExtents = stateMachine.collider.bounds.extents;
    }

    //check player is on the ground or not
    protected bool IsGrounded()
    {
        Ray ray = new Ray(stateMachine.objPlayer.transform.position + Vector3.up * 2 * colExtents.x, Vector3.down);
        return Physics.SphereCast(ray, colExtents.x, colExtents.x + 0.2f);
    }
    // calculate the player move direction
    protected void CalculateMoveDirection()
    {
        Vector3 cameraForward = new(stateMachine.transformCamera.forward.x, 0, stateMachine.transformCamera.forward.z);
        Vector3 cameraRight = new(stateMachine.transformCamera.right.x, 0, stateMachine.transformCamera.right.z);

        Vector3 moveDirection = cameraForward.normalized * stateMachine.InputReader.MoveComposite.y + cameraRight.normalized * stateMachine.InputReader.MoveComposite.x;

        stateMachine.PlayerLookDirection.x = moveDirection.x * stateMachine.MovementSpeed;
        stateMachine.PlayerLookDirection.z = moveDirection.z * stateMachine.MovementSpeed;
    }

    // rotate player on calculated direction
    protected void FaceMoveDirection()
    {
        Vector3 faceDirection =stateMachine.PlayerLookDirection;
        faceDirection.y = 0;

        if (faceDirection == Vector3.zero)
            return;

        stateMachine.transform.rotation = Quaternion.Slerp(stateMachine.transform.rotation, Quaternion.LookRotation(faceDirection), stateMachine.LookRotationDampFactor * Time.deltaTime);
    }

    //move player to the target direction
    protected void Move()
    {
        stateMachine.transform.position += stateMachine.PlayerLookDirection * Time.deltaTime * stateMachine.MovementSpeed;

    }

}
