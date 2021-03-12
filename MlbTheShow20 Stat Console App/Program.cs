using Mlb20TheShow_Stat_Randomizer;
using RandomNameGeneratorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MlbTheShow20_Stat_Console_App
{
    class Program
    {
        static void Main(string[] args)
        {
            //RandomNumberGeneratorAnalyzer();
            string playerType = SelectPlayerType();
            PersonNameGenerator personNameGenerator = new PersonNameGenerator();
            PlaceNameGenerator placeNameGenerator = new PlaceNameGenerator();

            char again = 'y';
            while (again != 'n')
            {
                string name = personNameGenerator.GenerateRandomFirstAndLastName();
                string place = placeNameGenerator.GenerateRandomPlaceName();
                Console.WriteLine($"Mr. {name} from {place}");

                if (playerType == "pitcher")
                {
                    
                    Console.WriteLine(new Pitcher());
                }
                else
                {
                    Console.WriteLine(new PositionPlayer());
                }


                Console.WriteLine("\nAgain? (y/n)");
                string againLine = Console.ReadLine();
                if(againLine.ToCharArray().Length > 0)
                {
                    again = Console.ReadLine()[0];
                }    
                
            }
        }

        private static string SelectPlayerType()
        {
            string playerType = "";
            while (playerType != "pitcher" && playerType != "position")
            {
                Console.WriteLine("Pitcher or position?");
                playerType = Console.ReadLine().ToLower();
            }

            return playerType;
        }

        private static void RandomNumberGeneratorAnalyzer()
        {
            List<int> randomNumberList = new List<int>();
            int numberCountToGenerate = 100000000;
            for(int i = 0; i < numberCountToGenerate; i++)
            {
                randomNumberList.Add(PositionPlayer.random.Next(0, 101));
            }

            Console.WriteLine($"Percentage Numbers between 0 and 10: {(100 * (double)randomNumberList.Count(x => x > -1 && x < 10) / numberCountToGenerate):0.00}");
            Console.WriteLine($"Numbers between 10 and 20: {(100 * (double)randomNumberList.Count(x => x >= 10 && x < 20) / numberCountToGenerate):0.00}");
            Console.WriteLine($"Numbers between 20 and 30: {(100 * (double)randomNumberList.Count(x => x >= 20 && x < 30) / numberCountToGenerate):0.00}");
            Console.WriteLine($"Numbers between 30 and 40: {(100 * (double)randomNumberList.Count(x => x >= 30 && x < 40) / numberCountToGenerate):0.00}");
            Console.WriteLine($"Numbers between 40 and 50: {(100 * (double)randomNumberList.Count(x => x >= 40 && x < 50) / numberCountToGenerate):0.00}");
            Console.WriteLine($"Numbers between 50 and 60: {(100 * (double)randomNumberList.Count(x => x >= 50 && x < 60) / numberCountToGenerate):0.00}");
            Console.WriteLine($"Numbers between 60 and 70: {(100 * (double)randomNumberList.Count(x => x >= 60 && x < 70) / numberCountToGenerate):0.00}");
            Console.WriteLine($"Numbers between 70 and 80: {(100 * (double)randomNumberList.Count(x => x >= 70 && x < 80) / numberCountToGenerate):0.00}");
            Console.WriteLine($"Numbers between 80 and 90: {(100 * (double)randomNumberList.Count(x => x >= 80 && x < 90) / numberCountToGenerate):0.00}");
            Console.WriteLine($"Numbers between 90 and 100: {(100 * (double)randomNumberList.Count(x => x >= 90 && x < 101) / numberCountToGenerate):0.00}");

        }
    }
}
