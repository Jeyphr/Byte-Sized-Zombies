using lootUtils.Guns;
using UnityEngine;

namespace lootUtils.PartAttributes
{
    /// <summary>
    /// Part Attribute Tokens represent the special attributes that can be applied to gun parts, like
    /// "increased accuracy" or "faster reload speed". It's also used to add custom functionality to 
    /// guns, such as alternate firing modes or special effects.
    /// 
    /// Guns look through their parts' PartAttribute arrays to determine what special attributes they have.
    /// This is done this way because parts can have multiple attributes, and it allows for more modularity and flexibility.
    /// </summary>
    public class PartAttribute : Gun
    {
        public string attributeName;
        public string attributeDescription;
        public float attributeScore;

        // Constructor
        public PartAttribute()
        {
            attributeName = "Default Attribute";
            attributeDescription = "This is a default part attribute.";
            attributeScore = 0f;
        }
    }
}
