using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public enum uiState
{
    Gameplay,
    Paused,
    Terminal
}

public class UIManager : MonoBehaviour
{
    [Header("Object References")]
    public static UIManager Instance { get; private set; }
    public static PlayerMovement PM;

    [Header("UI Statistics")]
    [SerializeField] private bool showLogs;

    #region UIManager Events
    #endregion

    #region Main Methods
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
        hideAllCanvases();
    }
    #endregion



    #region UI Control
    [Header("Game Screen References")]
    [SerializeField] private Canvas GameplayScreen;
    [SerializeField] private Canvas TerminalScreen;
    [SerializeField] private Canvas PauseScreen;

    private void setUIState(uiState state)
    {
        Debug.Log("Setting UI State:\t" + state);
        switch (state)
        {
            case uiState.Gameplay:
                hideAllCanvases();
                showCanvas(GameplayScreen);
                break;
            case uiState.Paused:
                hideAllCanvases();
                showCanvas(PauseScreen);
                break;
            case uiState.Terminal:
                hideAllCanvases();
                showCanvas(TerminalScreen);
                break;
        }
    }

    private void showCanvas(Canvas c)
    {
        c.enabled = true;
    }
    private void hideCanvas(Canvas c)
    {
        c.enabled = false;
    }
    private void hideAllCanvases()
    {
        hideCanvas(GameplayScreen);
        hideCanvas(PauseScreen);
        hideCanvas(TerminalScreen);
    }
    #endregion

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
        PlayerMovement.OnUIStateChange += setUIState;
    }
    private void OnDisable()
    {
        PlayerMovement.OnMouseStateChange -= toggleMouse;
        PlayerMovement.OnUIStateChange -= setUIState;
    }
    #endregion
}
