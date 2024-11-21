using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2
{
    public static class ScoreTable
    {
        //Basic score for each kill
        public static int SinglePoint { get; set; } = 1;
        public static int FivePoints { get; set; } = 5;
        public static int TenPoints { get; set; } = 10;
        public static int TwentyPoints { get; set; } = 20;
        public static int ThirtyPoints { get; set; } = 30;

        //Milestone level 0-10
        public static int MilestoneLv0 { get; set; } = 0;
        public static int MilestoneLv1 { get; set; } = 0;
        public static int MilestoneLv2 { get; set; } = 60;
        public static int MilestoneLv3 { get; set; } = 150;
        public static int MilestoneLv4 { get; set; } = 350;
        public static int MilestoneLv5 { get; set; } = 700;
        public static int MilestoneLv6 { get; set; } = 1000;
        public static int MilestoneLv7 { get; set; } = 1500;
        public static int MilestoneLv8 { get; set; } = 2100;
        public static int MilestoneLv9 { get; set; } = 3000;
        public static int MilestoneLv10 { get; set; } = 5000;
        public static List<int> MilestoneLv0to10 { get; } = [
            MilestoneLv0, MilestoneLv1, MilestoneLv2, 
            MilestoneLv3, MilestoneLv4, MilestoneLv5, 
            MilestoneLv6, MilestoneLv7, MilestoneLv8, 
            MilestoneLv9, MilestoneLv10
        ];
    }
}
