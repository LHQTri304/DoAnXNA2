using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace DoAnXNA2
{
    public static class MainRes //MainResources
    {
        // Game properties
        public static int ScreenWidth { get; set; } = 1280;
        public static int ScreenHeight { get; set; } = 720;
        public static bool IsAbleToWin { get; set; } = false;
        public static GameState CurrentState { get; set; }
        public static GameState PreviousState { get; set; }
        public static GameStateManager GSM { get; set; }

        // Entities
        public static PlayerShip PlayerShip { get; set; }
        public static Dictionary<string, EnemySpawner> AllSpawners { get; private set; } = [];
        public static List<Enemy> AllEnemies { get; set; } = [];
        public static List<Bullet> AllBullets { get; set; } = [];

        // UI/UX
        public static Cursor Cursor { get; set; }
        public static List<I_HUD> GameHUD { get; set; } = [];
        public static SpriteFont Font { get; set; }

        // Level system
        public static int CurrentScore { get; set; }

        // Methods...
        public static void Initialize()
        {
            IsAbleToWin = false;
            PlayerShip = new PlayerShip();
            Cursor = new Cursor();
            // Khởi tạo spawner --> Dùng ánh xạ (Reflection) để tạo tự động
            List<string> _enemyNames =
        [
            "Yellow", "Red", "Green", "Blue", "Orange", "Purple", "Gray", "Cyan",
            "Pink", "Brown", "Teal", "Lime", "Black", "White", "Gold", "Silver",
            "Maroon", "Navy"
        ];
            foreach (var eName in _enemyNames)
            {
                // Tìm kiếm lớp có tên tương ứng với màu (ví dụ: YellowSpawner cho "Yellow")
                string className = "DoAnXNA2." + eName + "Spawner";
                Type spawnerType = Type.GetType(className);

                if (spawnerType != null)
                {
                    // Tạo đối tượng spawner từ lớp tìm được
                    var spawnerInstance = (EnemySpawner)Activator.CreateInstance(spawnerType);
                    MainRes.AllSpawners.Add(eName, spawnerInstance);
                }
                else
                    Console.WriteLine($"Lớp {className} không tồn tại.");
            }
        }
        public static void ResetData()
        {
            IsAbleToWin = false;
            AllEnemies.Clear();
            AllBullets.Clear();
            CurrentScore = 0;
            PlayerShip?.ResetStats();
        }
    }
}
