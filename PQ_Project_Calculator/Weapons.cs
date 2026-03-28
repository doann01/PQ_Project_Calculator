using System;
using System.Collections.Generic;
using System.Text;

namespace PQ_Project_Calculator
{
    internal class Weapons : Items
    {
        public List<Damage> Damages { get; set; } = new();
        public decimal FireRate { get; set; } = 0M;
        public Dictionary<string, int> Shots { get; set; } = new();
        public NegativeEffects NegativeEffect { get; set; }
        public PositiveEffects PositiveEffect { get; set; }
        public WeaponTypes WeaponType { get; set; }


        public Weapons() { }

        public Weapons(decimal fireRate, Dictionary<string, int> shots, bool passive, string itemName, Dictionary<string, int> onUseStats)
            : base(passive, itemName, onUseStats)
        {
            FireRate = fireRate;
            Shots = shots ?? new Dictionary<string, int>();
        }
    }
    internal enum WeaponTypes
    {
        Sword,
        Bow,
        Axe,
        Staff,
        Dagger
    }
}
