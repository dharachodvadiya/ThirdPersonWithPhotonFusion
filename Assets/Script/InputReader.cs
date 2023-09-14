using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

public class InputReader : MonoBehaviour, IPlayerActions
{
   
    public Controls inputControls;
    private Action OnJumpPerformed;

    public Vector2 MoveComposite;
    public Vector2 MouseDelta;

    private void OnEnable()
    {
        if (inputControls == null)
        {
            inputControls = new Controls();
            inputControls.Player.SetCallbacks(this);
        }
        inputControls.Player.Enable();
    }
   
    private void OnDisable()
    {
        inputControls.Disable();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;
        OnJumpPerformed?.Invoke();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        MouseDelta = context.ReadValue<Vector2>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveComposite = context.ReadValue<Vector2>();
    } 
}
