using System;
using System.Collections.Generic;
using System.Text;

namespace PQ_Project_Calculator
{
    internal class Stats
    {
        public int Vit { get; set; }
        public int Wis { get; set; }
        public int Def { get; set; }
        public int Dex { get; set; }
        public int Atk { get; set; }
        public int Spd { get; set; }
        public decimal Mp { get; set; }
        public decimal MpCurrent { get; set; }
        public decimal Hp { get; set; }
        public decimal HpCurrent { get; set; }

        public Stats(int vit, int wis, int def, int dex, int atk, int spd, decimal mp, decimal hp)
        {
            Vit = vit;
            Wis = wis;
            Def = def;
            Dex = dex;
            Atk = atk;
            Spd = spd;
            Mp = mp;
            Hp = hp;
            HpCurrent = hp;
            MpCurrent = mp;
        }

        public Stats(Stats other)
        {
            Vit = other.Vit;
            Wis = other.Wis;
            Def = other.Def;
            Dex = other.Dex;
            Atk = other.Atk;
            Spd = other.Spd;
            Mp = other.Mp;
            Hp = other.Hp;
        }
    }

    internal enum StatTypes
    {
        Vit, Wis, Def, Dex, Atk, Spd, Mp, Hp, MpCurrent, HpCurrent
    }
}
