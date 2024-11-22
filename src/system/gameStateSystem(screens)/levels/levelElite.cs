using System.Collections.Generic;

namespace DoAnXNA2.src.levels
{
    public class Level08 : Level
    {
        public Level08() // Yellow Red Green Gray
            : base(maxEnemies: 120, duration: 60)
        {
            Waves = [
                new Wave(0, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.31f },
                { "Red", 0.27f },
                { "Green", 0.23f },
                { "Gray", 0.19f },
            }),
            new Wave(20, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.18f },
                { "Red", 0.23f },
                { "Green", 0.27f },
                { "Gray", 0.32f },
            }),
            new Wave(40, 15, 0, new Dictionary<string, float>
            {
                { "Yellow", 0.01f },
                { "Red", 0.17f },
                { "Green", 0.33f },
                { "Gray", 0.49f },
            }),
        ];
        }
    }

    public class Level09 : Level
    {
        public Level09() // Yellow Red Green Blue Gray Cyan
            : base(maxEnemies: 130, duration: 60)
        {
            Waves = [
                new Wave(0, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.21f },
                { "Red", 0.19f },
                { "Green", 0.18f },
                { "Blue", 0.16f },
                { "Gray", 0.14f },
                { "Cyan", 0.12f },
            }),
            new Wave(20, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.12f },
                { "Red", 0.14f },
                { "Green", 0.16f },
                { "Blue", 0.18f },
                { "Gray", 0.20f },
                { "Cyan", 0.21f },
            }),
            new Wave(40, 15, 0, new Dictionary<string, float>
            {
                { "Yellow", 0.00f },
                { "Red", 0.07f },
                { "Green", 0.13f },
                { "Blue", 0.20f },
                { "Gray", 0.26f },
                { "Cyan", 0.33f },
            }),
        ];
        }
    }

    public class Level10 : Level
    {
        public Level10() // Yellow Red Green Blue Orange Gray Cyan Pink
            : base(maxEnemies: 140, duration: 60)
        {
            Waves = [
                new Wave(0, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.18f },
                { "Red", 0.16f },
                { "Green", 0.15f },
                { "Blue", 0.13f },
                { "Orange", 0.12f },
                { "Gray", 0.10f },
                { "Cyan", 0.09f },
                { "Pink", 0.07f },
            }),
            new Wave(20, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.12f },
                { "Red", 0.12f },
                { "Green", 0.12f },
                { "Blue", 0.12f },
                { "Orange", 0.12f },
                { "Gray", 0.12f },
                { "Cyan", 0.12f },
                { "Pink", 0.12f },
            }),
            new Wave(40, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.07f },
                { "Red", 0.08f },
                { "Green", 0.10f },
                { "Blue", 0.12f },
                { "Orange", 0.13f },
                { "Gray", 0.15f },
                { "Cyan", 0.17f },
                { "Pink", 0.18f },
            }),
            new Wave(60, 15, 0, new Dictionary<string, float>
            {
                { "Yellow", 0.00f },
                { "Red", 0.04f },
                { "Green", 0.07f },
                { "Blue", 0.11f },
                { "Orange", 0.14f },
                { "Gray", 0.18f },
                { "Cyan", 0.21f },
                { "Pink", 0.25f },
            }),
        ];
        }
    }

    public class Level11 : Level
    {
        public Level11() // Yellow Red Green Blue Orange Purple Gray Cyan Pink Brown
            : base(maxEnemies: 150, duration: 60)
        {
            Waves = [
                new Wave(0, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.14f },
                { "Red", 0.13f },
                { "Green", 0.12f },
                { "Blue", 0.11f },
                { "Orange", 0.10f },
                { "Purple", 0.10f },
                { "Gray", 0.09f },
                { "Cyan", 0.08f },
                { "Pink", 0.07f },
                { "Brown", 0.06f },
            }),
            new Wave(20, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.10f },
                { "Red", 0.10f },
                { "Green", 0.10f },
                { "Blue", 0.10f },
                { "Orange", 0.10f },
                { "Purple", 0.10f },
                { "Gray", 0.10f },
                { "Cyan", 0.10f },
                { "Pink", 0.10f },
                { "Brown", 0.10f },
            }),
            new Wave(40, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.05f },
                { "Red", 0.06f },
                { "Green", 0.07f },
                { "Blue", 0.08f },
                { "Orange", 0.09f },
                { "Purple", 0.11f },
                { "Gray", 0.12f },
                { "Cyan", 0.13f },
                { "Pink", 0.14f },
                { "Brown", 0.15f },
            }),
            new Wave(60, 15, 0, new Dictionary<string, float>
            {
                { "Yellow", 0.00f },
                { "Red", 0.02f },
                { "Green", 0.05f },
                { "Blue", 0.07f },
                { "Orange", 0.09f },
                { "Purple", 0.11f },
                { "Gray", 0.13f },
                { "Cyan", 0.15f },
                { "Pink", 0.18f },
                { "Brown", 0.20f },
            }),
        ];
        }
    }

    public class Level12 : Level
    {
        public Level12() // Yellow Red Green Blue Orange Purple Gray Cyan Pink Brown Teal
            : base(maxEnemies: 160, duration: 60)
        {
            Waves = [
                new Wave(0, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.14f },
                { "Red", 0.13f },
                { "Green", 0.12f },
                { "Blue", 0.11f },
                { "Orange", 0.10f },
                { "Purple", 0.09f },
                { "Gray", 0.08f },
                { "Cyan", 0.07f },
                { "Pink", 0.06f },
                { "Brown", 0.05f },
                { "Teal", 0.04f },
            }),
            new Wave(20, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.11f },
                { "Red", 0.10f },
                { "Green", 0.10f },
                { "Blue", 0.10f },
                { "Orange", 0.09f },
                { "Purple", 0.09f },
                { "Gray", 0.09f },
                { "Cyan", 0.08f },
                { "Pink", 0.08f },
                { "Brown", 0.08f },
                { "Teal", 0.08f },
            }),
            new Wave(40, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.07f },
                { "Red", 0.08f },
                { "Green", 0.08f },
                { "Blue", 0.08f },
                { "Orange", 0.09f },
                { "Purple", 0.09f },
                { "Gray", 0.09f },
                { "Cyan", 0.10f },
                { "Pink", 0.10f },
                { "Brown", 0.10f },
                { "Teal", 0.11f },
            }),
            new Wave(60, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.04f },
                { "Red", 0.05f },
                { "Green", 0.06f },
                { "Blue", 0.07f },
                { "Orange", 0.08f },
                { "Purple", 0.09f },
                { "Gray", 0.10f },
                { "Cyan", 0.11f },
                { "Pink", 0.12f },
                { "Brown", 0.13f },
                { "Teal", 0.14f },
            }),
            new Wave(80, 15, 0, new Dictionary<string, float>
            {
                { "Yellow", 0.00f },
                { "Red", 0.02f },
                { "Green", 0.04f },
                { "Blue", 0.06f },
                { "Orange", 0.07f },
                { "Purple", 0.09f },
                { "Gray", 0.11f },
                { "Cyan", 0.13f },
                { "Pink", 0.14f },
                { "Brown", 0.16f },
                { "Teal", 0.18f },
            }),
        ];
        }
    }

    public class Level13 : Level
    {
        public Level13() // Yellow Red Green Blue Orange Purple Gray Cyan Pink Brown Teal Lime
            : base(maxEnemies: 170, duration: 60)
        {
            Waves = [
                new Wave(0, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.13f },
                { "Red", 0.12f },
                { "Green", 0.11f },
                { "Blue", 0.10f },
                { "Orange", 0.09f },
                { "Purple", 0.09f },
                { "Gray", 0.08f },
                { "Cyan", 0.07f },
                { "Pink", 0.06f },
                { "Brown", 0.06f },
                { "Teal", 0.05f },
                { "Lime", 0.04f },
            }),
            new Wave(20, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.10f },
                { "Red", 0.10f },
                { "Green", 0.09f },
                { "Blue", 0.09f },
                { "Orange", 0.09f },
                { "Purple", 0.08f },
                { "Gray", 0.08f },
                { "Cyan", 0.08f },
                { "Pink", 0.08f },
                { "Brown", 0.07f },
                { "Teal", 0.07f },
                { "Lime", 0.07f },
            }),
            new Wave(40, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.07f },
                { "Red", 0.07f },
                { "Green", 0.07f },
                { "Blue", 0.08f },
                { "Orange", 0.08f },
                { "Purple", 0.08f },
                { "Gray", 0.08f },
                { "Cyan", 0.09f },
                { "Pink", 0.09f },
                { "Brown", 0.09f },
                { "Teal", 0.10f },
                { "Lime", 0.10f },
            }),
            new Wave(60, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.04f },
                { "Red", 0.04f },
                { "Green", 0.05f },
                { "Blue", 0.06f },
                { "Orange", 0.07f },
                { "Purple", 0.08f },
                { "Gray", 0.09f },
                { "Cyan", 0.10f },
                { "Pink", 0.10f },
                { "Brown", 0.11f },
                { "Teal", 0.12f },
                { "Lime", 0.13f },
            }),
            new Wave(80, 15, 0, new Dictionary<string, float>
            {
                { "Yellow", 0.00f },
                { "Red", 0.02f },
                { "Green", 0.03f },
                { "Blue", 0.05f },
                { "Orange", 0.06f },
                { "Purple", 0.08f },
                { "Gray", 0.09f },
                { "Cyan", 0.11f },
                { "Pink", 0.12f },
                { "Brown", 0.14f },
                { "Teal", 0.15f },
                { "Lime", 0.16f },
            }),
        ];
        }
    }
}
