using lootUtils.Manufacturers;
using lootUtils.Guns;
using UnityEngine;

namespace lootUtils.Shields
{
    #region Enums
    public enum ShieldType
    {
        Standard,
        Amp,
        Turtle,
        Nova,
        Stockpile
    }
    #endregion  

    /// <summary>
    /// Represents a shield in the game.
    /// </summary>
    public class Shield : MonoBehaviour
    {
        public string shieldName;
        public string shieldDescription;
        public float shieldCapacity;
        public float rechargeRate;
        public float rechargeDelay;
        public int shieldScore;
        public WeaponRarity shieldRarity;
        public ShieldType shieldType;
        public Manufacturer manufacturer;
        
        // Constructor
        public Shield()
        {
            shieldCapacity = 100f;
            rechargeRate = 5f;
        }

    }
}
