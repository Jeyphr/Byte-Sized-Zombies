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


/// <summary>
/// This class manages everything there is to do with UI Management
/// 
/// </summary>
public class UIManager : MonoBehaviour
{
    [Header("Object References")]
    [SerializeField] public static UIManager Instance { get; private set; }

    [Header("Variables")]
    [SerializeField] private bool showLogs;



    // Fun begins below VV
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
        hideAllCanvases();
        sub_MouseEvents();
        setUIState(uiState.Terminal);
    }



    #region UI Control
    [Header("Game Screen References")]
    [SerializeField] private Canvas GameplayScreen;
    [SerializeField] private Canvas TerminalScreen;
    [SerializeField] private Canvas PauseScreen;
    //Vars
    //Events
    //private event Action<Enum> OnChangeScreen; <------------- STOPPED EDITING RIGHT HERE

    private void setUIState(uiState state)
    {
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
    //Vars
    private bool mouseLock;
    public bool GetMouseLock { get { return mouseLock; } private set { mouseLock = value; } }

    //Events
    public event Action<bool> OnUpdateMouse;

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

    private void updateMouse_OnUpdateMouse(bool val)
    {
        //Debug.Log("Mouse Locked?\t" + val);
        if (val)
        {
            LockMouse();
        }
        else
        {
            UnlockMouse();
        }
    }

    private void sub_MouseEvents()
    {
        Instance.OnUpdateMouse += updateMouse_OnUpdateMouse;
    }

    private void unsub_MouseEvents()
    {
        Instance.OnUpdateMouse -= updateMouse_OnUpdateMouse;
    }
    #endregion
}
