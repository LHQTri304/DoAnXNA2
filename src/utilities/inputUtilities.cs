using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace DoAnXNA2.src.utilities
{
    public static class InputUtilities
    {
        private static Dictionary<Keys, bool> avoidHoldingDict = new Dictionary<Keys, bool>();
        private static Dictionary<int, bool> avoidHoldingMouseDict = new Dictionary<int, bool>();

        // Phương thức tránh lặp lại hành động khi giữ phím
        public static void HandleKeyPress(Keys key, KeyboardState kstate, Action action)
        {
            if (!avoidHoldingDict.ContainsKey(key))
            {
                avoidHoldingDict[key] = false;
            }

            if (kstate.IsKeyUp(key))
            {
                avoidHoldingDict[key] = true;
            }
            else if (avoidHoldingDict[key] && kstate.IsKeyDown(key))
            {
                avoidHoldingDict[key] = false;
                action?.Invoke();
            }
        }

        // Phương thức tránh lặp lại hành động khi giữ nút chuột
        public static void HandleMouseClick(ButtonState mouseButton, int buttonIndex, Action action)
        {
            if (!avoidHoldingMouseDict.ContainsKey(buttonIndex))
            {
                avoidHoldingMouseDict[buttonIndex] = false;
            }

            // Kiểm tra trạng thái của nút chuột
            if (mouseButton == ButtonState.Released)
            {
                avoidHoldingMouseDict[buttonIndex] = true;
            }
            else if (avoidHoldingMouseDict[buttonIndex] && mouseButton == ButtonState.Pressed)
            {
                avoidHoldingMouseDict[buttonIndex] = false;
                action?.Invoke();
            }
        }
    }
}

