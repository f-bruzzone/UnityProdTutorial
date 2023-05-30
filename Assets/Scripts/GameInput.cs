using System;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }


    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternateAction;
    public event EventHandler OnPauseAction;


    private PlayerInputActions _playerInputActions;

    private void Awake()
    {
        Instance = this;

        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();

        _playerInputActions.Player.Interact.performed += Interact_Performed;
        _playerInputActions.Player.InteractAlternate.performed += InteractAlternate_performed;
        _playerInputActions.Player.Pause.performed += Pause_performed;
    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }

    private void InteractAlternate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = _playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }

    // Upon leaving scene, these subscriptions remain, but the player input theyre referencing
    // does not. When buttons are pressed after going to main menu and back into game a
    // null reference exception will be fired. Must unsubscribe and dispose of player input.
    private void OnDestroy()
    {
        _playerInputActions.Player.Interact.performed += Interact_Performed;
        _playerInputActions.Player.InteractAlternate.performed += InteractAlternate_performed;
        _playerInputActions.Player.Pause.performed += Pause_performed;

        _playerInputActions.Dispose();
    }
}
