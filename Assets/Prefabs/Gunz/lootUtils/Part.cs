using UnityEngine;
using lootUtils.PartAttributes;

namespace lootUtils.Parts
{
    #region Enums
    public enum PartType
    {
        Barrel,
        Stock,
        Optic,
        Magazine,
        Grip
    }

    public enum PartRarity
    {
        Common,
        Uncommon,
        Rare,
        Legendary,
        Epic
    }
    #endregion
    
    /// <summary>
    /// Represents a part of a gun with specific attributes.
    /// </summary>
    public class Part : MonoBehaviour
    {
        public string partName;
        public PartType partType;
        public PartRarity partRarity;
        public int partScore;
        public int timesPicked;
        public PartAttribute[] partAttributes;

        // Constructor
        public Part()
        {
            partName = "Default Part";
            partType = PartType.Barrel;
            partRarity = PartRarity.Common;
            partScore = 0;
            timesPicked = 0;
            partAttributes = new PartAttribute[] { };
        }
    }
}
