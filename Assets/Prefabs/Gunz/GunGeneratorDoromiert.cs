using System;
using UnityEngine;
using DoromiertSystem;

public class GunGeneratorDoromiert : MonoBehaviour
{
    // Manufacturer definitions (move these to a separate Manufacturers.cs if desired)
    public static Manufacturer DoomCo = new Manufacturer
    {
        Name = "Doom Co",
        Description = "They started building nailguns back in 1493 and somehow managed to never go out of business. They are known for their high-quality nailguns that are both reliable and powerful. They still don't know that gunpowder exists.",
        BulletTypes = new BulletTypeD[] { BulletTypeD.Nail },
        Elements = new ElementD[] { ElementD.None, ElementD.Fire },
        GunTypes = new GunTypeD[] { GunTypeD.Nailgun }
    };

    public static Manufacturer PropDept = new Manufacturer
    {
        Name = "Prop Dept",
        Description = "They're actually the prop department behind the movie you're stuck in. They make all sorts of fake guns for movies, but since you're in a movie, they're real to you.",
        BulletTypes = new BulletTypeD[] { BulletTypeD.Kinetic, BulletTypeD.Ray, BulletTypeD.Laser },
        Elements = new ElementD[] { ElementD.None, ElementD.Fire, ElementD.Electric, ElementD.Corrosive },
        GunTypes = new GunTypeD[] { GunTypeD.Pistol, GunTypeD.MachinePistol, GunTypeD.Revolver, GunTypeD.SMG, GunTypeD.Rifle, GunTypeD.AutoShotgun, GunTypeD.PumpShotgun, GunTypeD.Sniper, GunTypeD.Marksman_Rifle, GunTypeD.LMG }
    };

    public static Manufacturer Hablaffa_Incorporated = new Manufacturer
    {
        Name = "Hablaffa Incorporated",
        Description = "Founded in 1933 by Robert Noble-Hablaffa when he learned about his grandpa's invention of the dynamite stick, Hablaffa Inc at first only produced explosives meant for mining, but after they learned about how profitable the firearms industry was, they expanded into making general explosive weaponry.",
        BulletTypes = new BulletTypeD[] { BulletTypeD.Grenade },
        Elements = new ElementD[] { ElementD.Explosive },
        GunTypes = new GunTypeD[] { GunTypeD.Grenade_Launcher, GunTypeD.Rocket_Launcher, GunTypeD.Torpedo }
    };

    public static Manufacturer PenIsland = new Manufacturer
    {
        Name = "Pen Island",
        Description = "Founded in 2001 by a group of disgruntled office workers who were tired of using boring, ineffective pens, PenIsland revolutionized the writing instrument industry by creating pens that could also function as deadly firearms. Their slogan, 'Write your own destiny,' reflects their commitment to empowering individuals to take control of their lives and defend themselves if necessary.",
        BulletTypes = new BulletTypeD[] { BulletTypeD.Ink, BulletTypeD.Kinetic },
        Elements = new ElementD[] { ElementD.None, ElementD.Corrosive },
        GunTypes = new GunTypeD[] { GunTypeD.Pen }
    };

    public static Manufacturer Porter_Toys = new Manufacturer
    {
        Name = "Porter Toys",
        Description = "A toys company that secretly manufactures real firearms disguised as toys. Their products are popular among collectors and enthusiasts who appreciate the craftsmanship and novelty of owning a toy gun that is also a functional weapon.",
        BulletTypes = new BulletTypeD[] { BulletTypeD.Ray },
        Elements = new ElementD[] { ElementD.Fire, ElementD.Electric, ElementD.Corrosive, ElementD.Explosive },
        GunTypes = new GunTypeD[] { GunTypeD.Pistol, GunTypeD.MachinePistol }
    };

    public static Manufacturer BBL = new Manufacturer
    {
        Name = "BBL",
        Description = "Bass Boosted Labs (BBL) specializes in audio equipment of all sorts, but it started manufacturing firearms after the CEO watched a youtube video of someone using their speakers to hunt animals.",
        BulletTypes = new BulletTypeD[] { BulletTypeD.Audio },
        Elements = new ElementD[] { ElementD.Audio },
        GunTypes = new GunTypeD[] { GunTypeD.SMG, GunTypeD.Rifle, GunTypeD.AutoShotgun, GunTypeD.PumpShotgun, GunTypeD.Sniper, GunTypeD.Marksman_Rifle, GunTypeD.LMG }
    };

    public static Manufacturer SkyByDyToilets = new Manufacturer
    {
        Name = "SkyByDy Toilets",
        Description = "SkyByDy Toilets is a company that specializes in high-tech toilets and bathroom fixtures. Their bathroom products were so advanced that they decided to branch out into making firearms out of porcelain.",
        BulletTypes = new BulletTypeD[] { BulletTypeD.Kinetic },
        Elements = new ElementD[] { ElementD.None, ElementD.Corrosive },
        GunTypes = new GunTypeD[] { GunTypeD.PumpShotgun }
    };

    public Manufacturer[] Manufacturers = new Manufacturer[] { DoomCo, Hablaffa_Incorporated, PenIsland, Porter_Toys };

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