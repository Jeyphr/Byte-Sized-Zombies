using System;
using Unity.VisualScripting;
using UnityEngine;


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
#endregion



#region  Structs
public struct ManufacturerInfo
{
    public String manufacturerName;
    public String description;
    public BulletType bulletType;
    public Element[] possibleElements;
    public GunType[] possibleGunTypes;
}
#endregion



#region Classes
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

// -------------------------------- Guns ---------------------------------
public class Pistol : Weapon
{
    public GunType Type = GunType.Pistol;
}

public class MachinePistol : Weapon
{
    public GunType Type = GunType.MachinePistol;
}

public class Revolver : Weapon
{
    public GunType Type = GunType.Revolver;
}

public class SMG : Weapon
{
    public GunType Type = GunType.SMG;
}

public class Rifle : Weapon
{
    public GunType Type = GunType.Rifle;
}

public class Torpedo : Weapon
{
    public GunType Type = GunType.Torpedo;
}

public class Shotgun : Weapon
{
    public GunType Type = GunType.Shotgun;
    public float Spread; // Degrees of spread
}

public class Sniper : Weapon
{
    public GunType Type = GunType.Sniper;
    public float Steadiness; // Higher is better
}

public class Marksman_Rifle : Weapon
{
    public GunType Type = GunType.Marksman_Rifle;
}

public class LMG : Weapon
{
    public GunType Type = GunType.LMG;
}

public class Rocket_Launcher : Weapon
{
    public GunType Type = GunType.Rocket_Launcher;
}

public class Grenade_Launcher : Weapon
{
    public GunType Type = GunType.Grenade_Launcher;
}

// -------------------------------- Parts ---------------------------------
public class Part
{
    public string PartName;
    public PartType PartType;
    public float Score;
}

public class BarrelPart : Part
{
    public PartType Type = PartType.Barrel;
}

public class StockPart : Part
{
    public PartType Type = PartType.Stock;
}

public class MagazinePart : Part
{
    public PartType Type = PartType.Magazine;
}

public class OpticPart : Part
{
    public PartType Type = PartType.Optic;
}

public class GripPart : Part
{
    public PartType Type = PartType.Grip;
}
#endregion



#region GunGenerator Class
public class GunGenerator : MonoBehaviour
{
    public ManufacturerInfo Prop_Dept = new ManufacturerInfo
    {
        manufacturerName = "Prop Dept.",
        bulletType = BulletType.Kinetic,
        possibleElements = new Element[] { Element.NonElemental },
        possibleGunTypes = new GunType[] { GunType.Pistol, GunType.MachinePistol, GunType.Revolver, GunType.SMG, GunType.Rifle, GunType.Shotgun, GunType.Sniper, GunType.Marksman_Rifle, GunType.LMG }
    };

    public ManufacturerInfo Porter_Toys = new ManufacturerInfo
    {
        manufacturerName = "Porter Toys",
        bulletType = BulletType.Ray,
        possibleElements = new Element[] { Element.Fire, Element.Electric, Element.Corrosive },
        possibleGunTypes = new GunType[] { GunType.Revolver, GunType.SMG, GunType.Rifle, GunType.Shotgun, GunType.Marksman_Rifle, GunType.LMG }
    };

    public ManufacturerInfo DoomCo = new ManufacturerInfo
    {
        manufacturerName = "DoomCo.",
        bulletType = BulletType.Nail,
        possibleElements = new Element[] { Element.NonElemental, Element.Fire, Element.Explosive },
        possibleGunTypes = new GunType[] { GunType.MachinePistol, GunType.SMG, GunType.Shotgun, GunType.LMG, GunType.Torpedo, GunType.Grenade_Launcher }
    };

    public ManufacturerInfo Hablaffa_Incorporated = new ManufacturerInfo
    {
        manufacturerName = "Hablaffa Incorporated",
        bulletType = BulletType.Grenade,
        possibleElements = new Element[] { Element.Explosive },
        possibleGunTypes = new GunType[] { GunType.Grenade_Launcher, GunType.Rocket_Launcher, GunType.Torpedo, GunType.Shotgun, GunType.Sniper, GunType.Revolver }
    };

    public ManufacturerInfo PenIsland = new ManufacturerInfo
    {
        manufacturerName = "Pen Island Incorporated",
        bulletType = BulletType.Laser,
        possibleElements = new Element[] { Element.Corrosive },
        possibleGunTypes = new GunType[] { GunType.SMG, GunType.Rocket_Launcher }
    };



    #region Unity Methods
    void Start()
    {
        // Prop_Dept is already initialized at class scope
        GenerateGun();

    }
    #endregion



    #region Pickers
    public ManufacturerInfo PickManufacturer()
    {
        ManufacturerInfo[] manufacturers = new ManufacturerInfo[] { Prop_Dept, Porter_Toys, DoomCo, Hablaffa_Incorporated, PenIsland };
        ManufacturerInfo selectedManufacturer = manufacturers[UnityEngine.Random.Range(0, manufacturers.Length)];
        Debug.Log("Picked Manufacturer: " + selectedManufacturer.manufacturerName);
        return selectedManufacturer;
    }

    public Element PickElement(ManufacturerInfo manufacturer)
    {
        Element selectedElement = manufacturer.possibleElements[UnityEngine.Random.Range(0, manufacturer.possibleElements.Length)];
        Debug.Log("Picked Element: " + selectedElement);
        return selectedElement;
    }

    public BulletType PickBulletType(ManufacturerInfo manufacturer)
    {
        BulletType selectedBulletType = manufacturer.bulletType;
        Debug.Log("Picked Bullet Type: " + selectedBulletType);
        return selectedBulletType;
    }

    // Picks a random gun type based on the manufacturer
    public GunType PickGunType(ManufacturerInfo manufacturer)
    {
        GunType selectedGunType = manufacturer.possibleGunTypes[UnityEngine.Random.Range(0, manufacturer.possibleGunTypes.Length)];
        Debug.Log("Picked Gun Type: " + selectedGunType);
        return selectedGunType;
    }
    #endregion



    #region Gun Generation
    public void GenerateGun()
    {
        ManufacturerInfo manufacturer = PickManufacturer();
        GunType gunType = PickGunType(manufacturer);
        Element element = PickElement(manufacturer);
        BulletType bulletType = PickBulletType(manufacturer);

        Debug.Log("Generated a " + manufacturer.manufacturerName + " " + gunType + " that shoots " + element + " " + bulletType + " rounds.");
    }
    #endregion
}
#endregion