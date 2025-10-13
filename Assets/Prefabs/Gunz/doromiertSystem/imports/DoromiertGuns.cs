namespace DoromiertSystem
{
    public enum BulletTypeD { Kinetic, Ray, Laser, Nail, Grenade, Rocket, Audio, Ink }
    public enum ElementD { None, Fire, Electric, Corrosive, Explosive, Audio }
    public enum GunTypeD { Pistol, MachinePistol, Revolver, SMG, Rifle, Torpedo, AutoShotgun, PumpShotgun, Sniper, Marksman_Rifle, LMG, Rocket_Launcher, Grenade_Launcher, Nailgun, Pen }
    public enum RarityD { Common, Uncommon, Rare, Epic, Legendary, Fusion, Perfect }
    public enum AttachmentType { Barrel, Stock, Magazine, Sight, Grip, Tip, Ink_Reservoir, Choke }

    public class Manufacturer
    {
        public string Name;
        public string Description;
        public BulletTypeD[] BulletTypes;
        public ElementD[] Elements;
        public GunTypeD[] GunTypes;
    }

    public class Attachment
    {
        public string Name;
        public string Description;
        public AttachmentType Type;
        public ElementD Element;
        public float Score;
    }

    public class Barrel : Attachment
    {
        public AttachmentType Type = AttachmentType.Barrel;
        public float AccuracyModifier;
        public float RangeModifier;
    }

    public class Stock : Attachment
    {
        public AttachmentType Type = AttachmentType.Stock;
        public float RecoilModifier;
        public float StabilityModifier;
    }

    public class Magazine : Attachment
    {
        public AttachmentType Type = AttachmentType.Magazine;
        public int MagazineSizeModifier;
        public float ReloadSpeedModifier;
    }

    public class Sight : Attachment
    {
        public AttachmentType Type = AttachmentType.Sight;
        public float ZoomLevel;
        public float AccuracyModifier;
    }

    public class Grip : Attachment
    {
        public AttachmentType Type = AttachmentType.Grip;
        public float RecoilModifier;
        public float HandlingModifier;
    }

    public class Tip : Attachment
    {
        public AttachmentType Type = AttachmentType.Tip;
        public float DamageModifier;
    }

    public class Ink_Reservoir : Attachment
    {
        public AttachmentType Type = AttachmentType.Ink_Reservoir;
        public int MagazineSizeModifier;
        public float ReloadSpeedModifier;
    }

    public class Choke : Attachment
    {
        public AttachmentType Type = AttachmentType.Choke;
        public float SpreadModifier;
        public float RangeModifier;
        public bool IsPumpShotgunOnly = true;
    }

    public class Gun
    {
        public GunTypeD GunType;
        public Manufacturer Manufacturer;
        public RarityD Rarity;
        public ElementD Element;
        public BulletTypeD BulletType;
        public int Damage;
        public float FireRate;
        public float ReloadSpeed;
        public int MagazineSize;
        public float Accuracy;
        public float Recoil;
        public float Range;
        public float CriticalChance;
        public float CriticalMultiplier;
        public float Spread;
        public string Description;
        public string Name;
    }

    // Gun type classes (shortened for brevity, add others as needed)
    public class AutoShotgunD : Gun
    {
        public GunTypeD GunType = GunTypeD.AutoShotgun;
        public struct attachments
        {
            public Barrel Barrel;
            public Stock Stock;
            public Magazine Magazine;
            public Sight Sight;
            public Grip Grip;
            public Choke Choke;
        }
    }

    public class PumpShotgunD : Gun
    {
        public GunTypeD GunType = GunTypeD.PumpShotgun;
        public float Spread;
        public struct attachments
        {
            public Barrel Barrel;
            public Stock Stock;
            public Sight Sight;
            public Grip Grip;
            public Choke Choke;
        }
    }

    // ...add other gun classes here...
}