using UnityEngine;
using lootUtils.Manufacturers;
using lootUtils.Parts;
using System.Runtime.CompilerServices;

namespace lootUtils.Guns
{
    #region Enums
    public enum GunType
    {
        Pistol,
        MachinePistol,
        Revolver,
        SMG,
        Rifle,
        Torpedo,    //Assault Rifle that shoots grenades
        Shotgun,
        Sniper,
        Marksman_Rifle,
        LMG,
        Rocket_Launcher,
        Grenade_Launcher
    }

    public enum WeaponRarity
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary
    }
    #endregion

    // ==============================================================================================================================

    /// <summary>
    /// Guns must have one of each part: barrel, stock, optic, magazine, grip. These parts must have Part Attribute Tokens to give them
    /// stat changing abilities to the weapons.
    /// </summary>
    public class Gun
    {
        public string gunName;
        public GunType gunType;
        public WeaponRarity weaponRarity;
        public Manufacturer manufacturer;
        public Part[] gunParts;
        public int gunScore;


        // Constructor
        public Gun()
        {
            gunName = "Default Gun";
            gunType = GunType.Pistol;
            weaponRarity = WeaponRarity.Common;
            gunScore = 0;
        }

        //string ovveride
        public override string ToString()
        {
            string printable;
            printable = $"Gun Name: {gunName}\n" +
                        $"Gun Type: {gunType}\n" +
                        $"Weapon Rarity: {weaponRarity}\n" +
                        $"Manufacturer: {manufacturer.manufacturerName}\n" +
                        $"Gun Score: {gunScore}\n" +
                        $"=============================\n";

            return printable;
        }
    }
}
