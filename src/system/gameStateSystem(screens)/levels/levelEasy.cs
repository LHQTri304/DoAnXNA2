using System.Collections.Generic;

namespace DoAnXNA2.src.levels
{
    public class Level01 : Level
    {
        public Level01() // Yellow
            : base(maxEnemies: 50, duration: 60)
        {
            Waves = [
                new Wave(0, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 1.00f },
            }),
            new Wave(20, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 1.00f },
            }),
            new Wave(40, 15, 0, new Dictionary<string, float>
            {
                { "Yellow", 1.00f },
            }),
        ];
        }
    }

    public class Level02 : Level
    {
        public Level02() // Yellow Red
            : base(maxEnemies: 60, duration: 60)
        {
            Waves = [
                new Wave(0, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.57f },
                { "Red", 0.43f },
            }),
            new Wave(20, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.40f },
                { "Red", 0.60f },
            }),
            new Wave(40, 15, 0, new Dictionary<string, float>
            {
                { "Yellow", 0.02f },
                { "Red", 0.98f },
            }),
        ];
        }
    }

    public class Level03 : Level
    {
        public Level03() // Yellow Red Green
            : base(maxEnemies: 70, duration: 60)
        {
            Waves = [
                new Wave(0, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.40f },
                { "Red", 0.33f },
                { "Green", 0.27f },
            }),
            new Wave(20, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.25f },
                { "Red", 0.33f },
                { "Green", 0.41f },
            }),
            new Wave(40, 15, 0, new Dictionary<string, float>
            {
                { "Yellow", 0.01f },
                { "Red", 0.33f },
                { "Green", 0.66f },
            }),
        ];
        }
    }

    public class Level04 : Level
    {
        public Level04() // Yellow Red Green Blue
            : base(maxEnemies: 80, duration: 60)
        {
            Waves = [
                new Wave(0, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.31f },
                { "Red", 0.27f },
                { "Green", 0.23f },
                { "Blue", 0.19f },
            }),
            new Wave(20, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.18f },
                { "Red", 0.23f },
                { "Green", 0.27f },
                { "Blue", 0.32f },
            }),
            new Wave(40, 15, 0, new Dictionary<string, float>
            {
                { "Yellow", 0.01f },
                { "Red", 0.17f },
                { "Green", 0.33f },
                { "Blue", 0.49f },
            }),
        ];
        }
    }

    public class Level05 : Level
    {
        public Level05() // Yellow Red Green Blue Orange
            : base(maxEnemies: 90, duration: 60)
        {
            Waves = [
                new Wave(0, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.25f },
                { "Red", 0.22f },
                { "Green", 0.20f },
                { "Blue", 0.18f },
                { "Orange", 0.15f },
            }),
            new Wave(20, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.14f },
                { "Red", 0.17f },
                { "Green", 0.20f },
                { "Blue", 0.23f },
                { "Orange", 0.26f },
            }),
            new Wave(40, 15, 0, new Dictionary<string, float>
            {
                { "Yellow", 0.01f },
                { "Red", 0.10f },
                { "Green", 0.20f },
                { "Blue", 0.30f },
                { "Orange", 0.39f },
            }),
        ];
        }
    }

    public class Level06 : Level
    {
        public Level06() // Yellow Red Green Blue Orange Purple
            : base(maxEnemies: 100, duration: 60)
        {
            Waves = [
                new Wave(0, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.21f },
                { "Red", 0.19f },
                { "Green", 0.18f },
                { "Blue", 0.16f },
                { "Orange", 0.14f },
                { "Purple", 0.12f },
            }),
            new Wave(20, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.12f },
                { "Red", 0.14f },
                { "Green", 0.16f },
                { "Blue", 0.18f },
                { "Orange", 0.20f },
                { "Purple", 0.21f },
            }),
            new Wave(40, 15, 0, new Dictionary<string, float>
            {
                { "Yellow", 0.00f },
                { "Red", 0.07f },
                { "Green", 0.13f },
                { "Blue", 0.20f },
                { "Orange", 0.26f },
                { "Purple", 0.33f },
            }),
        ];
        }
    }
}
