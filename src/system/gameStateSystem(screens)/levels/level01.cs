using System.Collections.Generic;

namespace DoAnXNA2.src.levels
{
    public class Level01 : Level
    {
        public Level01() // Vàng
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
                    { "Yellow", 1.0f },
                }), // Wave thứ hai: 20s, nghỉ 5s

                new Wave(45, 30, 0, new Dictionary<string, float>
                {
                    { "Yellow", 1.0f },
                }) // Wave cuối: 30s, không nghỉ
            ];
        }
    }
}
