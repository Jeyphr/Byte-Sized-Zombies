public class AutoShotgunD : Gun {
    public GunTypeD GunType = GunTypeD.AutoShotgun;
    public struct attachments {
        public Barrel Barrel;
        public Stock Stock;
        public Magazine Magazine;
        public Sight Sight;
        public Grip Grip;
        public Choke Choke;
    }
}

public class PumpShotgunD : Gun {
    public GunTypeD GunType = GunTypeD.PumpShotgun;
    public float Spread;
    public struct attachments {
        public Barrel Barrel;
        public Stock Stock;
        public Sight Sight;
        public Grip Grip;
        public Choke Choke;
    }
}

public class SniperD : Gun {
    public GunTypeD GunType = GunTypeD.Sniper;
    public float Steadiness;
    public struct attachments {
        public Barrel Barrel;
        public Stock Stock;
        public Magazine Magazine;
        public Sight Sight;
        public Grip Grip;
    }
}

public class Subwoofer : Gun {
    public GunTypeD GunType = GunTypeD.Subwoofer;
    public float BassBoost;
    public struct attachments {
        public Barrel Barrel;
        public Stock Stock;
        public Magazine Magazine;
        public Sight Sight;
        public Grip Grip;
        public Amplifier Amplifier;
    }
}

// ...repeat for other gun types as in your original file...