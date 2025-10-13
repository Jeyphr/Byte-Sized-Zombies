using System;
using UnityEngine;
using DoromiertSystem;

public class GunGeneratorDoromiert : MonoBehaviour
{

    public Manufacturer[] Manufacturers = new Manufacturer[] { Manufacturers.DoomCo, Manufacturers.Hablaffa_Incorporated, Manufacturers.PenIsland, Manufacturers.Porter_Toys };

    public void Start()
    {
        DebugGenerator();
    }
    
    public Gun GenerateGun()
    {
        Manufacturer manufacturer = Manufacturers[UnityEngine.Random.Range(0, Manufacturers.Length)];
        GunTypeD gunType = manufacturer.GunTypes[UnityEngine.Random.Range(0, manufacturer.GunTypes.Length)];

        Gun gun;
        switch (gunType)
        {
            case GunTypeD.AutoShotgun:
                gun = new AutoShotgunD();
                gun.Spread = UnityEngine.Random.Range(5f, 20f);
                
                break;
            case GunTypeD.Sniper:
                gun = new SniperD();
                break;
            default:
                gun = new Gun();
                break;
        }

        // boilerplate stats generation
        gun.GunType = gunType;
        gun.Manufacturer = manufacturer;
        gun.Rarity = (RarityD)UnityEngine.Random.Range(0, Enum.GetValues(typeof(RarityD)).Length);
        gun.Element = manufacturer.Elements[UnityEngine.Random.Range(0, manufacturer.Elements.Length)];
        gun.BulletType = manufacturer.BulletTypes[UnityEngine.Random.Range(0, manufacturer.BulletTypes.Length)];
        gun.Damage = UnityEngine.Random.Range(10, 101);
        gun.FireRate = UnityEngine.Random.Range(1f, 10f);
        gun.ReloadSpeed = UnityEngine.Random.Range(1f, 5f);
        gun.MagazineSize = UnityEngine.Random.Range(5, 31);
        gun.Accuracy = UnityEngine.Random.Range(0.5f, 1f);
        gun.Recoil = UnityEngine.Random.Range(0f, 1f);
        gun.Range = UnityEngine.Random.Range(50f, 500f);
        gun.CriticalChance = UnityEngine.Random.Range(0f, 0.5f);
        gun.CriticalMultiplier = UnityEngine.Random.Range(1.5f, 3f);
        gun.Name = "Gun of " + manufacturer.Name;

        return gun;
    }

    public void DebugGenerator()
    {
        // Generate and log 5 random guns
        for (int i = 0; i < 5; i++)
        {
            Gun gun = GenerateGun();
            Debug.Log($"Generated Gun {i + 1}: {gun.Name}, Type: {gun.GunType}, Manufacturer: {gun.Manufacturer.Name}, Rarity: {gun.Rarity}, Element: {gun.Element}, Damage: {gun.Damage}, Fire Rate: {gun.FireRate}, Magazine Size: {gun.MagazineSize}");
        }
    }
}