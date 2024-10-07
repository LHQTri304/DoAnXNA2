using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace DoAnXNA2.src.utilities
{
    public static class InputUtilities
    {
        private static Dictionary<Keys, bool> avoidHoldingDict = new Dictionary<Keys, bool>();

        // Phương thức tránh lặp lại hành động khi giữ phím --> bắt buộc phải bấm từ đợt
        public static void HandleKeyPress(Keys key, KeyboardState kstate, Action action)
        {
            // Kiểm tra và khởi tạo trạng thái cho từng phím
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
                action?.Invoke(); // Gọi hành động khi phím được nhấn
            }
        }
    }
}
