using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class PlayerStateMachine : StateMachine
{
    public float MovementSpeed { get; private set; } = 5f;
    public float JumpForce { get; private set; } = 5f;
    public InputReader InputReader { get; private set; }
}
