using Raylib_cs;

namespace PicoSharp
{
    public static class Color
    {
        // 0: #000000 (Black)
        public static readonly Raylib_cs.Color Black = new Raylib_cs.Color(0, 0, 0, 255);
        
        // 1: #1D2B53 (Dark Blue)
        public static readonly Raylib_cs.Color DarkBlue = new Raylib_cs.Color(29, 43, 83, 255);
        
        // 2: #7E2553 (Dark Purple)
        public static readonly Raylib_cs.Color DarkPurple = new Raylib_cs.Color(126, 37, 83, 255);
        
        // 3: #008751 (Dark Green)
        public static readonly Raylib_cs.Color DarkGreen = new Raylib_cs.Color(0, 135, 81, 255);
        
        // 4: #AB5236 (Brown)
        public static readonly Raylib_cs.Color Brown = new Raylib_cs.Color(171, 82, 54, 255);
        
        // 5: #5F574F (Dark Grey)
        public static readonly Raylib_cs.Color DarkGrey = new Raylib_cs.Color(95, 87, 79, 255);
        
        // 6: #C2C3C7 (Light Grey)
        public static readonly Raylib_cs.Color LightGrey = new Raylib_cs.Color(194, 195, 199, 255);
        
        // 7: #FFF1E8 (White)
        public static readonly Raylib_cs.Color White = new Raylib_cs.Color(255, 241, 232, 255);
        
        // 8: #FF004D (Red)
        public static readonly Raylib_cs.Color Red = new Raylib_cs.Color(255, 0, 77, 255);
        
        // 9: #FFA300 (Orange)
        public static readonly Raylib_cs.Color Orange = new Raylib_cs.Color(255, 163, 0, 255);
        
        // 10: #FFEC27 (Yellow)
        public static readonly Raylib_cs.Color Yellow = new Raylib_cs.Color(255, 236, 39, 255);
        
        // 11: #00E436 (Green)
        public static readonly Raylib_cs.Color Green = new Raylib_cs.Color(0, 228, 54, 255);
        
        // 12: #29ADFF (Blue)
        public static readonly Raylib_cs.Color Blue = new Raylib_cs.Color(41, 173, 255, 255);
        
        // 13: #83769C (Lavender)
        public static readonly Raylib_cs.Color Lavender = new Raylib_cs.Color(131, 118, 156, 255);
        
        // 14: #FF77A8 (Pink)
        public static readonly Raylib_cs.Color Pink = new Raylib_cs.Color(255, 119, 168, 255);
        
        // 15: #FFCCAA (Light Peach)
        public static readonly Raylib_cs.Color LightPeach = new Raylib_cs.Color(255, 204, 170, 255);

        /// <summary>
        /// Get a color by its index (0-15).
        /// </summary>
        public static Raylib_cs.Color Get(int index)
        {
            return index switch
            {
                0 => Black,
                1 => DarkBlue,
                2 => DarkPurple,
                3 => DarkGreen,
                4 => Brown,
                5 => DarkGrey,
                6 => LightGrey,
                7 => White,
                8 => Red,
                9 => Orange,
                10 => Yellow,
                11 => Green,
                12 => Blue,
                13 => Lavender,
                14 => Pink,
                15 => LightPeach,
                _ => Black
            };
        }
    }
}
