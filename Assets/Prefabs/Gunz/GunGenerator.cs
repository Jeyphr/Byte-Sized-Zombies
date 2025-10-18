using System;
using System.Collections.Generic;
using JetBrains.Annotations;
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
    public int TimesPicked;
}

public class manufacturerPartList
{
    public Part[] grips;
    public Part[] barrels;
    public Part[] stocks;
    public Part[] magazines;
    public Part[] optics;
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
    public ManufacturerInfo SetManufacturer()
    {
        var selectedManufacturer = manufacturers[UnityEngine.Random.Range(0, manufacturers.Length)];
        return selectedManufacturer;
    }

    public Element SetElement(ManufacturerInfo manufacturer, GunType gunType)
    {
        // Adjust element for specific gun types
        if (gunType == GunType.Torpedo || gunType == GunType.Grenade_Launcher || gunType == GunType.Rocket_Launcher)
        {
            return Element.Explosive;
        }

        Element selectedElement = manufacturer.possibleElements[UnityEngine.Random.Range(0, manufacturer.possibleElements.Length)];
        return selectedElement;
    }

    public BulletType SetBulletType(ManufacturerInfo manufacturer, GunType gunType)
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

    public GunType SetWeaponType(ManufacturerInfo manufacturer)
    {
        GunType selectedGunType = manufacturer.possibleGunTypes[UnityEngine.Random.Range(0, manufacturer.possibleGunTypes.Length)];
        return selectedGunType;
    }

    public string SetWeaponName(Weapon weapon)
    {
        Part bestPart = GetHighestScoringPartInWeapon(weapon);

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
                Prefix = "Banging";
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
    public Part GetHighestScoringPartInWeapon(Weapon weapon)
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

    public Rarity SetRarity(Weapon weapon)
    {
        foreach (var part in weapon.Parts)
        {
            weapon.GearScore += part.PartScore;
        }

        //Determine Rarity based on GearScore
        switch (weapon.GearScore)
        {
            case float score when (score < 12):
                return Rarity.Common;
            case float score when (score >= 12 && score < 24):
                return Rarity.Uncommon;
            case float score when (score >= 24 && score < 36):
                return Rarity.Rare;
            case float score when (score >= 36 && score < 48):
                return Rarity.Epic;
            case float score when (score >= 48):
                return Rarity.Legendary;
            default:
                return Rarity.Common;
        }
    }
    #endregion

    #region Part Creation Methods
    //add one of each part to the weapon
    private Part[] GetPartsFromManufacturerList(manufacturerPartList partList)
    {

        List<Part> parts = new List<Part>();
        parts.Add(PickFromList(partList.grips));
        parts.Add(PickFromList(partList.barrels));
        parts.Add(PickFromList(partList.stocks));
        parts.Add(PickFromList(partList.magazines));
        parts.Add(PickFromList(partList.optics));


        return parts.ToArray();
    }

    //takes a part list and picks a random part
    private Part PickFromList(Part[] list)
    {
        if (list == null || list.Length == 0)
            return null;

        // Pick a random part from the list
        Part part = list[UnityEngine.Random.Range(0, list.Length)];
        part.TimesPicked++;
        return part;
    }

    //creates all the generic parts
    private Part[] CreateGenericParts(PartType partType, String manufacturerName, int numberOfParts = 5, int minScore = 1, int maxScore = 10)

    {
        Part[] parts = new Part[numberOfParts];

        for (int i = 0; i < numberOfParts; i++)
        {
            parts[i] = new Part
            {
                PartType = partType,
                PartScore = UnityEngine.Random.Range(minScore, maxScore),
                PartName = $"{manufacturerName} {partType} {i + 1}",
            };
        }

        return parts;
    }

    private Part[] getPartListFromManufacturer(WeaponManufacturer manufacturer)
    {
        switch (manufacturer)
        {
            case WeaponManufacturer.Prop_Dept:
                return GetPartsFromManufacturerList(allPartLists[0]);
            default:
                return GetPartsFromManufacturerList(allPartLists[0]);
        }
    }

    private manufacturerPartList FillManufacturerPartsList(ManufacturerInfo manufacturer)
    {
        manufacturerPartList partList = new manufacturerPartList();

        partList.grips = CreateGenericParts(PartType.Grip, manufacturer.manufacturerName);
        partList.barrels = CreateGenericParts(PartType.Barrel, manufacturer.manufacturerName);
        partList.stocks = CreateGenericParts(PartType.Stock, manufacturer.manufacturerName);
        partList.magazines = CreateGenericParts(PartType.Magazine, manufacturer.manufacturerName);
        partList.optics = CreateGenericParts(PartType.Optic, manufacturer.manufacturerName);

        return partList;
    }
    #endregion

    #region Unity Methods
    public void GenerateGun()
    {
        Weapon newWeapon = new Weapon();
        newWeapon.Manufacturer = SetManufacturer();
        newWeapon.GunType = SetWeaponType(newWeapon.Manufacturer);
        newWeapon.Element = SetElement(newWeapon.Manufacturer, newWeapon.GunType);
        newWeapon.BulletType = SetBulletType(newWeapon.Manufacturer, newWeapon.GunType);
        newWeapon.Rarity = SetRarity(newWeapon);
        newWeapon.WeaponName = SetWeaponName(newWeapon);

        //Debug.Log($"Just generated a {newWeapon.WeaponName} that shoots {newWeapon.BulletType} bullets. ({newWeapon.GearScore}, {newWeapon.Rarity})");
    }

    public manufacturerPartList[] allPartLists = new manufacturerPartList[5];


    void Start()
    {

        for (int i = 0; i < 100; i++)
        {
            GenerateGun();
        }
    }
    #endregion
}