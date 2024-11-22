/* using System.Collections.Generic;

namespace DoAnXNA2.src.levels
{
    public class Level03 : Level
    {
        public Level03() // Yellow Red Green
            : base(maxEnemies: 50, duration: 60) 
        {
            Waves =
            [
                new Wave(0, 15, 5, new Dictionary<string, float>
                {
                    { "Yellow", 0.7f },
                    { "Red", 0.3f }
                }), // Wave đầu tiên: 15s, nghỉ 5s, 70% spawn Yellow 30% spawn Red

                new Wave(20, 20, 5, new Dictionary<string, float>
                {
                    { "Yellow", 0.5f },
                    { "Red", 0.4f },
                    { "Green", 0.1f }
                }), // Wave thứ hai: 20s, nghỉ 5s, 50% spawn Yellow 40% spawn Red 10% spawn Green

                new Wave(45, 30, 0, new Dictionary<string, float>
                {
                    { "Yellow", 0.3f },
                    { "Red", 0.4f },
                    { "Green", 0.3f }
                }) // Wave cuối: 30s, không nghỉ, 30% spawn Yellow 40% spawn Red 30% spawn Green
            ];
        }
    }
}
 */