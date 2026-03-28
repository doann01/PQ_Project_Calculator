using System;
using System.Collections.Generic;
using System.Text;

namespace PQ_Project_Calculator
{
    internal class Abilities:Items
    {
        public List<Damage> Damages { get; set; } = new();
        public int MPCost { get; set; } = 0;
        public int shots { get; set; }
        public decimal Cooldown { get; set; }
        public DateTime LastUsed { get; set; }

        public Abilities() { }

        public Abilities(int mpCost, int shots, decimal cooldown, DateTime lastUsed, bool passive, string itemName, Dictionary<string, int> onUseStats)
            : base(passive, itemName, onUseStats)
        {
            MPCost = mpCost;
            this.shots = shots;
            Cooldown = cooldown;
            LastUsed = lastUsed;
        }
    }

    internal enum AbilityTypes
    {
        Totem,
        Spell,
        Bomb,
        Flag
    }
}
