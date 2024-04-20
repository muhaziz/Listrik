using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    private Controls controls;
    public event Action JumpEvent;
    public event Action DashEvent;
    public event Action ChangeEvent;
    public event Action PauseEvent; // Tambahkan event PauseEvent

    public bool Dashing { get; private set; }
    public bool Changing { get; private set; }
    public Vector2 MovementValue { get; private set; }

    private void Start()
    {
        controls = new Controls();
        controls.Player.SetCallbacks(this);

        controls.Player.Enable();
    }

    private void OnDestroy()
    {
        controls.Player.Disable();
    }


    public void OnMovement(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Dashing = true;
        }
        else if (context.canceled)
        {
            Dashing = false;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }

        JumpEvent?.Invoke();
    }

    public void OnChangestate(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Changing = !Changing; // Toggle nilai saat tombol ditekan
            ChangeEvent?.Invoke(); // Panggil event ChangeEvent saat nilai berubah
            Debug.Log("Changestate: " + Changing);
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PauseEvent?.Invoke();
        }
    }
}
