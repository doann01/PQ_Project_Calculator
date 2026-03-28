using System.Text.Json;
using System.IO;

namespace PQ_Project_Calculator
{
    internal class Project
    {
        static void Main(string[] args)
        {

            string weaponsJson = File.ReadAllText("Weapons.json");
            List<Weapons> weapons = JsonSerializer.Deserialize<List<Weapons>>(weaponsJson); 

            string activeItemsJson = File.ReadAllText("ActiveItems.json");
            List<Abilities> activeItems = JsonSerializer.Deserialize<List<Abilities>>(activeItemsJson);

            string armorsJson = File.ReadAllText("Armors.json");
            List<Armors> armors = JsonSerializer.Deserialize<List<Armors>>(armorsJson);

            string accessoriesJson = File.ReadAllText("Accessories.json");
            List<Accessories> accessories = JsonSerializer.Deserialize<List<Accessories>>(accessoriesJson);

            Stats playerStats = new(16, 33, 7, 7, 7, 25, 180, 250);

            Build playerBuild = new Build()
            {
                Weapon = weapons[0],
                ActiveItem = activeItems[0],
                Armor = armors[1],
                Accessory = accessories[1]
            };

            Stats finalStats = playerBuild.TotalStats(playerStats);

            Console.WriteLine("Weapon stats:");

            foreach (var stat in weapons[0].OnUseStats)
            {
                Console.WriteLine($"{stat.Key} {stat.Value}");
            }

            foreach (var dmg in playerBuild.Weapon.Damages)
            {
                decimal totalDamage = playerBuild.DamageCalcFinal(dmg, finalStats);

                Console.WriteLine($"Average damage: {totalDamage}");
                Console.WriteLine($"Char stats are:");
                Console.WriteLine($"{finalStats.Dex} {finalStats.Atk}");
            }
        }
    }
}
