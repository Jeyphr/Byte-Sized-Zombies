using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

[System.Serializable]
public class PlayerMovement : MonoBehaviour
{
    //VARS
    [Header("Player Statistics")]
    public bool playerFrozen;
    public float movementSpeed = 3f;
    public float speedMult = 1f;
    public float jumpPower = 5f;


    [Header("Camera Statistics")]
    public bool cameraFrozen;
    public float hSens = 1.5f;
    public float vSens = 1f;
    public float fov;


    [Header("Object References")]
    public Camera pCam;
    public PlayerInput pInput;
    public CharacterController pController;
    public PlayerInputHandler iHandler;

    //hiddenvars
    private Vector3 currentMovement;
    private const float gravity = -9.82f;
    private const float iRange = 4f;

    /*
    Handles both player movement and camera movement.
    This is where the magic happens...
    */

    void Awake()
    {
        pController = GetComponent<CharacterController>();
        pCam = GetComponent<Camera>();
        iHandler = PlayerInputHandler.Instance;
    }
    void Update()
    {
        if (playerFrozen) { return; }
        handleMovement();
        handleJumping();

    }

    #region Schmoovement
    private void handleMovement()
    {
        float speed = movementSpeed * speedMult;
        Vector3 inputDirection = new Vector3(iHandler.MoveInput.x, 0f, iHandler.MoveInput.y);
        Vector3 worldDirection = transform.TransformDirection(inputDirection);
        worldDirection.Normalize();

        currentMovement.x = worldDirection.x * speed;
        currentMovement.z = worldDirection.z * speed;
        pController.Move(currentMovement * Time.deltaTime);
    }

    private void handleWalking()
    {

    }

    private void handleJumping()
    {

    }
    #endregion

    #region Checks
    private bool groundCheck()
    {
        return true;
    }
    #endregion
}
