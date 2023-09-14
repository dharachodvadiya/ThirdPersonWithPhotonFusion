using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

public class InputReader : MonoBehaviour, IPlayerActions
{
    Vector2 MoveComposite;
    public Controls inputControls;

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
         Debug.Log("OnJump");
        // throw new System.NotImplementedException();


    }

    public void OnLook(InputAction.CallbackContext context)
    {

       // Debug.Log("OnLook");
        //throw new System.NotImplementedException();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;
        Debug.Log("OnMove");
        MoveComposite = context.ReadValue<Vector2>();
    } 
}
