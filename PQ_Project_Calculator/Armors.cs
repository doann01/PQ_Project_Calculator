using System;
using System.Collections.Generic;
using System.Text;

namespace PQ_Project_Calculator
{
    internal class Armors:Items
    {
        public Armors() { }

        public Armors(bool passive, string itemName, Dictionary<string, int> onUseStats)
            : base(passive, itemName, onUseStats)
        {
        }

        public virtual Damage ApplyPassive(Damage dmg, Stats stats, Decimal PassiveFireRate)
        {

            return dmg;
        }

    }

    internal enum ArmorTypes
    {
        Heavy,
        Robe,
        Leather
    }
}
