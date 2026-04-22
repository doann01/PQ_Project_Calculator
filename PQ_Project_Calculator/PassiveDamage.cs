using System;
using System.Collections.Generic;
using System.Text;

namespace PQ_Project_Calculator
{
    public class PassiveDamage:Passives
    {
        public bool IsAtkScaling { get; set; }
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
            NegativeEffect = weapon.NegativeEffect; //Handle "burn/negative on hit" here. Poison as well
                                                    //( I will totally delay poison as long as i can :) )
            
            if (IsAtkScaling){
                damageMin *= (stats.Atk / 100m + 1);
                damageMax *= (stats.Atk / 100m + 1);
            }
            dmg.Min += damageMin;
            dmg.Max += damageMax;
            return dmg;
        }
    }
}
