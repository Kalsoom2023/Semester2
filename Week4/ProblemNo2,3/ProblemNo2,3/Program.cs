using ProblemNo2.bl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProblemNo2.bl;

namespace ProblemNo2
{
    internal class Program
    {

        static List<Player> players = new List<Player>();
        static List<Stats> skillStats = new List<Stats>();

        static void Main(string[] args)
        {
            int choice = 0;
            while (choice != 6) 
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add Player");
                Console.WriteLine("2. Add Skill Statistics");
                Console.WriteLine("3. Display Player Info");
                Console.WriteLine("4. Learn a Skill");
                Console.WriteLine("5. Attack");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Addplayer();
                        break;
                    case 2:
                        AddSkillStats();
                        break;
                    case 3:
                        DisplayPlayerInfo();
                        break;
                    case 4:
                        LearnASkill();
                        break;
                    case 5:
                        Attack();
                        break;
                    case 6:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                        break;
                }
            }
        }

        static void Addplayer()
        {
            Console.Write("Enter player name: ");
            string name = Console.ReadLine();
            Console.Write("Enter health: ");
            int hp = int.Parse(Console.ReadLine());
            Console.Write("Enter max health: ");
            int maxHp = int.Parse(Console.ReadLine());
            Console.Write("Enter energy: ");
            int energy = int.Parse(Console.ReadLine());
            Console.Write("Enter max energy: ");
            int maxEnergy = int.Parse(Console.ReadLine());
            Console.Write("Enter armor: ");
            int armor = int.Parse(Console.ReadLine());

            Player player = new Player(name, hp, maxHp, energy, maxEnergy, armor);
            players.Add(player);


        }

        static void AddSkillStats()
        {
            Console.Write("Enter skill name: ");
            string name = Console.ReadLine();
            Console.Write("Enter damage: ");
            int damage = int.Parse(Console.ReadLine());
            Console.Write("Enter penetration: ");
            double penetration = double.Parse(Console.ReadLine());
            Console.Write("Enter cost: ");
            int cost = int.Parse(Console.ReadLine());
            Console.Write("Enter heal: ");
            int heal = int.Parse(Console.ReadLine());
            Console.Write("Enter description: ");
            string description = Console.ReadLine();

            Stats skill = new Stats(name, damage, penetration, cost, heal, description);
            skillStats.Add(skill);

            Console.WriteLine("Skill statistics added successfully.");
        }

        static void DisplayPlayerInfo()
        {
            foreach (var player in players)
            {
                Console.WriteLine("Player:" + player.name + " Health: " + player.hp + "/" + player.maxHp + " Energy: " + player.energy + "/" + player.maxEnergy + "Armor: " + player.armor);
            }
        }

        static Player FindPlayerByName(List<Player> players, string name)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].name == name)
                {
                    return players[i];
                }
            }
            return null;
        }

        static Stats FindSkillByName(List<Stats> skills, string name)
        {
            for (int i = 0; i < skills.Count; i++)
            {
                if (skills[i].name == name)
                {
                    return skills[i];
                }
            }
            return null;
        }

        static void LearnASkill()
        {
            Console.Write("Enter the player's name: ");
            string playerName = Console.ReadLine();
            Console.Write("Enter the skill name: ");
            string skillName = Console.ReadLine();

            Player player = FindPlayerByName(players, playerName);
            Stats skill = FindSkillByName(skillStats, skillName);

            if (player != null && skill != null)
            {
                player.LearnSkill(skill);
                Console.WriteLine("Skill" + skillName + " learned successfully by " + playerName);
            }
            else
            {
                Console.WriteLine("Player or skill not found.");
            }
        }

        static void Attack()
        {
            Console.WriteLine("Choose attacker:");
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine(i + 1 + players[i].name);
            }
            Console.Write("Enter number of the attacker: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Choose target:");
            for (int i = 0; i < players.Count; i++)
            {
                if (i != num1)
                    Console.WriteLine(i + 1 + players[i].name);
            }
            Console.Write("Enter the number of the target: ");
            int num2 = int.Parse(Console.ReadLine());

            if (num1 >= 0 && num1 < players.Count &&
                num2 >= 0 && num2 < players.Count && num1 != num2)
            {
                Player attacker = players[num1];
                Player target = players[num2];

                Console.WriteLine(attacker.Attack(target));
            }
            else
            {
                Console.WriteLine("Invalid selection of attacker or target.");
            }
        }
    }
}
