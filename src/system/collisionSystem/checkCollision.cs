

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoAnXNA2
{
    public static class CheckCollision
    {
        public static bool CheckBounds(Rectangle bounds1, Rectangle bounds2, Action onCollision)
        {
            if (bounds1.Intersects(bounds2))
            {
                onCollision?.Invoke();
                return true;
            }
            return false;
        }

        public static bool CheckBounds(Vector2 position1, Texture2D texture1, Vector2 position2, Texture2D texture2, Action onCollision)
        {
            var bounds1 = QuickGetUtilities.GetBounds(position1, texture1);
            var bounds2 = QuickGetUtilities.GetBounds(position2, texture2);
            return CheckBounds(bounds1, bounds2, onCollision);
        }
    }
}