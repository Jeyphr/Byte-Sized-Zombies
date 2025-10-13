using DoromiertSystem;

public static class Manufacturers
{
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

    public static Manufacturer HablaffaIncorporated = new Manufacturer
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

    public static Manufacturer PorterToys = new Manufacturer
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

    public static Manufacturer Everblue = new Manufacturer
    {
        Name = "Everblue",
        Description = "Everblue is a shipping comapny that used their expertise to craft very high capacity magazines.",
        BulletTypes = new BulletTypeD[] { },
        Elements = new ElementD[] { },
        GunTypes = new GunTypeD[] { }
    };

    public static Manufacturer PrivyetTech = new Manufacturer
    {
        Name = "Privyet Tech",
        Description = "Privyet Tech is a Russian company that makes all kinds of budget friendly products. And by budget friendly, we mean ghetto quality. Literally.",
        BulletTypes = new BulletTypeD[] { BulletTypeD.Kinetic, BulletTypeD.Ray, BulletTypeD.Laser, BulletTypeD.Nail },
        Elements = new ElementD[] { ElementD.None, ElementD.Fire, ElementD.Electric, ElementD.Corrosive },
        GunTypes = new GunTypeD[] { GunTypeD.Pistol, GunTypeD.MachinePistol, GunTypeD.Revolver, GunTypeD.SMG, GunTypeD.Rifle, GunTypeD.AutoShotgun, GunTypeD.PumpShotgun, GunTypeD.Sniper, GunTypeD.Marksman_Rifle, GunTypeD.LMG, GunTypeD.Nailgun }
    };

    public static Manufacturer Yuzuki = new Manufacturer
    {
        Name = "Yuzuki",
        Description = "Yuzuki is a Japanese company that makes high quality firearms with a focus on precision and reliability. They are known for their innovative designs and use of advanced materials.",
        BulletTypes = new BulletTypeD[] { BulletTypeD.Kinetic, BulletTypeD.Ray, BulletTypeD.Laser },
        Elements = new ElementD[] { ElementD.None, ElementD.Fire, ElementD.Electric, ElementD.Corrosive },
        GunTypes = new GunTypeD[] { GunTypeD.Pistol, GunTypeD.MachinePistol, GunTypeD.Revolver, GunTypeD.SMG, GunTypeD.Rifle, GunTypeD.AutoShotgun, GunTypeD.PumpShotgun, GunTypeD.Sniper, GunTypeD.Marksman_Rifle, GunTypeD.LMG }
    };

    public static Manufacturer NegativeZero = new Manufacturer
    {
        Name = "Negative Zero",
        Description = "If you see a gun made by Negative Zero, run. Just run. The devs of this game hand-made it.",
        Elements = new ElementD[] { },
        BulletTypes = new BulletTypeD[] { },
        GunTypes = new GunTypeD[] { }
    };
}