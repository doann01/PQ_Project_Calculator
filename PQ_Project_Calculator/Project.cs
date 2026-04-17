using System.Text.Json;
using System.IO;

/*
This is a reminder to myself, i will visualise the pipeline and make sure i have separate names for them which wont be original or wont actually make sense until someone really read the whole thing, it is for my own convenience cuz i can visualize the things the way i created in my mind, idk if i am going to keep it the same but i hope i do cuz it will be a bit massy, so there is different steps to dps calculations which starts in  >>>>>>>> damage at first where we use Stats Items and Damage which i will cal Dps1 (This really does make sense to me) then we have the last weapon only calculation(For now its weapon only but i will try to implement spells in here somewhere or maybe as another addition to last step of dps calculation) which is in build where we calculate the last damage of the weapon including on use stats of items and stat calculations which is called Dps2, then we have passives(A pain in the ass i wish i hardcoded them) it will add up passives of ALL items not just the weapon to give us the next dps calculation step which i call Dps3 (It might be hard to memorize them but i make them up so its easy for me) then im not sure if this is how it will work but i will try to implement a last step of calculation which is Buffs such as flag atk increases etc (The fact that multiplayer lobbies have most of the flags popped at once forces me to actually create a last step of dps calculation where i calculate outer effects on the dps or at least i think so) and its not a surprise this is Dps4. This is the end of pipeline for now in my mind, i dont know if i wil change the structure and if i do so i am pretty sure it will take a long long time so i should stick to this and also theres updates every week for the game and theres things like Posion added to the game which makes things somewhat harder for me so i hope they fail to give us great updates so i can finish this thing earlier :). I am planning on keeping this thing alive for some time(If i even finish it) cuz ive been enjoying a lot doing this small project and it really helped me with my "learning/studying" adventure so i think i will want to keep it alive. This is a bit too long and im pretty sure i will delete this but first i want to explain myself for writing such a long comment here for like no reason since i could just take a not anywhere. First thing its more convenient for me, second thing i actually struggled with the passive system a lot and creating such a pipeline in my mind and then visualizing it helped me a lot to keep going. So here i am leaving a small(Believe me this actually is small i could type all day) note to remind how things work and what is going on with the code, i keep a more detailed summary somewhere else ( Cursor writes for me i hate taking notes :) ) so this is... I was just typing so i could come back to read this and make sure the pipeline is built correct but oh boy what a yapper i am. I really am tired and unfortunately sick so i am trying to do anything but code :(. Anyways, this is the situtation right now, i am pretty sure i will finish things in these 2-3 days excluding the ui which i still dont know how to handle, i am just trying to make things work at first, again i am sick so there might be MASSIVE mistakes with this thing even on release(?) so go fucking back to see what is going on and fix them. This is a note to myself btw, i am leaving this to myself just in case and this mf vs keeps gaslighting me to write some bs ahhhhhhhhhhhhhhhhhhhhhhhhhhhh. Im dumb. (Holy fuck this is some long thing i wasnt expecting to leave such a long command lol)



  This is a whole different thing i will just type the methods i need to manually fill so i dont mess things uppppp -> Build.TotalStats(Stats), Build.DamageCalcFinal(Damage, Stats), 
*/
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
