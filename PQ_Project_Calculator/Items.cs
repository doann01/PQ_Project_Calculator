namespace PQ_Project_Calculator
{
    public class Items
    {
        public Dictionary<string, int> OnUseStats { get; set; } = new();
        public bool PassiveFlag { get; set; } = false;
        public string ItemName { get; set; } = "";
        public Items ItemPassive { get; set; }
        public string PassiveTypeCheck { get; set; } = "";
        public Passives Passive { get; set; }

        //Passive Section
        //Apparently if i want to store things in json i need to keep them in weapons and that indirectly means i need to keep these in items
        //i have changed the structure will try to work towards that

        public Items() { }
        public Items(bool passive, string itemName, Dictionary<string, int>? onUseStats) 
        {
            PassiveFlag = passive;
            ItemName = itemName;
            OnUseStats = onUseStats is not null
                ? new Dictionary<string, int>(onUseStats)
                : new Dictionary<string, int>();
        }
        
    }
}
