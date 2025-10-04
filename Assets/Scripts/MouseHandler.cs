using UnityEngine;

public class MouseHandler : MonoBehaviour
{
    [Header("Object References")]
    public static MouseHandler Instance { get; private set; }
    public static PlayerMovement PM;

    [Header("Mouse Settings")]
    [SerializeField] private bool showLogs;
    [SerializeField] private bool mouseLock;

    //GETTERS AND SETTERS
    public bool GetMouseLock { get { return mouseLock; } private set { mouseLock = value; } }

    //This is where the bun begins!
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        // --------------------------------------
        PM = FindAnyObjectByType<PlayerMovement>();
    }



    #region Mouse Control Methods
    private void LockMouse()
    {
        mouseLock = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void UnlockMouse()
    {
        mouseLock = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    private void toggleMouse(bool isOn)
    {
        Debug.Log("Mouse Mode: " + isOn);
        if (isOn)
        {
            UnlockMouse();
        }
        else
        {
            LockMouse();
        }
    }
    #endregion
    


    #region Event Methods
    private void OnEnable()
    {
        PlayerMovement.OnMouseStateChange += toggleMouse;
    }
    private void OnDisable()
    {
        PlayerMovement.OnMouseStateChange -= toggleMouse;
    }
    #endregion

}
