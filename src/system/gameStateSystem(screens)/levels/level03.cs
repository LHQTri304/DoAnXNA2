using System.Collections.Generic;

namespace DoAnXNA2.src.levels
{
    public class Level03 : Level
    {
        public Level03() // Vàng, Đỏ, Xanh Lá
            : base(maxEnemies: 50, duration: 60) 
        {
            Waves =
            [
                new Wave(0, 15, 5, new Dictionary<string, float>
                {
                    { "Yellow", 0.7f },
                    { "Red", 0.3f }
                }), // Wave đầu tiên: 15s, nghỉ 5s

                new Wave(20, 20, 5, new Dictionary<string, float>
                {
                    { "Yellow", 0.5f },
                    { "Red", 0.4f },
                    { "Green", 0.1f }
                }), // Wave thứ hai: 20s, nghỉ 5s

                new Wave(45, 30, 0, new Dictionary<string, float>
                {
                    { "Yellow", 0.3f },
                    { "Red", 0.4f },
                    { "Green", 0.3f }
                }) // Wave cuối: 30s, không nghỉ
            ];
        }
    }
}
