using UnityEngine;
using lootUtils.Manufacturers;
using lootUtils.Bullets;
using lootUtils.Parts;

namespace lootUtils.Guns
{
    /// <summary>
    /// Handles the generation of loot items such as guns, shields, and parts.
    /// </summary>
    public class LootGenerator : MonoBehaviour
    {
        #region Generation Methods
        /// <summary>
        /// Guns are generated in this order:
        /// 1. Pick a manufacturer
        /// 2. Pick a gun type allowed by that manufacturer
        /// 3. Pick a bullet type allowed by that manufacturer
        /// 4. Pick an element type allowed by that manufacturer
        /// 5. Generate parts for the gun
        /// 6. Calculate the gun score based on its parts
        /// 7. Set the gun's rarity based on its score
        /// 8. Name the gun based on its manufacturer and best part
        /// </summary>
        /// <returns></returns>
        public Gun generateGun()
        {
            LootGenerator lootGenerator = new LootGenerator();
            Gun gun = new Gun();

            // 1. Pick a manufacturer
            Manufacturer manufacturer = lootGenerator.pickManufacturer();
            gun.manufacturer = manufacturer;

            // 2. Pick a gun type allowed by that manufacturer
            GunType gunType = lootGenerator.pickGunType(manufacturer);
            gun.gunType = gunType;

            // 3. Pick a bullet type allowed by that manufacturer
            BulletType bulletType = lootGenerator.pickBulletType(manufacturer);

            // 4. Pick an element type allowed by that manufacturer
            ElementType elementType = lootGenerator.pickElementType(manufacturer);

            // 5. Generate parts for the gun
            Part[] gunParts = lootGenerator.generateParts(manufacturer, gunType);
            gun.gunParts = gunParts;

            // 6. Calculate the gun score based on its parts
            int gunScore = lootGenerator.calculateGunScore(gun);
            gun.gunScore = gunScore;

            // 7. Set the gun's rarity based on its score
            WeaponRarity weaponRarity = lootGenerator.setWeaponRarity(gunScore);
            gun.weaponRarity = weaponRarity;

            // 8. Name the gun based on its manufacturer and best part
            Part bestPart = lootGenerator.findBestPart(gunParts);
            gun.gunName = $"{manufacturer.manufacturerName} {bestPart.partName} {gunType.ToString()}";
            return gun;
        }
        #endregion



        #region Part Methods

        // Weapon score is the sum of its parts' scores
        public int calculateGunScore(Gun gun)
        {
            int score = 0;
            foreach (Part part in gun.gunParts)
            {
                score += part.partScore;
            }
            return score;
        }

        public WeaponRarity setWeaponRarity(int score)
        {
            switch (score)
            {
                case int n when (n >= 0 && n < 20):
                    return WeaponRarity.Common;
                case int n when (n >= 20 && n < 40):
                    return WeaponRarity.Uncommon;
                case int n when (n >= 40 && n < 60):
                    return WeaponRarity.Rare;
                case int n when (n >= 60 && n < 80):
                    return WeaponRarity.Epic;
                case int n when (n >= 80):
                    return WeaponRarity.Legendary;
                default:
                    return WeaponRarity.Common;
            }
        }

        // Weapon is named after its best part
        public Part findBestPart(Part[] parts)
        {
            Part bestPart = null;
            int highestScore = -1;
            foreach (Part part in parts)
            {
                if (part.partScore > highestScore)
                {
                    highestScore = part.partScore;
                    bestPart = part;
                }
            }
            return bestPart;
        }   

        /// <summary>
        /// Guns need one of each part:
        /// barrel, stock, optic, magazine, grip.
        /// 
        /// These parts must have Part Attribute Tokens to give them
        /// stat changing abilities to the weapons.
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <param name="gunType"></param>
        /// <returns></returns>
        public Part[] generateParts(Manufacturer manufacturer, GunType gunType)
        {
            Part[] parts = new Part[5];
            foreach (PartType partType in System.Enum.GetValues(typeof(PartType)))
            {
                Part part = new Part();
                part.partType = partType;
                parts[(int)partType] = part;
            }
            return parts;
        }
        #endregion



        #region Picker Methods
        // Randomly picks a manufacturer from the list of manufacturers
        // Negative Zero Inc is NOT allowed to be picked here
        public Manufacturer pickManufacturer()
        {
            Manufacturer manufacturer = new Manufacturer();
            int randomIndex = Random.Range(0, (manufacturer.manufacturers.Length - 1));
            manufacturer = manufacturer.manufacturers[randomIndex];
            return manufacturer;
        }

        public ElementType pickElementType(Manufacturer manufacturer)
        {
            ElementType elementType = ElementType.NonElemental;
            int randomIndex = Random.Range(0, (manufacturer.allowedElementTypes.Length));
            elementType = manufacturer.allowedElementTypes[randomIndex];
            return elementType;
        }

        public BulletType pickBulletType(Manufacturer manufacturer)
        {
            BulletType bulletType = BulletType.Kinetic;
            int randomIndex = Random.Range(0, (manufacturer.allowedBulletTypes.Length));
            bulletType = manufacturer.allowedBulletTypes[randomIndex];
            return bulletType;
        }

        public GunType pickGunType(Manufacturer manufacturer)
        {
            GunType gunType = GunType.Pistol;
            int randomIndex = Random.Range(0, (manufacturer.allowedGunTypes.Length));
            gunType = manufacturer.allowedGunTypes[randomIndex];
            return gunType;
        }
        #endregion



        #region General Methods
        void Start()
        {
            for (int i = 0; i < 5; i++)
            {
                Gun generatedGun = generateGun();
                Debug.Log(generatedGun.ToString());
            }
        }
        #endregion

    }
}