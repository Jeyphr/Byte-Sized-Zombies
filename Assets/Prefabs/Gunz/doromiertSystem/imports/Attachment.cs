using System;

public class Attachment {
    public string Name;
    public string Description;
    public ManufacturerD Manufacturer;
    public AttachmentType Type;
    public ElementD Element;
    public Rarity Rarity;
    public float Score;
}

public class Barrel : Attachment {
    public AttachmentType Type = AttachmentType.Barrel;
    public float AccuracyModifier;
    public float RangeModifier;
}

public class Stock : Attachment {
    public AttachmentType Type = AttachmentType.Stock;
    public float RecoilModifier;
    public float StabilityModifier;
}

public class Magazine : Attachment {
    public AttachmentType Type = AttachmentType.Magazine;
    public int MagazineSizeModifier;
    public float ReloadSpeedModifier;
}

public class Sight : Attachment {
    public AttachmentType Type = AttachmentType.Sight;
    public float ZoomLevel;
    public float AccuracyModifier;
}

public class Grip : Attachment {
    public AttachmentType Type = AttachmentType.Grip;
    public float RecoilModifier;
    public float HandlingModifier;
}

public class Tip : Attachment {
    public AttachmentType Type = AttachmentType.Tip;
    public float DamageModifier;
}

public class Ink_Reservoir : Attachment {
    public AttachmentType Type = AttachmentType.Ink_Reservoir;
    public int MagazineSizeModifier;
    public float ReloadSpeedModifier;
}

public class Amplifier : Attachment {
    public AttachmentType Type = AttachmentType.Amplifier;
    public float DamageModifier;
    public float RangeModifier;
}

public class AmplifierPreset {
    public string Name;
    public string Description;
    public ManufacturerD Manufacturer;
    public ElementD Element;
    public Rarity Rarity;
    public float DamageMin, DamageMax;
    public float RangeMin, RangeMax;
}

public class Choke : Attachment {
    public AttachmentType Type = AttachmentType.Choke;
    public float SpreadModifier;
    public float RangeModifier;
}

public class BarrelPreset {
    public string Name;
    public string Description;
    public ManufacturerD Manufacturer;
    public ElementD Element;
    public Rarity Rarity;
    public float AccuracyMin, AccuracyMax;
    public float RangeMin, RangeMax;
}

public class StockPreset {
    public string Name;
    public string Description;
    public ManufacturerD Manufacturer;
    public ElementD Element;
    public Rarity Rarity;
    public float RecoilMin, RecoilMax;
    public float StabilityMin, StabilityMax;
}

public class MagazinePreset {
    public string Name;
    public string Description;
    public ManufacturerD Manufacturer;
    public ElementD Element;
    public Rarity Rarity;
    public int MagazineSizeMin, MagazineSizeMax;
    public float ReloadSpeedMin, ReloadSpeedMax;
}

public class SightPreset {
    public string Name;
    public string Description;
    public ManufacturerD Manufacturer;
    public ElementD Element;
    public Rarity Rarity;
    public float ZoomMin, ZoomMax;
    public float AccuracyMin, AccuracyMax;
}

public class GripPreset {
    public string Name;
    public string Description;
    public ManufacturerD Manufacturer;
    public ElementD Element;
    public Rarity Rarity;
    public float RecoilMin, RecoilMax;
    public float HandlingMin, HandlingMax;
}

public class TipPreset {
    public string Name;
    public string Description;
    public ManufacturerD Manufacturer;
    public ElementD Element;
    public Rarity Rarity;
    public float DamageMin, DamageMax;
}

public class InkReservoirPreset {
    public string Name;
    public string Description;
    public ManufacturerD Manufacturer;
    public ElementD Element;
    public Rarity Rarity;
    public int MagazineSizeMin, MagazineSizeMax;
    public float ReloadSpeedMin, ReloadSpeedMax;
}

public class ChokePreset {
    public string Name;
    public string Description;
    public ManufacturerD Manufacturer;
    public ElementD Element;
    public Rarity Rarity;
    public float SpreadMin, SpreadMax;
    public float RangeMin, RangeMax;
    public bool IsPumpShotgunOnly = true;
}

public static class AttachmentFactory {
    private static Random rng = new Random();

    public static Barrel CreateBarrel(BarrelPreset preset) {
        return new Barrel {
            Name = preset.Name,
            Description = preset.Description,
            Manufacturer = preset.Manufacturer,
            Element = preset.Element,
            Rarity = preset.Rarity,
            AccuracyModifier = RandomRange(preset.AccuracyMin, preset.AccuracyMax),
            RangeModifier = RandomRange(preset.RangeMin, preset.RangeMax)
        };
    }

    public static Stock CreateStock(StockPreset preset) {
        return new Stock {
            Name = preset.Name,
            Description = preset.Description,
            Manufacturer = preset.Manufacturer,
            Element = preset.Element,
            Rarity = preset.Rarity,
            RecoilModifier = RandomRange(preset.RecoilMin, preset.RecoilMax),
            StabilityModifier = RandomRange(preset.StabilityMin, preset.StabilityMax)
        };
    }

    public static Magazine CreateMagazine(MagazinePreset preset) {
        return new Magazine {
            Name = preset.Name,
            Description = preset.Description,
            Manufacturer = preset.Manufacturer,
            Element = preset.Element,
            Rarity = preset.Rarity,
            MagazineSizeModifier = RandomIntRange(preset.MagazineSizeMin, preset.MagazineSizeMax),
            ReloadSpeedModifier = RandomRange(preset.ReloadSpeedMin, preset.ReloadSpeedMax)
        };
    }

    public static Sight CreateSight(SightPreset preset) {
        return new Sight {
            Name = preset.Name,
            Description = preset.Description,
            Manufacturer = preset.Manufacturer,
            Element = preset.Element,
            Rarity = preset.Rarity,
            ZoomLevel = RandomRange(preset.ZoomMin, preset.ZoomMax),
            AccuracyModifier = RandomRange(preset.AccuracyMin, preset.AccuracyMax)
        };
    }

    public static Grip CreateGrip(GripPreset preset) {
        return new Grip {
            Name = preset.Name,
            Description = preset.Description,
            Manufacturer = preset.Manufacturer,
            Element = preset.Element,
            Rarity = preset.Rarity,
            RecoilModifier = RandomRange(preset.RecoilMin, preset.RecoilMax),
            HandlingModifier = RandomRange(preset.HandlingMin, preset.HandlingMax)
        };
    }

    public static Tip CreateTip(TipPreset preset) {
        return new Tip {
            Name = preset.Name,
            Description = preset.Description,
            Manufacturer = preset.Manufacturer,
            Element = preset.Element,
            Rarity = preset.Rarity,
            DamageModifier = RandomRange(preset.DamageMin, preset.DamageMax)
        };
    }

    public static Ink_Reservoir CreateInkReservoir(InkReservoirPreset preset) {
        return new Ink_Reservoir {
            Name = preset.Name,
            Description = preset.Description,
            Manufacturer = preset.Manufacturer,
            Element = preset.Element,
            Rarity = preset.Rarity,
            MagazineSizeModifier = RandomIntRange(preset.MagazineSizeMin, preset.MagazineSizeMax),
            ReloadSpeedModifier = RandomRange(preset.ReloadSpeedMin, preset.ReloadSpeedMax)
        };
    }

    public static Choke CreateChoke(ChokePreset preset) {
        return new Choke {
            Name = preset.Name,
            Description = preset.Description,
            Manufacturer = preset.Manufacturer,
            Element = preset.Element,
            Rarity = preset.Rarity,
            SpreadModifier = RandomRange(preset.SpreadMin, preset.SpreadMax),
            RangeModifier = RandomRange(preset.RangeMin, preset.RangeMax),
        };
    }

    private static float RandomRange(float min, float max) {
        return (float)(min + rng.NextDouble() * (max - min));
    }

    private static int RandomIntRange(int min, int max) {
        return rng.Next(min, max + 1);
    }
}