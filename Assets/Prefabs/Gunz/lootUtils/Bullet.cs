using UnityEngine;

namespace lootUtils.Bullets
{
    #region Enums
    public enum BulletType
    {
        Kinetic,    // Bullets
        Ray,        // Elemental Nova Explosive Rounds
        Laser,      // Elemental Laser Beams
        Nail,       // Nails
        Grenade,    // Grenades
        Rocket      // Rockets

    }

    public enum ElementType
    {
        NonElemental,
        Fire,
        Electric,
        Corrosive,
        Explosive
    }
    #endregion


    /// <summary>
    /// Represents a bullet in the game.
    /// </summary>
    public class Bullet : MonoBehaviour
    {
    }
}
