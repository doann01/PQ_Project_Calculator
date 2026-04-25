using System;
using System.Collections.Generic;
using System.Text;

namespace PQ_Project_Calculator
{
    public class Armors:Items
    {
        public Armors() { }

        public Armors(bool passive, string itemName, Dictionary<string, int> onUseStats)
            : base(passive, itemName, onUseStats)
        {
        }

    }

    public enum ArmorTypes
    {
        Heavy,
        Robe,
        Leather
    }
}
