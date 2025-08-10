using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class PlayerInputHandler : MonoBehaviour
{
    [Header("InputActionAsset")]
    public InputActionAsset playerControls;

    [Header("Action Map Name Reference")]
    public string actionMapName = "Player";

    [Header("Action Map Name References")]
    public string move = "Move";
    public string look = "Look";
    public string jump = "Jump";
    public string crouch = "Crouch";
    public string walk = "Walk";
    public string paused = "Pause";

    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction jumpAction;
    private InputAction crouchAction;
    private InputAction walkAction;
    private InputAction pauseAction;

    public Vector2 MoveInput { get; private set; }
    public Vector2 LookInput { get; private set; }
    public bool IsJumping { get; private set; }
    public bool IsCrouching { get; private set; }
    public bool IsWalking { get; private set; }
    public bool PressingPause { get; private set; }

    //Singleton Stuff
    public static PlayerInputHandler Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); }

        moveAction = playerControls.FindActionMap(actionMapName).FindAction(move);
        lookAction = playerControls.FindActionMap(actionMapName).FindAction(look);
        jumpAction = playerControls.FindActionMap(actionMapName).FindAction(jump);
        crouchAction = playerControls.FindActionMap(actionMapName).FindAction(crouch);
        walkAction = playerControls.FindActionMap(actionMapName).FindAction(walk);
        pauseAction = playerControls.FindActionMap(actionMapName).FindAction(paused);

        RegisterInputActions();
    }

    private void RegisterInputActions()
    {
        moveAction.performed += context => MoveInput = context.ReadValue<Vector2>();
        lookAction.performed += context => LookInput = context.ReadValue<Vector2>();
        moveAction.canceled += context => MoveInput = Vector2.zero;
        lookAction.canceled += context => LookInput = Vector2.zero;

        jumpAction.performed += context => IsJumping = true;
        crouchAction.performed += context => IsCrouching = true;
        walkAction.performed += context => IsWalking = true;
        pauseAction.performed += context => PressingPause = true;

        jumpAction.canceled += context => IsJumping = false;
        crouchAction.canceled += context => IsCrouching = false;
        walkAction.canceled += context => IsWalking = false;
        pauseAction.canceled += context => PressingPause = false;
    }



    private void OnEnable()
    {
        moveAction.Enable();
        lookAction.Enable();
        jumpAction.Enable();
        crouchAction.Enable();
        walkAction.Enable();
        pauseAction.Enable();

    }

    private void OnDisable()
    {
        moveAction.Disable();
        lookAction.Disable();
        jumpAction.Disable();
        crouchAction.Disable();
        walkAction.Disable();
        pauseAction.Disable();
    }
}
