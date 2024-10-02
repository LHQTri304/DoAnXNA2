using Microsoft.Xna.Framework.Input;
using System;

namespace DoAnXNA2.src.utilities
{
    public static class InputUtilities
    {
        private static bool avoidHolding = false;

        public static void HandleKeyPress(Keys key, KeyboardState kstate, Action action)
        {
            if (kstate.IsKeyUp(key))
            {
                avoidHolding = true;
            }
            else if (avoidHolding && kstate.IsKeyDown(key))
            {
                avoidHolding = false;
                action?.Invoke(); // Gọi hành động khi phím được nhấn
            }
        }
    }
}
