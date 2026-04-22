using System;
using System.Collections.Generic;
using System.Text;

namespace PQ_Project_Calculator
{
    public abstract class Passives
    {
        public string PassiveName { get; set; } = "";
        public bool Enable { get; set; } = true;
        public decimal ValueMin { get; set; }
        public decimal ValueMax { get; set; }
        public decimal Value { get; set; }
        public decimal ApplyChance { get; set; }
        public NegativeEffects NegativeEffect { get; set; }
        public PositiveEffects PositiveEffect { get; set; }
        public bool IsEntity { get; set; }
        public bool IsWeapon { get; set; }
        public virtual Damage Apply(Damage dmg, Stats stats, Weapons weapons, int enemyDef)
        {
            return dmg;
        }

        public virtual Stats Apply(Stats stats)
        {
            return stats;
        }
        public virtual Damage Apply(Damage dmg)
        {
            return dmg;
        }
    }
}
