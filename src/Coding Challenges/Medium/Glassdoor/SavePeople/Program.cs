using System.Collections.Generic;
using GlassdoorChallenges.SavePeopleSpace;
using System.Linq;

namespace GlassdoorChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            int testOne = SavePeopleChallenge.HowManyBoats(new List<int>() { 100, 200, 150, 80},200);
            int testTwo = SavePeopleChallenge.HowManyBoats(new List<int>() { 350, 190, 150, 180, 280 }, 400);
        }

        /// <summary>
        /// An imminent hurricane threatens the coastal town of Codeville. If at most two people can fit in a rescue boat, 
        /// and the maximum weight limit for a given boat is k, determine how many boats will be needed to save everyone.
        /// </summary>
        /// <param name="people">The list of weights for each person represented by an index</param>
        /// <param name="k">The assigned weight limit for all boats</param>
        /// <returns>The maximum amount of boats to carry all people</returns>
        public static int HowManyBoats(List<int> people, int k)
        {
            int count = 0;
            people.Sort();

            for (int i = 0; i < people.Count(); i++)
            {

                //Person weights more than boat capacity
                if (people[i] > k)
                    people.Remove(people[i]);

                //Edge case to be true until first person is last person
                if (i + 1 == people.Count())
                    count++;

                else
                {
                    //If two people's weight is less than or equal the boat capacity
                    if (people[i] + people[i + 1] <= k)
                    {
                        count++;
                        people.Remove(people[i]);
                        people.Remove(people[i + 1]);
                        i = -1;
                    }

                    //If a single person's weight is less than the boat capacity, but is too high to add to another.
                    //Also for when a single person's weight equals the boat capacity
                    else if (people[i] <= k)
                    {
                        count++;
                        people.Remove(people[i]);
                        i = -1;
                    }
                }
            }
            return count;
        }
    }
}
