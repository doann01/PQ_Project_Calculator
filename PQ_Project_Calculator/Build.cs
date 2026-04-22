using System;
using System.Collections.Generic;
using System.Text;

namespace PQ_Project_Calculator
{
    public class Build
    {
        public decimal FinalDamage { get; set; }
        public Passives ItemPassive { get; set; }
        public Weapons Weapon { get; set; }
        public Abilities ActiveItem { get; set; }
        public Armors Armor { get; set; }
        public Accessories Accessory { get; set; }
        public Build()
        {
            
        }

        private void AddStats(Stats stats, Dictionary<string, int> onUse)
        {
            if (onUse == null) return;

            foreach(var stat in onUse)
            {
                switch (stat.Key)
                {
                    case "Vit": stats.Vit += stat.Value; break;
                    case "Wis": stats.Wis += stat.Value; break;
                    case "Def": stats.Def += stat.Value; break;
                    case "Dex": stats.Dex += stat.Value; break;
                    case "Atk": stats.Atk += stat.Value; break;
                    case "Spd": stats.Spd += stat.Value; break;
                    case "Mp": stats.Mp += stat.Value; break;
                    case "Hp": stats.Hp += stat.Value; break;
                }
            }

        }

        public Stats TotalStats(Stats baseStats)
        {
            Stats total = new Stats(baseStats);


            AddStats(total, Weapon.OnUseStats);
            AddStats(total, ActiveItem.OnUseStats);
            AddStats(total, Armor.OnUseStats);
            AddStats(total, Accessory.OnUseStats);

            return total;
        }

        public decimal DamageCalcFinal(Damage dmg, Stats stats)
        {
            decimal def0 = dmg.DamageCalcAvg(stats, 0);

            FinalDamage = def0 * (stats.Dex / 100m + 1) * Weapon.FireRate * Weapon.Shots.Count;

            return FinalDamage;
        }
    }
}
