using System.Collections.Generic;
using System.Text;

namespace Mlb20TheShow_Stat_Randomizer
{
    class Pitcher : PositionPlayer
    {
        public int Stamina { get; set; } = random.Next(0, 101);
        public int HitsPer9 { get; set; } = random.Next(0, 101);
        public int KsPer9 { get; set; } = random.Next(0, 101);
        public int WalksPer9 { get; set; } = random.Next(0, 101);
        public int HomeRunsPer9 { get; set; } = random.Next(0, 101);
        public int PitchingClutch { get; set; } = random.Next(0, 101);
        public Pitch Pitch1 { get; set; } = new Pitch(random);
        public Pitch Pitch2 { get; set; } = new Pitch(random);
        public Pitch Pitch3 { get; set; } = new Pitch(random);
        public Pitch Pitch4 { get; set; } = new Pitch(random);
        public Pitch Pitch5 { get; set; } = new Pitch(random);

        public Pitcher()
        {
            DeterminePitches();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"\n");
            builder.Append($"{"Pitching Stats"}\n");
            builder.Append(string.Format("{0, -3}{1,-20}\n", Stamina, "Stamina"));
            builder.Append(string.Format("{0, -3}{1,-20}\n", HitsPer9, "H/9"));
            builder.Append(string.Format("{0, -3}{1,-20}\n", KsPer9, "K/9"));
            builder.Append(string.Format("{0, -3}{1,-20}\n", WalksPer9, "BB/9"));
            builder.Append(string.Format("{0, -3}{1,-20}\n", HomeRunsPer9, "HR/9"));
            builder.Append(string.Format("{0, -3}{1,-20}\n", PitchingClutch, "Clutch"));
            builder.Append("\n");
            builder.Append(string.Format("{0, -10}{1, -19}{2,-19}{3,-19}{4,-19}{5,-19}\n", "Pitches", "Pitch 1", "Pitch 2", "Pitch 3", "Pitch 4", "Pitch 5"));
            builder.Append(string.Format("{0, -10}{1, -19}{2,-19}{3,-19}{4,-19}{5,-19}\n", "Type",Pitch1.PitchType, Pitch2.PitchType, Pitch3.PitchType, Pitch4.PitchType, Pitch5.PitchType));
            builder.Append(string.Format("{0, -10}{1, -19}{2,-19}{3,-19}{4,-19}{5,-19}\n", "Velocity", Pitch1.Velocity, Pitch2.Velocity, Pitch3.Velocity, Pitch4.Velocity, Pitch5.Velocity));
            builder.Append(string.Format("{0, -10}{1, -19}{2,-19}{3,-19}{4,-19}{5,-19}\n", "Control", Pitch1.Control, Pitch2.Control, Pitch3.Control, Pitch4.Control, Pitch5.Control));
            builder.Append(string.Format("{0, -10}{1, -19}{2,-19}{3,-19}{4,-19}{5,-19}\n", "Break", Pitch1.Break, Pitch2.Break, Pitch3.Break, Pitch4.Break, Pitch5.Break));

            builder.Append("\n");
            builder.Append($"Pitcher Average: {PitcherAverage():0.00}\n");
            builder.Append($"Pitcher Stats Average: {PitchingStatAverage():0.00}\n");
            builder.Append($"Pitch Average: {PitchStatAverage():0.00}\n");
            builder.Append(base.ToString());

            return builder.ToString();
        }

        private void DeterminePitches()
        {
            List<PitchType> pitchesAlreadyHad = new List<PitchType>();

            Pitch1.PitchType = (PitchType)random.Next(0, 19);
            while (Pitch1.PitchType == PitchType.None)
            {
                Pitch1.PitchType = (PitchType)random.Next(0, 19);
            }
            pitchesAlreadyHad.Add(Pitch1.PitchType);

            Pitch2.PitchType = (PitchType)random.Next(0, 19);
            while (Pitch2.PitchType == PitchType.None || pitchesAlreadyHad.Contains(Pitch2.PitchType))
            {
                Pitch2.PitchType = (PitchType)random.Next(0, 19);
            }
            pitchesAlreadyHad.Add(Pitch2.PitchType);

            Pitch3.PitchType = (PitchType)random.Next(0, 19);
            while (Pitch3.PitchType == PitchType.None || pitchesAlreadyHad.Contains(Pitch3.PitchType))
            {
                Pitch3.PitchType = (PitchType)random.Next(0, 19);
            }
            pitchesAlreadyHad.Add(Pitch3.PitchType);

            Pitch4.PitchType = (PitchType)random.Next(0, 19);
            while(pitchesAlreadyHad.Contains(Pitch4.PitchType))
            {
                Pitch4.PitchType = (PitchType)random.Next(0, 19);
            }
            pitchesAlreadyHad.Add(Pitch3.PitchType);

            if(Pitch4.PitchType != PitchType.None || pitchesAlreadyHad.Contains(Pitch5.PitchType))
            {
                Pitch5.PitchType = (PitchType)random.Next(0, 19);
            }
            else
            {
                Pitch5.PitchType = PitchType.None;
            }
        }

        private double PitcherAverage()
        {
            double total = Stamina + HitsPer9 + KsPer9 + WalksPer9 + HomeRunsPer9 + PitchingClutch;

            total += Pitch1.Velocity + Pitch1.Control + Pitch1.Break + Pitch2.Velocity + Pitch2.Control + Pitch2.Break + Pitch3.Velocity + Pitch3.Break + Pitch3.Control;
            double valueCount = 6 + 9;
            if (Pitch4.PitchType != PitchType.None)
            {
                total += Pitch4.Velocity + Pitch4.Control + Pitch4.Break;
                valueCount += 3;
            }
            if (Pitch5.PitchType != PitchType.None)
            {
                total += Pitch5.Velocity + Pitch5.Control + Pitch5.Break;
                valueCount += 3;
            }

            return total / valueCount;
        }

        private double PitchingStatAverage()
        {
            double total = Stamina + HitsPer9 + KsPer9 + WalksPer9 + HomeRunsPer9 + PitchingClutch;
            return (total / 6);
        }

        private double PitchStatAverage()
        {
            double total = Pitch1.Velocity + Pitch1.Control + Pitch1.Break + Pitch2.Velocity + Pitch2.Control + Pitch2.Break + Pitch3.Velocity + Pitch3.Break + Pitch3.Control;
            double valueCount = 9;
            if(Pitch4.PitchType != PitchType.None)
            {
                total += Pitch4.Velocity + Pitch4.Control + Pitch4.Break;
                valueCount += 3;
            }
            if (Pitch5.PitchType != PitchType.None)
            {
                total += Pitch5.Velocity + Pitch5.Control + Pitch5.Break;
                valueCount += 3;
            }

            return total / valueCount;
        }
    }
}
