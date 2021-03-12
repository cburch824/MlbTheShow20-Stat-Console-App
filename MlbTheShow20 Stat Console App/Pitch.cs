using System;
using System.Collections.Generic;
using System.Text;

namespace Mlb20TheShow_Stat_Randomizer
{
    public enum PitchType
    {
      None,
      FourSeam,
      TwoSeam,
      Slider,
      Curveball,
      Changeup,
      Cutter,
      CircleChange,
      Palmball,
      Forkball,
      Knucklecurve,
      Screwball,
      TwelveSixCurve,
      SweepingCurve,
      RunningFB,
      VulcanChange,
      Sinker,
      Slurve,
      Splitter,
      Knunckleball,
    }

    public class Pitch
    {
        public PitchType PitchType { get; set; }
        public int Velocity { get; set; }
        public int Control { get; set; }
        public int Break { get; set; }

        public Pitch(Random random)
        {
            Velocity = random.Next(0, 101);
            Control = random.Next(0, 101);
            Break = random.Next(0, 101);
        }
    }
}
