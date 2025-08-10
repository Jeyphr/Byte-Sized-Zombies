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
    [SerializeField] public static UIManager Instance { get; private set; }
    [SerializeField] public static PlayerMovement PM;

    [Header("Variables")]
    [SerializeField] private bool showLogs;

    #region UIManager Events
    #endregion

    //Fun begins below VV
    #region Main Methods
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
        Debug.Log(state);
        switch (state)
        {
            case uiState.Gameplay:
                hideAllCanvases();
                LockMouse();
                showCanvas(GameplayScreen);
                break;
            case uiState.Paused:
                hideAllCanvases();
                UnlockMouse();
                showCanvas(PauseScreen);
                break;
            case uiState.Terminal:
                hideAllCanvases();
                UnlockMouse();
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
        PlayerMovement.OnCamStateChange += toggleMouse;
        PlayerMovement.OnUIStateChange += setUIState;
    }
    private void OnDisable()
    {
        PlayerMovement.OnCamStateChange -= toggleMouse;
        PlayerMovement.OnUIStateChange -= setUIState;
    }
    #endregion
}
