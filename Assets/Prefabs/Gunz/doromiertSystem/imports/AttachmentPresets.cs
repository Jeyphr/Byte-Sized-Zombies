public static class AttachmentPresets {
    public static BarrelPreset SkybydyBarrel = new BarrelPreset {
        Name = "SkyByDy Precision Tap",
        Description = "High accuracy tap-shaped barrel from Skybydy.",
        Manufacturer = Manufacturers.SkyByDyToilets,
        Element = ElementD.None,
        Rarity = Rarity.Rare,
        AccuracyMin = 0.05f,
        AccuracyMax = 0.10f,
        RangeMin = 0.05f,
        RangeMax = 0.10f
    };

    public static StockPreset HeavyStock = new StockPreset {
        Name = "Heavy Stock",
        Description = "Reduces recoil, increases stability.",
        Manufacturer = Manufacturers.PropDept,
        Element = ElementD.None,
        Rarity = Rarity.Common,
        RecoilMin = -0.10f,
        RecoilMax = -0.05f,
        StabilityMin = 0.05f,
        StabilityMax = 0.10f
    };

    public static MagazinePreset ExtendedMag = new MagazinePreset {
        Name = "Premium NewBlue Extended Mag",
        Description = "Increases magazine size.",
        Manufacturer = Manufacturers.Everblue,
        Element = ElementD.None,
        Rarity = Rarity.Uncommon,
        MagazineSizeMin = 10,
        MagazineSizeMax = 20,
        ReloadSpeedMin = -0.05f,
        ReloadSpeedMax = 0.0f
    };

    public static StockPreset Firestock = new StockPreset {
        Name = "Firestock",
        Description = "Turns your gun incendiary.",
        Manufacturer = Manufacturers.PorterToys,
        Element = ElementD.Fire,
        Rarity = Rarity.Rare,
        StabilityMin = 0.0f,
        StabilityMax = 0.0f
    };

    public static AmplifierPreset PowerAmp = new AmplifierPreset {
        Name = "Power Amplifier",
        Description = "Increases damage and range.",
        Manufacturer = Manufacturers.BBL,
        Element = ElementD.None,
        Rarity = Rarity.Uncommon,
        DamageMin = 0.10f,
        DamageMax = 0.20f,
        RangeMin = 0.05f,
        RangeMax = 0.15f
    };

    public static GripPreset RecoilGrip = new GripPreset {
        Name = "Recoil Grip",
        Description = "Reduces recoil significantly.",
        Manufacturer = Manufacturers.PropDept,
        Element = ElementD.None,
        Rarity = Rarity.Common,
        RecoilMin = -0.5f,
        RecoilMax = -0.10f,
        HandlingMin = 0.0f,
        HandlingMax = 0.0f
    };

    public static SightPreset ZoomSight = new SightPreset {
        Name = "PorterSight 4x (used)",
        Description = "Half a binocular set for children. You don't know who your bioncular buddy is.",
        Manufacturer = Manufacturers.PorterToys,
        Element = ElementD.None,
        Rarity = Rarity.Uncommon,
        AccuracyMin = 0.10f,
        AccuracyMax = 0.20f,
    };

    public static ChokePreset TightChoke = new ChokePreset {
        Name = "Tight Choke",
        Description = "Improves pellet spread.",
        Manufacturer = Manufacturers.PropDept,
        Element = ElementD.None,
        Rarity = Rarity.Rare,
        RangeMin = 0.05f,
        RangeMax = 0.15f
    };

    public static TipPreset BoomTip = new TipPreset {
        Name = "Boom Tip 3000",
        Description = "IT MAKE YRO'UE GUN GO BOOM BOOM!!! BUY NOW!!!",
        Manufacturer = Manufacturers.HablaffaIncorporated,
        Element = ElementD.Explosive,
        Rarity = Rarity.Epic,
        DamageMin = 0.15f,
        DamageMax = 0.25f
    };

    public static InkReservoirPreset LargeInkReservoir = new InkReservoirPreset {
        Name = "Fun-sized glue reservoir",
        Description = "Some people think that putting glue in your pen gun is a bad idea. Those people are wrong.",
        Manufacturer = Manufacturers.PorterToys,
        Element = ElementD.None,
        Rarity = Rarity.Uncommon,
        MagazineSizeMin = 50,
        MagazineSizeMax = 100,
        ReloadSpeedMin = -0.05f,
        ReloadSpeedMax = 0.0f
    };

    public static SightPreset HollowCup = new SightPreset {
        Name = "Hollow Coffe Cup",
        Description = "Someone cracked a coffee cup in such a way that only its bottom part broke off. It somehow works as a sight.",
        Manufacturer = Manufacturers.PenIsland,
        Element = ElementD.None,
        Rarity = Rarity.Common,
        ZoomMin = 0.05f,
        ZoomMax = 0.10f,
        AccuracyMin = 0.05f,
        AccuracyMax = 0.10f,
    };

    public static GripPreset UncomfortableGrip = new GripPreset {
        Name = "Extremely Uncomfortable Grip",
        Description = "A grip that is so extremely uncomfortable to hold that it hurts. But hey, it makes your gun a legendary, you masochist.",
        Manufacturer = Manufacturers.PrivyetTech,
        Element = ElementD.None,
        Rarity = Rarity.Legendary,
        HandlingMin = -0.10f,
        HandlingMax = -0.05f
    };

    public static ChokePreset WideChoke = new ChokePreset {
        Name = "Wide Choke",
        Description = "Open your horizons with this brand new wide choke! Now with literally NEGATIVE spread reduction!",
        Manufacturer = Manufacturers.PrivyetTech,
        Element = ElementD.None,
        Rarity = Rarity.Epic,
        RangeMin = -0.10f,
        RangeMax = -0.05f
    };

    public static BarrelPreset ProBarrel = new BarrelPreset {
        Name = "Pro Barrel",
        Description = "A barrel made for professionals. Increases accuracy and range significantly.",
        Manufacturer = Manufacturers.Yuzuki,
        Element = ElementD.None,
        Rarity = Rarity.Epic,
        AccuracyMin = 0.15f,
        AccuracyMax = 0.25f,
        RangeMin = 0.10f,
        RangeMax = 0.20f
    };

    public static TipPreset SharpTip = new TipPreset {
        Name = "Sharp Iron Tip",
        Description = "Pokey.",
        Manufacturer = Manufacturers.DoomCo,
        Element = ElementD.None,
        Rarity = Rarity.Common,
        DamageMin = 0.05f,
        DamageMax = 0.10f
    };

    public static MagazinePreset BoomMag = new MagazinePreset {
        Name = "boom boom mag plus!!",
        Description = "THIS SHIT SOMEHOW LITERALLY MAKES YOUR BULLETS EXPLOSIVE!! WE TRIED MAKING IT NOT DO SO! IT SOMEHOW TURNED OUT BEING EXPLOSIVE EVERY TIME!!!",
        Manufacturer = Manufacturers.HablaffaIncorporated,
        Element = ElementD.Explosive,
        Rarity = Rarity.Rare,
        MagazineSizeMin = 5,
        MagazineSizeMax = 10,
        ReloadSpeedMin = -0.05f,
        ReloadSpeedMax = 0.0f
    };
}