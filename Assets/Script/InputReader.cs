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

    Vector2 MoveComposite;
    Vector2 MouseDelta;

    private void OnEnable()
    {
        if (null == inputControls)
        {
            inputControls = new Controls();
            inputControls.Player.SetCallbacks(this);
        }
        inputControls.Player.Enable();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDisable()
    {
        inputControls.Disable();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;
        // Debug.Log("OnJump");
        // throw new System.NotImplementedException();
        OnJumpPerformed?.Invoke();


    }

    public void OnLook(InputAction.CallbackContext context)
    {
        MouseDelta = context.ReadValue<Vector2>();
        // Debug.Log("OnLook");
        //throw new System.NotImplementedException();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;
       // Debug.Log("OnMove");
        MoveComposite = context.ReadValue<Vector2>();
    } 
}
