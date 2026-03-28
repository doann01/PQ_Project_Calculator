using System;
using System.Collections.Generic;
using System.Text;

namespace PQ_Project_Calculator
{
    internal class PassiveDamage:Passives
    {
        public bool IsAtkScaling { get; set; }
        public bool IsDmgBoost { get; set; }
        public DamageTypes DamageType { get; set; }

        public override Damage Apply(Damage dmg, Stats stats, Weapons weapon, int enemyDef)
        {
            if (!Enable) return dmg;

            decimal damageMin = 0;
            decimal damageMax = 0;
            switch (DamageType)
            {
                case DamageTypes.Normal:
                    damageMin = ValueMin - enemyDef;
                    damageMax = ValueMax - enemyDef;
                    break;
                case DamageTypes.True:
                    damageMin = ValueMin;
                    damageMax = ValueMax;
                    break;
                default:
                    break;
            }
            damageMin *= weapon.FireRate * (ApplyChance / 100m) * (stats.Dex / 100m + 1);
            damageMax *= weapon.FireRate * (ApplyChance / 100m) * (stats.Dex / 100m + 1);
            if(!IsEntity && IsWeapon){ 
                damageMin *= weapon.Shots.Count;
                damageMax *= weapon.Shots.Count;
            }
            PositiveEffect = weapon.PositiveEffect; //
            NegativeEffect = weapon.NegativeEffect; //handle "burn/negative on hit" here
            
            if (IsAtkScaling){
                damageMin *= (stats.Atk / 100m + 1);
                damageMax *= (stats.Atk / 100m + 1);
            }
            if (IsDmgBoost){
                dmg.Min *= (ValueMin / 10m);
                dmg.Max *= (ValueMax / 10m);
            }
            dmg.Min += damageMin;
            dmg.Max += damageMax;
            return dmg;
        }
    }
}
