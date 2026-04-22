using System;
using System.Collections.Generic;
using System.Text;

namespace PQ_Project_Calculator
{
    public class Accessories:Items
    {
        public List<Damage> Damages { get; set; } = new();
        public Dictionary<string, int> Shots { get; set; } = new();

        public Accessories() { }

        public Accessories(Dictionary<string, int> shots, bool passive, string itemName, Dictionary<string, int> onUseStats)
            : base(passive, itemName, onUseStats)
        {
            Shots = shots ?? new Dictionary<string, int>();
        }
    }

    public enum AccessoryTypes
    {
        Pendant,
        Hat,
        Crown,
        Gauntlet,
        Bracelet,
        Helmet,
        Ring,
        Belt,
        Boot
    }
}
