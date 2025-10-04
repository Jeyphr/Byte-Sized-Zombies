using TMPro;
using UnityEngine;

public class Logger : MonoBehaviour
{
    public static Logger Instance { get; private set; }

    [Header("Object References")]
    [SerializeField] private TextMeshProUGUI xPos, yPos, zPos;

    //hidden object references
    private GameObject player;

    [Header("Logger Statistics")]
    private float playerX, playerY, playerZ;

    //hidden variables

    #region Main Methods
    //This is where the bun begins!
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
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        updateCoordText();
    }
    #endregion

    #region Coordinate Update Methods
    private void setCoordText(TextMeshProUGUI label, float val)
    {
        int castVal = (int)val;
        label.text = castVal.ToString();
    }

    private void updateCoordText()
    {
        if (player == null) { return; }

        setCoordText(xPos, player.transform.position.x);
        setCoordText(yPos, player.transform.position.y);
        setCoordText(zPos, player.transform.position.z);
    }
    #endregion
}
