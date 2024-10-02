using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace DoAnXNA2
{
    public class CustomBitmapFont
    {
        private Texture2D fontTexture;
        private Dictionary<char, Rectangle> characterRectangles;

        // Constructor để load font
        public CustomBitmapFont(Texture2D texture)
        {
            fontTexture = texture;
            characterRectangles = new Dictionary<char, Rectangle>();

            // Giả sử mỗi ký tự có kích thước 43x46 và được sắp xếp đều trên sprite sheet
            // Bạn có thể thay đổi cách tính này nếu ký tự có kích thước khác nhau
            int charWidth = 14;
            int charHeight = 15;

            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789,:"; // Các ký tự trong ảnh

            int row = 0;
            int col = 0;

            foreach (char c in characters)
            {
                // Tính vị trí của ký tự trong sprite sheet
                characterRectangles[c] = new Rectangle(col * charWidth, row * charHeight, charWidth, charHeight);

                // Chuyển sang cột tiếp theo, nếu hết hàng thì chuyển sang hàng tiếp theo
                col++;
                if (col >= 8) // Giả sử có 10 ký tự trên mỗi hàng
                {
                    col = 0;
                    row++;
                }
            }
        }

        // Phương thức để vẽ văn bản
        public void DrawText(SpriteBatch spriteBatch, string text, Vector2 position, Color color)
        {
            Vector2 currentPosition = position;

            foreach (char c in text)
            {
                if (characterRectangles.ContainsKey(c))
                {
                    Rectangle sourceRectangle = characterRectangles[c];
                    spriteBatch.Draw(fontTexture, currentPosition, sourceRectangle, color);
                    currentPosition.X += sourceRectangle.Width; // Dịch chuyển để vẽ ký tự tiếp theo
                }
            }
        }
    }
}