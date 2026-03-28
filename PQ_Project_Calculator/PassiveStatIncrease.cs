using System;
using System.Collections.Generic;
using System.Text;

namespace PQ_Project_Calculator
{
    internal class PassiveStatIncrease:Passives
    {
        public StatTypes StatType { get; set; }
        public override Stats Apply(Stats stats)
        {
            if (!Enable) return stats;

            switch (StatType)
            {
                case StatTypes.Vit:
                    stats.Vit += Convert.ToInt16(Value);
                    break;
                case StatTypes.Wis:
                    stats.Wis += Convert.ToInt16(Value);
                    break;
                case StatTypes.Def:
                    stats.Def += Convert.ToInt16(Value);
                    break;
                case StatTypes.Dex:
                    stats.Dex += Convert.ToInt16(Value);
                    break;
                case StatTypes.Atk:
                    stats.Atk += Convert.ToInt16(Value);
                    break;
                case StatTypes.Spd:
                    stats.Spd += Convert.ToInt16(Value);
                    break;
                case StatTypes.Mp:
                    stats.Mp += Value;
                    break;
                case StatTypes.Hp:
                    stats.Hp += Value;
                    break;
                case StatTypes.HpCurrent:
                    stats.HpCurrent += Convert.ToInt16(Value);
                    break;
                case StatTypes.MpCurrent:
                    stats.MpCurrent += Convert.ToInt16(Value);
                    break;
                default:
                    return stats;
            }
            
            return stats;
        } 
    }
}
