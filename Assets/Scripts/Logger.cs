using TMPro;
using UnityEngine;

public class Logger : MonoBehaviour
{
    public static Logger Instance { get; private set; }

    [Header("Object References")]
    private GameObject player;
    [SerializeField] private TextMeshProUGUI xPos, yPos, zPos;

    [Header("Logger Statistics")]
    private float playerX, playerY, playerZ;

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
        setCoordText(xPos, player.transform.position.x);
        setCoordText(yPos, player.transform.position.y);
        setCoordText(zPos, player.transform.position.z);
    }
    #endregion

    #region Coordinate Update Methods
    private void setCoordText(TextMeshProUGUI label, float val)
    {
        int castVal = (int)val;
        label.text = castVal.ToString();
    }
    #endregion
}
