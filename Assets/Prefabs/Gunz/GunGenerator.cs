using System;
using DoromiertSystem;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

//---------------------------------------------------------------

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
    Prop_Dept,              // Prop Department - Standard issue, made with love <3
    Porter_Toys,            // Porter Toys - Really Raving Rayguns!
    DoomCo,                 // DoomCo - Nine-Inch Nailguns!
    Hablaffa_Incorporated,  // KABOOMSTICKS! BUY NOW!
    Privyet_Tech,           // Russian manufacturer - rugged and not much else

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
    public float Score;
}

public class GunGenerator : MonoBehaviour
{
    // Consolidated manufacturer definitions for readability
    private readonly ManufacturerInfo[] manufacturers = new ManufacturerInfo[]
    {
        new ManufacturerInfo
        {
            manufacturerName = "Prop Dept.",
            bulletType = BulletType.Kinetic,
            possibleElements = new Element[] { Element.NonElemental },
            possibleGunTypes = new GunType[] { GunType.Pistol, GunType.MachinePistol, GunType.Revolver, GunType.SMG, GunType.Rifle, GunType.Shotgun, GunType.Sniper, GunType.Marksman_Rifle, GunType.LMG }
        },
        new ManufacturerInfo
        {
            manufacturerName = "Porter Toys",
            bulletType = BulletType.Ray,
            possibleElements = new Element[] { Element.Fire, Element.Electric, Element.Corrosive },
            possibleGunTypes = new GunType[] { GunType.Revolver, GunType.SMG, GunType.Rifle, GunType.Shotgun, GunType.Marksman_Rifle, GunType.LMG }
        },
        new ManufacturerInfo
        {
            manufacturerName = "DoomCo.",
            bulletType = BulletType.Nail,
            possibleElements = new Element[] { Element.NonElemental, Element.Fire, Element.Explosive },
            possibleGunTypes = new GunType[] { GunType.MachinePistol, GunType.SMG, GunType.Shotgun, GunType.LMG, GunType.Torpedo, GunType.Grenade_Launcher }
        },
        new ManufacturerInfo
        {
            manufacturerName = "Hablaffa Incorporated",
            bulletType = BulletType.Grenade,
            possibleElements = new Element[] { Element.Explosive },
            possibleGunTypes = new GunType[] { GunType.Grenade_Launcher, GunType.Rocket_Launcher, GunType.Torpedo, GunType.Shotgun, GunType.Sniper, GunType.Revolver }
        },
        new ManufacturerInfo
        {
            manufacturerName = "Privyet Tech",
            bulletType = BulletType.Kinetic,
            possibleElements = new Element[] { Element.NonElemental },
            possibleGunTypes = new GunType[] { GunType.Pistol, GunType.SMG, GunType.Rifle, GunType.Sniper, GunType.Marksman_Rifle, GunType.LMG, GunType.Rocket_Launcher, GunType.Torpedo, GunType.Grenade_Launcher }
        }
    };

    public ManufacturerInfo PickManufacturer()
    {
        var selectedManufacturer = manufacturers[UnityEngine.Random.Range(0, manufacturers.Length)];
        return selectedManufacturer;
    }

    public Element PickElement(ManufacturerInfo manufacturer, GunType gunType)
    {
        Element selectedElement = manufacturer.possibleElements[UnityEngine.Random.Range(0, manufacturer.possibleElements.Length)];

        // Adjust element for specific gun types
        if (gunType == GunType.Torpedo || gunType == GunType.Grenade_Launcher || gunType == GunType.Rocket_Launcher)
        {
            return Element.Explosive;
        }

        return selectedElement;
    }

    public BulletType PickBulletType(ManufacturerInfo manufacturer, GunType gunType)
    {
        BulletType selectedBulletType = manufacturer.bulletType;

        // Adjust bullet type for specific gun types
        if (gunType == GunType.Torpedo || gunType == GunType.Grenade_Launcher)
        {
            return BulletType.Grenade;
        }
        else if (gunType == GunType.Rocket_Launcher)
        {
            return BulletType.Rocket;
        }

        return selectedBulletType;
    }

    // Picks a random gun type based on the manufacturer
    public GunType PickGunType(ManufacturerInfo manufacturer)
    {
        GunType selectedGunType = manufacturer.possibleGunTypes[UnityEngine.Random.Range(0, manufacturer.possibleGunTypes.Length)];
        return selectedGunType;
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
            BulletType = bulletType,
            WeaponName = $"{element} {manufacturer.manufacturerName} {gunType}",


        };

        Debug.Log($"Just generated a {newWeapon.WeaponName} that shoots {newWeapon.BulletType} bullets.");
    }

    void Start()
    {
        // Prop_Dept is already initialized at class scope
        for (int i = 0; i < 100; i++)
        {
            GenerateGun();
        }


    }
}