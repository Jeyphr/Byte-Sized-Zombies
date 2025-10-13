using System;
using DoromiertSystem;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

//---------------------------------------------------------------
#region --- DATA ---
public enum BulletType
{
    Kinetic,    // Bullets
    Ray,        // Elemental Nova Explosive Rounds
    Laser,      // Elemental Laser Beams
    Nail,       // Nails
    Grenade,    // Grenades
    Rocket      // Rockets
}

public enum Element
{
    NonElemental,
    Fire,
    Electric,
    Corrosive,
    Explosive
}

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


public enum PartType
{
    Barrel,
    Stock,
    Magazine,
    Optic,
    Grip
}

public enum Rarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}
public class Weapon
{
    public GunType GunType;
    public ManufacturerInfo Manufacturer;
    public Element Element;
    public BulletType BulletType;
    public Rarity Rarity;
    public Part[] Parts;

    // Base Stats
    public string WeaponName;
    public string WeaponDescription;
    public float GearScore;
}

public enum WeaponManufacturer
{
    Prop_Dept,
    Porter_Toys,
    DoomCo,
    Hablaffa_Incorporated,
    Privyet_Tech
}


public class ManufacturerInfo
{
    public string manufacturerName;
    public string description;
    public BulletType bulletType;
    public Element[] possibleElements;
    public GunType[] possibleGunTypes;
}

public class Part
{
    public string PartName;
    public PartType PartType;
    public float PartScore;
}
#endregion

public class GunGenerator : MonoBehaviour
{

    #region --- MANUFACTURERS ---
    private readonly ManufacturerInfo[] manufacturers = new ManufacturerInfo[]
    {
        new ManufacturerInfo
        {
            manufacturerName = "Prop Dept.",
            description = "Standard issue, made with love <3",
            bulletType = BulletType.Kinetic,
            possibleElements = new Element[] { Element.NonElemental },
            possibleGunTypes = new GunType[] { GunType.Pistol, GunType.MachinePistol, GunType.Revolver, GunType.SMG, GunType.Rifle, GunType.Shotgun, GunType.Sniper, GunType.Marksman_Rifle, GunType.LMG }
        },
        new ManufacturerInfo
        {
            manufacturerName = "Porter Toys",
            description = "Really Raving Rayguns!",
            bulletType = BulletType.Ray,
            possibleElements = new Element[] { Element.Fire, Element.Electric, Element.Corrosive },
            possibleGunTypes = new GunType[] { GunType.Revolver, GunType.SMG, GunType.Rifle, GunType.Shotgun, GunType.Marksman_Rifle, GunType.LMG }
        },
        new ManufacturerInfo
        {
            manufacturerName = "DoomCo.",
            description = "Nine-Inch Nailguns!",
            bulletType = BulletType.Nail,
            possibleElements = new Element[] { Element.NonElemental, Element.Fire, Element.Explosive },
            possibleGunTypes = new GunType[] { GunType.MachinePistol, GunType.SMG, GunType.Shotgun, GunType.LMG, GunType.Torpedo, GunType.Grenade_Launcher }
        },
        new ManufacturerInfo
        {
            manufacturerName = "Hablaffa Incorporated",
            description = "KABOOMSTICKS! BUY NOW!",
            bulletType = BulletType.Grenade,
            possibleElements = new Element[] { Element.Explosive },
            possibleGunTypes = new GunType[] { GunType.Grenade_Launcher, GunType.Rocket_Launcher, GunType.Torpedo, GunType.Shotgun, GunType.Sniper, GunType.Revolver }
        },
        new ManufacturerInfo
        {
            manufacturerName = "Privyet Tech",
            description = "Rugged and not much else",
            bulletType = BulletType.Kinetic,
            possibleElements = new Element[] { Element.NonElemental },
            possibleGunTypes = new GunType[] { GunType.Pistol, GunType.SMG, GunType.Rifle, GunType.Sniper, GunType.Marksman_Rifle, GunType.LMG, GunType.Rocket_Launcher, GunType.Torpedo, GunType.Grenade_Launcher }
        }
    };
    #endregion

    #region Weapon Generation Methods
    public ManufacturerInfo PickManufacturer()
    {
        var selectedManufacturer = manufacturers[UnityEngine.Random.Range(0, manufacturers.Length)];
        return selectedManufacturer;
    }

    public Element PickElement(ManufacturerInfo manufacturer, GunType gunType)
    {
        // Adjust element for specific gun types
        if (gunType == GunType.Torpedo || gunType == GunType.Grenade_Launcher || gunType == GunType.Rocket_Launcher)
        {
            return Element.Explosive;
        }

        Element selectedElement = manufacturer.possibleElements[UnityEngine.Random.Range(0, manufacturer.possibleElements.Length)];
        return selectedElement;
    }

    public BulletType PickBulletType(ManufacturerInfo manufacturer, GunType gunType)
    {
        // Adjust bullet type for specific gun types
        if (gunType == GunType.Torpedo || gunType == GunType.Grenade_Launcher)
        {
            return BulletType.Grenade;
        }
        else if (gunType == GunType.Rocket_Launcher)
        {
            return BulletType.Rocket;
        }

        BulletType selectedBulletType = manufacturer.bulletType;
        return selectedBulletType;
    }

    // Picks a random gun type based on the manufacturer
    public GunType PickGunType(ManufacturerInfo manufacturer)
    {
        GunType selectedGunType = manufacturer.possibleGunTypes[UnityEngine.Random.Range(0, manufacturer.possibleGunTypes.Length)];
        return selectedGunType;
    }

    public string WeaponNameGenerator(Weapon weapon)
    {
        Part bestPart = GetHighestScoringPart(weapon);

        String Prefix;
        switch (weapon.Element)
        {
            case Element.Fire:
                Prefix = "Blazing";
                break;
            case Element.Electric:
                Prefix = "Shocking";
                break;
            case Element.Corrosive:
                Prefix = "Stinging";
                break;
            case Element.Explosive:
                Prefix = "Hard";
                break;
            default:
                Prefix = "";
                break;
        }

        if (bestPart == null)
        {
            return $"{Prefix} {weapon.Manufacturer.manufacturerName} {weapon.GunType}";
        }

        return $"{Prefix} {bestPart.PartName} {weapon.GunType}";
    }

    // Returns the Part with the highest PartScore, or null if no parts
    public Part GetHighestScoringPart(Weapon weapon)
    {
        if (weapon?.Parts == null || weapon.Parts.Length == 0)
            return null;

        Part best = weapon.Parts[0];
        for (int i = 1; i < weapon.Parts.Length; i++)
        {
            if (weapon.Parts[i].PartScore > best.PartScore)
                best = weapon.Parts[i];
        }
        return best;
    }

    public void GenerateGun()
    {
        ManufacturerInfo manufacturer = PickManufacturer();
        GunType gunType = PickGunType(manufacturer);
        Element element = PickElement(manufacturer, gunType);
        BulletType bulletType = PickBulletType(manufacturer, gunType);

        Weapon newWeapon = new Weapon
        {
            Manufacturer = manufacturer,
            GunType = gunType,
            Element = element,
            BulletType = bulletType
        };

        newWeapon.WeaponName = WeaponNameGenerator(newWeapon);
        Debug.Log($"Just generated a {newWeapon.WeaponName} that shoots {newWeapon.BulletType} bullets.");
    }
    #endregion

    #region Unity Methods
    void Start()
    {
        // Prop_Dept is already initialized at class scope
        for (int i = 0; i < 100; i++)
        {
            GenerateGun();
        }


    }
    #endregion
}