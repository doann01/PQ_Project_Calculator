namespace PQ_Project_Calculator
{
    internal class Items
    {
        public Dictionary<string, int> OnUseStats { get; set; } = new();
        public bool Passive { get; set; } = false;
        public string ItemName { get; set; } = "";
        public Passives ItemPassive { get; set; }

        public Items() { }

        public Items(bool passive, string itemName, Dictionary<string, int>? onUseStats)
        {
            Passive = passive;
            ItemName = itemName;
            OnUseStats = onUseStats is not null
                ? new Dictionary<string, int>(onUseStats)
                : new Dictionary<string, int>();
        }

        public virtual Damage ApplyPassive(Damage dmg, Stats stats)
        {
            return dmg;
        }
    }
}
