using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public enum playerState
{
    Gameplay,
    Paused,
    Terminal
}

[System.Serializable]
public class PlayerMovement : MonoBehaviour
{
    [Header("Player Statistics")]
    public bool updateMovement;
    public bool updatePlayer;
    public float movementSpeed;
    public float walkMult;
    public float jumpPower;

    [Header("Camera Statistics")]
    public bool updateCamera;
    public bool freeCam;
    public float hSens;
    public float vSens;
    public float fov;

    [Header("Object References")]
    public Camera playerCamera;
    public Camera uiCamera;
    public CharacterController playerController;
    private PlayerInputHandler iHandler;
    private UIManager uiManager;

    //hiddenvars
    private Vector3 currentMovement;
    private const float gravity = 9.82f;
    private const float iRange = 4f;
    private float mouseX, mouseY;
    private float upDownRange = 80.0f;
    private bool isPaused = false;
    private bool isInTerminal = false;

    #region PlayerMovmement Events
    public static event Action<bool> OnMouseStateChange;
    public static event Action<uiState> OnUIStateChange;

    #endregion

    #region Main Methods
    void Start()
    {
        playerController = FindAnyObjectByType<CharacterController>();
        iHandler = FindAnyObjectByType<PlayerInputHandler>();
        uiManager = FindAnyObjectByType<UIManager>();

        playerCamera = Camera.main;
        playerCamera.fieldOfView = fov;
        uiCamera.fieldOfView = fov;

        //------------------------------------------
        setGameState(playerState.Gameplay);
    }
    void Update()
    {
        handleUI();

        if (!updatePlayer) { return; }
        handleMovement();
        handleRotation();
        handleJumping();

    }
    #endregion



    #region Schmoovement
    private void handleMovement()
    {
        if (!updateMovement) { return; }

        float speed = movementSpeed * (iHandler.IsWalking ? walkMult : 1f);
        Vector3 inputDirection = new Vector3(iHandler.MoveInput.x, 0f, iHandler.MoveInput.y);
        Vector3 worldDirection = transform.TransformDirection(inputDirection);
        worldDirection.Normalize();

        currentMovement.x = worldDirection.x * speed;
        currentMovement.z = worldDirection.z * speed;
        playerController.Move(currentMovement * Time.deltaTime);
    }
    private void handleRotation()
    {
        if (!updateCamera) { return; }
        if (freeCam) { return; }

        if (!isPaused)
        {
            mouseX = iHandler.LookInput.x * hSens;
            transform.Rotate(0, mouseX, 0);

            mouseY -= iHandler.LookInput.y * vSens;
            mouseY = Mathf.Clamp(mouseY, -upDownRange, upDownRange);
            playerCamera.transform.localRotation = Quaternion.Euler(mouseY, 0, 0);
        }

    }
    private void handleJumping()
    {
        if (!updateMovement) { return; }

        if (playerController.isGrounded)
        {
            currentMovement.y = -0.5f;

            if (iHandler.IsJumping)
            {
                currentMovement.y = jumpPower;
            }
        }
        else
        {
            currentMovement.y -= gravity * Time.deltaTime;
        }

    }
    #endregion

    #region State Handler
    private void setGameState(playerState g)
    {
        Debug.Log("Setting Game State:\t" + g);
        switch (g)
        {
            case playerState.Gameplay:
                isPaused = false;
                OnUIStateChange?.Invoke(uiState.Gameplay);
                OnMouseStateChange?.Invoke(false);
                break;
            case playerState.Paused:
                isPaused = true;
                OnUIStateChange?.Invoke(uiState.Paused);
                OnMouseStateChange?.Invoke(true);
                break;
            case playerState.Terminal:
                isPaused = false;
                OnUIStateChange?.Invoke(uiState.Terminal);
                OnMouseStateChange?.Invoke(true);
                break;

        }

    }

    #endregion

    #region UI Control
    private void handleUI()
    {
        if (iHandler.PressingPause && !isPaused)
        {
            isPaused = true;
            setGameState(playerState.Paused);
            Time.timeScale = 0;
        }
    }
    #endregion
}
