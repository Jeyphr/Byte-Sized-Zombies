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
    private PlayerMovement PM;
    [Header("UI Statistics")]
    [SerializeField] private bool showLogs;



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

    #region Event Methods
    private void OnEnable()
    {
        PlayerMovement.OnUIStateChange += setUIState;
    }
    private void OnDisable()
    {
        PlayerMovement.OnUIStateChange -= setUIState;
    }
    #endregion
}
