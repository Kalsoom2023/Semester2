using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemNo2.bl
{


    public class Stats
    {
        public string name;
        public int damage;
        public string description;
        public double penetration;
        public int cost;
        public int heal;


        public Stats(string name, int damage, double penetration, int cost, int heal, string description)
        {
            this.name = name;
            this.damage = damage;
            this.penetration = penetration;
            this.cost = cost;
            this.heal = heal;
            this.description = description;
        }
    }


    class Player
    {
        public int hp;
        public int maxHp;
        public int energy;
        public int maxEnergy;
        public int armor;
        public string name;
        public Stats skillStatistics;


        public Player(string name, int hp, int maxHp, int energy, int maxEnergy, int armor)
        {
            this.name = name;
            this.hp = hp;
            this.maxHp = maxHp;
            this.energy = energy;
            this.maxEnergy = maxEnergy;
            this.armor = armor;
        }
        public void UpdateHealth(int number)
        {
            hp += number;
            if (hp > maxHp)
                hp = maxHp;
            else if (hp < 0)
                hp = 0;
        }


        public void updateEnergy(int number)
        {
            energy += number;
            if (energy > maxEnergy)
                energy = maxEnergy;
            else if (energy < 0)
                energy = 0;
        }





        public void UpdateName(string newName)
        {
            name = newName;
        }


        public void LearnSkill(Stats skill)
        {
            skillStatistics = skill;
        }


        public string Attack(Player target)
        {

            if (energy < skillStatistics.cost)
                return name + " attempted to use " + skillStatistics.name + " but didn't have enough energy!";


            updateEnergy(-skillStatistics.cost);


            double effectiveArmor = target.armor - skillStatistics.penetration;
            if (effectiveArmor < 0)
                effectiveArmor = 0;


            double calculatedDamage = skillStatistics.damage * ((100 - effectiveArmor) / 100.0);


            target.UpdateHealth(-(int)calculatedDamage);


            UpdateHealth(skillStatistics.heal);


            string result = name + " used " + skillStatistics.name + skillStatistics.description + " against " + target.name + "doing" + calculatedDamage + "damage!";


            if (skillStatistics.heal > 0)
                result += name + "healed for " + skillStatistics.heal + " health!";


            if (target.hp <= 0)
                result += target.name + " died.";
            else
                result += $" {target.name} is at {(target.hp * 100.0 / target.maxHp):0.00}% health.";

            return result;
        }
    }
}