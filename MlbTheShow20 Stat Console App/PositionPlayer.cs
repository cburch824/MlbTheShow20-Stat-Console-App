using System;
using System.Text;

namespace Mlb20TheShow_Stat_Randomizer
{
    public class PositionPlayer
    {
        public static readonly Random random = new Random();

        public int ContactVsRight { get; set; } = random.Next(0,101);
        public int ContactVsLeft { get; set; } = random.Next(0,101);
        public int PowerVsRight { get; set; } = random.Next(0,101);
        public int PowerVsLeft { get; set; } = random.Next(0,101);
        public int Vision { get; set; } = random.Next(0,101);
        public int Discipline { get; set; } = random.Next(0,101);
        public int Clutch { get; set; } = random.Next(0,101);
        public int Bunt { get; set; } = random.Next(0,101);
        public int DragBunt { get; set; } = random.Next(0,101);
        public int Durability { get; set; } = random.Next(0,101);
        public int Fielding { get; set; } = random.Next(0,101);
        public int ArmStrength { get; set; } = random.Next(0,101);
        public int ArmAccuracy { get; set; } = random.Next(0,101);
        public int Reaction { get; set; } = random.Next(0,101);
        public int Speed { get; set; } = random.Next(0,101);
        public int Stealing { get; set; } = random.Next(0,101);
        public int BaserunningAggressiveness { get; set; } = random.Next(0,101);

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"\n");
            builder.Append($"{"Hitting Stats"} {"Fielding Stats", 23} {"Baserunning Stats", 25}\n");
            builder.Append(string.Format("{0, -3}{1,-20}{2,-3}{3,-20}{4,-3}{5,-20}\n", ContactVsRight, "Contact vs Right", Durability, "Durability", Speed, "Speed"));
            builder.Append(string.Format("{0, -3}{1,-20}{2,-3}{3,-20}{4,-3}{5,-20}\n", ContactVsLeft, "Contact vs Left", Fielding, "Fielding", Stealing, "Stealing"));
            builder.Append(string.Format("{0, -3}{1,-20}{2,-3}{3,-20}{4,-3}{5,-20}\n", PowerVsRight, "Power vs Right", ArmStrength, "Arm Strength", BaserunningAggressiveness, "BR Agg"));
            builder.Append(string.Format("{0, -3}{1,-20}{2,-3}{3,-20}\n", PowerVsLeft, "Power vs Left", ArmAccuracy, "Arm Accuracy"));
            builder.Append(string.Format("{0, -3}{1,-20}{2,-3}{3,-20}\n", Bunt, "Bunt", Reaction, "Reaction"));
            builder.Append(string.Format("{0, -3}{1,-20}\n", DragBunt, "Drag Bunt"));
            builder.Append(string.Format("{0, -3}{1,-20}\n", Discipline, "Discipline"));
            builder.Append(string.Format("{0, -3}{1,-20}\n", Clutch, "Clutch"));
            builder.Append(string.Format("{0, -3}{1,-20}\n", Vision, "Vision"));
            builder.Append("\n");

            builder.Append($"Position Player Average: {PositionPlayerAverage():0.00}\n");
            builder.Append($"Hitting Average: {HittingAverage():0.00}\n");
            builder.Append($"Fielding Average: {FieldingAverage():0.00}\n");
            builder.Append($"Baserunning Average: {BaserunningAverage():0.00}\n");

            return builder.ToString();
        }

        private double PositionPlayerAverage()
        {
            double total = ContactVsRight + ContactVsLeft + PowerVsRight + PowerVsLeft + Vision + Discipline + Clutch + Bunt + DragBunt + Durability + Fielding + ArmStrength + ArmAccuracy + Reaction + Speed + Stealing + BaserunningAggressiveness;
            return total / 17;
        }
        
        private double HittingAverage()
        {
            double total = ContactVsRight + ContactVsLeft + PowerVsRight + PowerVsLeft + Vision + Discipline + Clutch + Bunt + DragBunt;
            return total / 9;
        }

        private double FieldingAverage()
        {
            double total = Durability + Fielding + ArmStrength + ArmAccuracy + Reaction;
            return total / 5;
        }

        private double BaserunningAverage()
        {
            double total = Speed + Stealing + BaserunningAggressiveness;
            return total / 3;
        }
    }
}
