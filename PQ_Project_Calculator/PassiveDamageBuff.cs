using System;
using System.Collections.Generic;
using System.Text;

namespace PQ_Project_Calculator
{
    internal class PassiveDamageBuff:Passives
    {
        public DamageTypes DamageType { get; set; }
        public WeaponTypes WeaponType { get; set; }
        public AbilityTypes AbilityType { get; set; }
        public ArmorTypes ArmorType { get; set; }
        public AccessoryTypes AccessoryType { get; set; }
        public DamageBuffTypes DmgBuffType { get; set; }

        public override Damage Apply(Damage dmg)
        {
            if (!Enable) return dmg;

            switch (DmgBuffType)
            {
                case DamageBuffTypes.DmgType:
                    switch (DamageType)
                    {
                        case DamageTypes.Burn:
                        case DamageTypes.Normal:
                            decimal damage = (Value / 100m + 1) * (ApplyChance / 100m);
                            dmg.Min *= damage;
                            dmg.Min *= damage;
                            break;
                        default:
                            break;
                    }
                    break;
                case DamageBuffTypes.Weapon:
                    switch(WeaponType)
                    {
                        case WeaponTypes.Axe:
                        case WeaponTypes.Bow:
                        case WeaponTypes.Dagger:
                        case WeaponTypes.Staff:
                        case WeaponTypes.Sword:
                            decimal damage = (Value / 100m + 1) * (ApplyChance / 100m);
                            dmg.Min *= damage;
                            dmg.Min *= damage;
                            break;
                        default:
                            break;
                    }
                    break;
                case DamageBuffTypes.Ability:
                    switch (AbilityType)
                    {
                        case AbilityTypes.Bomb:
                        case AbilityTypes.Totem:
                        case AbilityTypes.Flag:
                        case AbilityTypes.Spell:
                            decimal damage = (Value / 100m + 1) * (ApplyChance / 100m);
                            dmg.Min *= damage;
                            dmg.Min *= damage;
                            break;
                    }
                    break;

                case DamageBuffTypes.Armor:
                    switch (ArmorType)
                    {
                        case ArmorTypes.Heavy:
                        case ArmorTypes.Leather:
                        case ArmorTypes.Robe:
                            decimal damage = (Value / 100m + 1) * (ApplyChance / 100m);
                            dmg.Min *= damage;
                            dmg.Min *= damage;
                            break;
                        default:
                            break;
                    }
                    break;

                case DamageBuffTypes.Accessory:
                    switch (AccessoryType)
                    {
                        case AccessoryTypes.Boot:
                        case AccessoryTypes.Crown:
                        case AccessoryTypes.Hat:
                        case AccessoryTypes.Ring:
                        case AccessoryTypes.Pendant:
                        case AccessoryTypes.Belt:
                        case AccessoryTypes.Gauntlet:
                        case AccessoryTypes.Bracelet:
                        case AccessoryTypes.Helmet:
                            decimal damage = (Value / 100m + 1) * (ApplyChance / 100m);
                            dmg.Min *= damage;
                            dmg.Min *= damage;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            return dmg;
        }
    }

    internal enum DamageBuffTypes
    {
        Weapon, Ability, Armor, Accessory, DmgType
    }

}

