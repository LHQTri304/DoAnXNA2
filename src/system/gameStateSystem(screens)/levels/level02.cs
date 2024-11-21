using System.Collections.Generic;

namespace DoAnXNA2.src.levels
{
    public class Level02 : Level
    {
        public Level02() // Vàng, Đỏ
            : base(maxEnemies: 50, duration: 60) 
        {
            Waves =
            [
                new Wave(0, 15, 5, new Dictionary<string, float>
                {
                    { "Yellow", 1.0f },
                }), // Wave đầu tiên: 15s, nghỉ 5s

                new Wave(20, 20, 5, new Dictionary<string, float>
                {
                    { "Yellow", 0.4f },
                    { "Red", 0.6f },
                }), // Wave thứ hai: 20s, nghỉ 5s

                new Wave(45, 30, 0, new Dictionary<string, float>
                {
                    { "Yellow", 0.2f },
                    { "Red", 0.8f },
                }) // Wave cuối: 30s, không nghỉ
            ];
        }
    }
}
