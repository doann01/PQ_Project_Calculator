using System;
using System.Collections.Generic;
using System.Text;

namespace PQ_Project_Calculator
{
    internal class PassiveStatDecrease:Passives
    {
        public StatTypes StatType { get; set; }
        public override Stats Apply(Stats stats)
        {
            if (!Enable) return stats;

            switch (StatType)
            {
                case StatTypes.Hp:
                    stats.Hp -= Value;
                    break;
                case StatTypes.Mp:
                    stats.Mp -= Value;
                    break;
                default:
                    return stats;
            }

            return stats;
        }
    }
}
