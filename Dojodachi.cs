using System;
using System.Collections.Generic;

namespace Dojodachi
{
    public class Dojodachi
    {
        
        Random rand = new Random();
        public int happiness { get; set; }
        public int fullness { get; set; }
        public int energy { get; set; }
        public int meals { get; set; }

        public Dojodachi()
        {
            this.happiness = 20;
            this.fullness = 20;
            this.energy = 50;
            this.meals = 3;
        }

        public string Feed()
        {
            if (this.meals > 0)
            {
                this.meals--;
                if (rand.Next(5) < 1)
                {
                    return "Your dojodachi did not like the meal :(";
                }
                else
                {
                    int amount = rand.Next(5, 11);
                    this.fullness += amount;
                    return $"Your dojodachi liked the meal (+{amount} fullness)";
                }
            }
            return "You do not have any meals :(";
        }

        public string Play()
        {
            this.energy -= 5;
            if (rand.Next(5) < 1)
            {
                return "Your dojodachi did not have fun playing :(";
            }
            else
            {
                int amount = rand.Next(5, 11);
                this.happiness += amount;
                return $"Your dojodachi enjoyed the play time (+{amount} happiness)";
            }
        }

        public string Work()
        {
            this.energy -= 5;
            int amount = rand.Next(1, 4);
            this.meals += amount;
            return $"Your dojodachi worked and earned {amount} meals";
        }

        public string Sleep()
        {
            this.energy += 15;
            this.happiness -= 5;
            this.fullness -= 5;
            return "Your dojodachi is snoozing... ZZZzzz ...";
        }

    }
}
