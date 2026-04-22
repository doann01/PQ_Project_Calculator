using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PQ_Project_Calculator
{
    public class Damage
    {
        public decimal Min { get; set; }
        public decimal Max { get; set; }
        public Dictionary<string, decimal> StatScaling { get; set; } = new();
        public decimal Average => (Max + Min) / 2;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DamageTypes Type { get; set; }
        private decimal DamageCalc(decimal damage, Stats stats, int enemyDef)
        {
            decimal dmg = damage;

            foreach (var statscale in StatScaling)
            {   
                decimal statValue = statscale.Key switch
                {
                    "Vit" => stats.Vit,
                    "Wis" => stats.Wis,
                    "Def" => stats.Def,
                    "Dex" => stats.Dex,
                    "Atk" => stats.Atk,
                    "Spd" => stats.Spd,
                    "Mp" => stats.Mp,
                    "Hp" => stats.Hp,
                    _ => 0
                };
                dmg += statValue * statscale.Value;
            }

            switch (Type)
            {
                case DamageTypes.Normal:
                    dmg = (dmg - enemyDef) * (stats.Atk/100m + 1);
                    break;
                case DamageTypes.True:
                    dmg = dmg * (stats.Atk / 100m + 1);
                    break;
                case DamageTypes.Burn:
                    break;
                case DamageTypes.Bleed:
                    dmg = (dmg - enemyDef);
                    break;
                default:
                    break;
            }
            return dmg;
        }

        public decimal DamageCalcMin(Stats stats, int enemyDef)
        {
            return DamageCalc(Min, stats, enemyDef);
        }
        public decimal DamageCalcMax(Stats stats, int enemyDef)
        {
            return DamageCalc(Max, stats, enemyDef);
        }

        public decimal DamageCalcAvg(Stats stats, int enemyDef)
        {
            return DamageCalc(Average, stats, enemyDef);
        }
    }

    public enum DamageTypes
    {
        Normal,
        True,
        Percent40,
        Percent60,
        Burn,
        Bleed,
        Posion //I dont know how poison work so i think i will keep it empty until the release(?).
            //or i can just gather info from others but :/
    }
}

