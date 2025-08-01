using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

[System.Serializable]
public class PlayerMovement : MonoBehaviour
{
    //VARS
    [Header("Player Statistics")]
    public bool playerFrozen;
    public bool updatePlayer;
    public float movementSpeed = 10f;
    public float walkMult = 0.5f;
    public float jumpPower = 5f;


    [Header("Camera Statistics")]
    public bool cameraFrozen;
    public bool freeCam;
    public float hSens = 1.5f;
    public float vSens = 1f;
    public float fov;


    [Header("Object References")]
    private Camera playerCamera;
    private CharacterController playerController;
    private PlayerInputHandler iHandler;

    //hiddenvars
    private Vector3 currentMovement;
    private const float gravity = 9.82f;
    private const float iRange = 4f;
    private float mouseX, mouseY;
    private float upDownRange = 80.0f;

    /*
    Handles both player movement and camera movement.
    This is where the magic happens...
    */

    void Awake()
    {
        playerController = GetComponent<CharacterController>();
        playerCamera = Camera.main;
        iHandler = PlayerInputHandler.Instance;
    }
    void Update()
    {
        if (!updatePlayer) { return; }
        handleMovement();
        handleRotation();
        handleJumping();
    }

    #region Schmoovement
    private void handleMovement()
    {
        if (playerFrozen) { return; }

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
        if(cameraFrozen){ return; }

        if (!freeCam) {
            mouseX = iHandler.LookInput.x * hSens;
            transform.Rotate(0, mouseX, 0);
    
            mouseY -= iHandler.LookInput.y * vSens;
            mouseY = Mathf.Clamp(mouseY, -upDownRange, upDownRange);
            playerCamera.transform.localRotation = Quaternion.Euler(mouseY, 0, 0);
        }

    }

    private void handleJumping()
    {
        if(playerFrozen){ return; }

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
}
