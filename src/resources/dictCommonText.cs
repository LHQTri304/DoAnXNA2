using System.Collections.Generic;

namespace DoAnXNA2
{
    public static class CommonText
    {
        public static Dictionary<int, string> TITLE = new()
        {
            {0, "MAIN MENU"},
            {1, "CHOOSING LEVEL"},
            {2, "GAME OVER"},
            {3, "SETTING"},
            {4, "LEADER BOARD"},
        };
        public static Dictionary<int, string> BUTTON = new()
        {
            {0, "Press ESC to go back"},
            {1, "Press SPACE to Start"},
        };
    }
}