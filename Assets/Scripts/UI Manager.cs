using System;
using UnityEngine;





public enum uiState
{
    Gameplay,
    Paused,
    Terminal
}




public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }









    #region Mouse Control
    private bool mouseLock;
    public bool GetMouseLock { get { return mouseLock; } private set { mouseLock = value; } }

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

    private void ToggleMouseLock()
    {
        if (mouseLock)
        {
            UnlockMouse();
        }
        else
        {
            LockMouse();
        }
    }
    #endregion
}
