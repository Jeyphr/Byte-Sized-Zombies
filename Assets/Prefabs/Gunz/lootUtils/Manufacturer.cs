using System.Runtime.CompilerServices;
using lootUtils.Bullets;
using lootUtils.Guns;
using UnityEngine;

namespace lootUtils.Manufacturers
{
    #region Enums
    public enum ManufacturerType
    {
        Prop_Dept,
        Porter_Toys,
        DoomCo,
        Hablaffa_Incorporated,
        Privyet_Tech,
        Negative_Zero_Incorporated
    }
    #endregion

    // ==============================================================================================================================
    /// <summary>
    /// Represents a manufacturer of gun parts.
    /// </summary>
    public class Manufacturer
    {
        public ManufacturerType manufacturerType;
        public string manufacturerName;
        public string manufacturerTagline;
        public BulletType[] allowedBulletTypes;
        public ElementType[] allowedElementTypes;
        public GunType[] allowedGunTypes;

        // Constructor
        public Manufacturer()
        {
            manufacturerType = ManufacturerType.Negative_Zero_Incorporated;
            manufacturerName = "Default Manufacturer";
            manufacturerTagline = "Default Tagline";
            allowedBulletTypes = new BulletType[] { BulletType.Kinetic };
            allowedElementTypes = new ElementType[] { ElementType.NonElemental };
            allowedGunTypes = new GunType[] { GunType.Pistol, GunType.Shotgun };
        }

        //readonly array of all manufacturers
        public readonly Manufacturer[] manufacturers = new Manufacturer[]
        {
            new() {
                manufacturerType    = ManufacturerType.Prop_Dept,
                manufacturerName    = "Prop Dept",
                manufacturerTagline = "Made to look like the real thing! (Because it is...).",
                allowedBulletTypes  = new BulletType[] { BulletType.Kinetic },
                allowedElementTypes = new ElementType[] { ElementType.NonElemental },
                allowedGunTypes     = new GunType[]
                {
                    GunType.Pistol,
                    GunType.Revolver,
                    GunType.SMG,
                    GunType.Rifle,
                    GunType.Shotgun,
                    GunType.Sniper,
                    GunType.LMG,
                }
            },

            new() {
                manufacturerType    = ManufacturerType.Porter_Toys,
                manufacturerName    = "Porter Toys",
                manufacturerTagline = "Really Raving Rayguns!",
                allowedBulletTypes  = new BulletType[] { BulletType.Ray, BulletType.Laser },
                allowedElementTypes = new ElementType[] { ElementType.Fire, ElementType.Electric , ElementType.Corrosive },
                allowedGunTypes     = new GunType[]
                {
                    GunType.MachinePistol,
                    GunType.Revolver,
                    GunType.SMG,
                    GunType.Shotgun,
                    GunType.LMG,
                    GunType.Torpedo
                }
            },

            new() {
                manufacturerType    = ManufacturerType.DoomCo,
                manufacturerName    = "DoomCo",
                manufacturerTagline = "Nine Inch Nailguns!",
                allowedBulletTypes  = new BulletType[] { BulletType.Nail, BulletType.Grenade },
                allowedElementTypes = new ElementType[] { ElementType.NonElemental, ElementType.Explosive },
                allowedGunTypes     = new GunType[]
                {
                    GunType.MachinePistol,
                    GunType.Revolver,
                    GunType.SMG,
                    GunType.Shotgun,
                    GunType.Marksman_Rifle,
                    GunType.LMG,
                    GunType.Torpedo
                }
            },

            new() {
                manufacturerType    = ManufacturerType.Hablaffa_Incorporated,
                manufacturerName    = "Hablaffa Incorporated",
                manufacturerTagline = "KABOOMSTICKS! BUY NOW!.",
                allowedBulletTypes  = new BulletType[] { BulletType.Rocket, BulletType.Grenade },
                allowedElementTypes = new ElementType[] { ElementType.Explosive},
                allowedGunTypes     = new GunType[]
                {
                    GunType.Revolver,
                    GunType.Shotgun,
                    GunType.LMG,
                    GunType.Rocket_Launcher,
                    GunType.Grenade_Launcher,
                    GunType.Torpedo
                }
            },

            new() {
                manufacturerType    = ManufacturerType.Privyet_Tech,
                manufacturerName    = "Privyet Tech",
                manufacturerTagline = "Beig shuot powar! Moozt bye.",
                allowedBulletTypes  = new BulletType[] { BulletType.Kinetic, BulletType.Laser },
                allowedElementTypes = new ElementType[] { ElementType.Electric },
                allowedGunTypes     = new GunType[]
                {
                    GunType.Pistol,
                    GunType.MachinePistol,
                    GunType.Revolver,
                    GunType.SMG,
                    GunType.Rifle,
                    GunType.Shotgun,
                    GunType.Sniper,
                    GunType.Marksman_Rifle,
                    GunType.LMG,
                    GunType.Rocket_Launcher,
                    GunType.Grenade_Launcher,
                    GunType.Torpedo
                }
            },

            new() {
                manufacturerType    = ManufacturerType.Negative_Zero_Incorporated,
                manufacturerName    = "Negative Zero Incorporated",
                manufacturerTagline = "You can sense the impending doom in your hands.",
                allowedBulletTypes  = new BulletType[] { BulletType.Kinetic, BulletType.Ray, BulletType.Laser, BulletType.Nail, BulletType.Grenade, BulletType.Rocket },
                allowedElementTypes = new ElementType[] { ElementType.NonElemental, ElementType.Fire, ElementType.Electric, ElementType.Corrosive, ElementType.Explosive },
                allowedGunTypes     = new GunType[]
                {
                    GunType.Pistol,
                    GunType.MachinePistol,
                    GunType.Revolver,
                    GunType.SMG,
                    GunType.Rifle,
                    GunType.Shotgun,
                    GunType.Sniper,
                    GunType.Marksman_Rifle,
                    GunType.LMG,
                    GunType.Rocket_Launcher,
                    GunType.Grenade_Launcher,
                    GunType.Torpedo
                }
            }
        };
    }
}
