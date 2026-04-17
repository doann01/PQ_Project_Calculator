using System;
using System.Collections.Generic;
using System.Text;

namespace PQ_Project_Calculator
{
    internal class PassivecalcBuff:Passives
    {
        public DamageTypes DamageType { get; set; }
        public WeaponTypes WeaponType { get; set; }
        public AbilityTypes AbilityType { get; set; }
        public ArmorTypes ArmorType { get; set; }
        public AccessoryTypes AccessoryType { get; set; }
        public calcBuffTypes DmgBuffType { get; set; }

        public override Damage Apply(Damage dmg)
        {
            if (!Enable) return dmg;

            decimal calc = (Value / 100m + 1) * (ApplyChance / 100m);

            switch (DmgBuffType)
            {
                case calcBuffTypes.DmgType:
                    switch (DamageType)
                    {
                        case DamageTypes.Burn:
                        case DamageTypes.Normal:
                            dmg.Min *= calc;
                            dmg.Min *= calc;
                            break;
                        default:
                            break;
                    }
                    break;
                case calcBuffTypes.Weapon:
                    switch(WeaponType)
                    {
                        case WeaponTypes.Axe:
                        case WeaponTypes.Bow:
                        case WeaponTypes.Dagger:
                        case WeaponTypes.Staff:
                        case WeaponTypes.Sword:
                            dmg.Min *= calc;
                            dmg.Min *= calc;
                            break;
                        default:
                            break;
                    }
                    break;
                case calcBuffTypes.Ability:
                    switch (AbilityType)
                    {
                        case AbilityTypes.Bomb:
                        case AbilityTypes.Totem:
                        case AbilityTypes.Flag:
                        case AbilityTypes.Spell:
                            dmg.Min *= calc;
                            dmg.Min *= calc;
                            break;
                    }
                    break;

                case calcBuffTypes.Armor:
                    switch (ArmorType)
                    {
                        case ArmorTypes.Heavy:
                        case ArmorTypes.Leather:
                        case ArmorTypes.Robe:
                            dmg.Min *= calc;
                            dmg.Min *= calc;
                            break;
                        default:
                            break;
                    }
                    break;

                case calcBuffTypes.Accessory:
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
                            dmg.Min *= calc;
                            dmg.Min *= calc;
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

    internal enum calcBuffTypes
    {
        Weapon, Ability, Armor, Accessory, DmgType
    }

}

