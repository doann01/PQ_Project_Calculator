using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PQ_Project_Calculator
{
    public class DmgPipeline
    {
        public Build build = new Build();
        public PassiveDamageBuff DamageBuff = new PassiveDamageBuff();
        public PassiveDamage PassiveDamage = new PassiveDamage();
        public PassiveStatDecrease statDecrease = new PassiveStatDecrease();
        public PassiveStatIncrease statIncrease = new PassiveStatIncrease();

        public Stats CalculateStats(Stats stats, Items item)
        {
            if (!item.Passive)
                return stats;

            switch (item.PassiveTypeCheck)
            {

                case "StatInc":
                    stats = statIncrease.Apply(stats);
                    break;
                case "StatDec":
                    stats = statDecrease.Apply(stats);
                    break;
                default:
                    break;

            }

            return stats;
        }

        public Damage CalculateDamage(Damage dmg, Stats stats, Weapons weapon, int enemyDef, Items item)
        {
            if (!item.Passive)
                return dmg;

            dmg.Min = build.BuildDpsMin(dmg, stats);
            dmg.Max = build.BuildDpsMax(dmg, stats);

            switch (item.PassiveTypeCheck)
            {
                case "PDamage":
                    dmg = PassiveDamage.Apply(dmg, stats, weapon, enemyDef) ;
                    break;
                case "DamageIncrease":
                    dmg = DamageBuff.Apply(dmg);
                    break;
                default:
                    break;
            }
            return dmg;
        }   


        public void DamageStatCalc(Damage dmg, Stats stats, Weapons weapon, int enemyDef, Items item)
        {
            CalculateStats(stats, item);
            CalculateDamage(dmg, stats, weapon, enemyDef, item);
        }
        
    }
}
