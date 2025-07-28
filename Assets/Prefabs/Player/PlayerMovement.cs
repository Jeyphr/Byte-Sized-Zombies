using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

[System.Serializable]
public class PlayerMovement : MonoBehaviour
{
    //VARS
    [Header("Player Statistics")]
    public bool playerFrozen;
    public float movementSpeed = 1;
    public float jumpPower = 1;


    [Header("Camera Statistics")]
    public bool cameraFrozen;
    public float hSens = 1;
    public float vSens = 1;
    public float fov;


    [Header("Object References")]
    public Camera pCam;
    public PlayerInput pInput;
    public CharacterController pController;

    //hiddenvars
    private Vector2 moveDir;
    private const float gravity = -9.82f;
    private const float iRange = 4f;

    /*
    Handles both player movement and camera movement.
    This is where the magic happens...
    */
    void Update()
    {
        if(playerFrozen){ return; }
        handleMovement();
        handleJumping();
    }

    #region Schmoovement
    private void handleMovement()
    {

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
