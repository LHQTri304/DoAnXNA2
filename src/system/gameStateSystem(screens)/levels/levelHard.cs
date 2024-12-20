using System.Collections.Generic;

namespace DoAnXNA2.src.levels
{
    public class Level15 : Level
    {
        public Level15() // Yellow Red Green Gray Cyan Black
            : base(maxEnemies: 190, duration: 60)
        {
            Waves = [
                new Wave(0, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.25f },
                { "Red", 0.22f },
                { "Green", 0.18f },
                { "Gray", 0.15f },
                { "Cyan", 0.11f },
                { "Black", 0.08f },
            }),
            new Wave(20, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.22f },
                { "Red", 0.20f },
                { "Green", 0.18f },
                { "Gray", 0.16f },
                { "Cyan", 0.13f },
                { "Black", 0.11f },
            }),
            new Wave(40, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.19f },
                { "Red", 0.18f },
                { "Green", 0.17f },
                { "Gray", 0.16f },
                { "Cyan", 0.16f },
                { "Black", 0.15f },
            }),
            new Wave(60, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.15f },
                { "Red", 0.15f },
                { "Green", 0.16f },
                { "Gray", 0.17f },
                { "Cyan", 0.18f },
                { "Black", 0.19f },
            }),
            new Wave(80, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.10f },
                { "Red", 0.13f },
                { "Green", 0.15f },
                { "Gray", 0.18f },
                { "Cyan", 0.20f },
                { "Black", 0.23f },
            }),
            new Wave(100, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.06f },
                { "Red", 0.10f },
                { "Green", 0.14f },
                { "Gray", 0.19f },
                { "Cyan", 0.23f },
                { "Black", 0.28f },
            }),
            new Wave(120, 15, 0, new Dictionary<string, float>
            {
                { "Yellow", 0.00f },
                { "Red", 0.07f },
                { "Green", 0.13f },
                { "Gray", 0.20f },
                { "Cyan", 0.26f },
                { "Black", 0.33f },
            }),
        ];
        }
    }

    public class Level16 : Level
    {
        public Level16() // Yellow Red Green Blue Gray Cyan Pink Black White
            : base(maxEnemies: 200, duration: 60)
        {
            Waves = [
                new Wave(0, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.18f },
                { "Red", 0.16f },
                { "Green", 0.14f },
                { "Blue", 0.13f },
                { "Gray", 0.11f },
                { "Cyan", 0.09f },
                { "Pink", 0.08f },
                { "Black", 0.06f },
                { "White", 0.04f },
            }),
            new Wave(20, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.16f },
                { "Red", 0.15f },
                { "Green", 0.13f },
                { "Blue", 0.12f },
                { "Gray", 0.11f },
                { "Cyan", 0.10f },
                { "Pink", 0.09f },
                { "Black", 0.08f },
                { "White", 0.07f },
            }),
            new Wave(40, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.13f },
                { "Red", 0.13f },
                { "Green", 0.12f },
                { "Blue", 0.12f },
                { "Gray", 0.11f },
                { "Cyan", 0.11f },
                { "Pink", 0.10f },
                { "Black", 0.09f },
                { "White", 0.09f },
            }),
            new Wave(60, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.11f },
                { "Red", 0.11f },
                { "Green", 0.11f },
                { "Blue", 0.11f },
                { "Gray", 0.11f },
                { "Cyan", 0.11f },
                { "Pink", 0.11f },
                { "Black", 0.11f },
                { "White", 0.11f },
            }),
            new Wave(80, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.09f },
                { "Red", 0.09f },
                { "Green", 0.10f },
                { "Blue", 0.10f },
                { "Gray", 0.11f },
                { "Cyan", 0.12f },
                { "Pink", 0.12f },
                { "Black", 0.13f },
                { "White", 0.14f },
            }),
            new Wave(100, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.06f },
                { "Red", 0.07f },
                { "Green", 0.09f },
                { "Blue", 0.10f },
                { "Gray", 0.11f },
                { "Cyan", 0.12f },
                { "Pink", 0.14f },
                { "Black", 0.15f },
                { "White", 0.16f },
            }),
            new Wave(120, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.03f },
                { "Red", 0.05f },
                { "Green", 0.07f },
                { "Blue", 0.09f },
                { "Gray", 0.11f },
                { "Cyan", 0.13f },
                { "Pink", 0.15f },
                { "Black", 0.17f },
                { "White", 0.19f },
            }),
            new Wave(140, 15, 0, new Dictionary<string, float>
            {
                { "Yellow", 0.00f },
                { "Red", 0.03f },
                { "Green", 0.06f },
                { "Blue", 0.08f },
                { "Gray", 0.11f },
                { "Cyan", 0.14f },
                { "Pink", 0.17f },
                { "Black", 0.19f },
                { "White", 0.22f },
            }),
        ];
        }
    }

    public class Level17 : Level
    {
        public Level17() // Yellow Red Green Blue Orange Gray Cyan Pink Brown Black White Gold
            : base(maxEnemies: 210, duration: 60)
        {
            Waves = [
                new Wave(0, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.14f },
                { "Red", 0.13f },
                { "Green", 0.12f },
                { "Blue", 0.11f },
                { "Orange", 0.10f },
                { "Gray", 0.09f },
                { "Cyan", 0.08f },
                { "Pink", 0.07f },
                { "Brown", 0.06f },
                { "Black", 0.05f },
                { "White", 0.04f },
                { "Gold", 0.03f },
            }),
            new Wave(20, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.12f },
                { "Red", 0.12f },
                { "Green", 0.11f },
                { "Blue", 0.10f },
                { "Orange", 0.09f },
                { "Gray", 0.09f },
                { "Cyan", 0.08f },
                { "Pink", 0.07f },
                { "Brown", 0.07f },
                { "Black", 0.06f },
                { "White", 0.05f },
                { "Gold", 0.04f },
            }),
            new Wave(40, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.11f },
                { "Red", 0.10f },
                { "Green", 0.10f },
                { "Blue", 0.09f },
                { "Orange", 0.09f },
                { "Gray", 0.09f },
                { "Cyan", 0.08f },
                { "Pink", 0.08f },
                { "Brown", 0.07f },
                { "Black", 0.07f },
                { "White", 0.06f },
                { "Gold", 0.06f },
            }),
            new Wave(60, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.09f },
                { "Red", 0.09f },
                { "Green", 0.09f },
                { "Blue", 0.09f },
                { "Orange", 0.09f },
                { "Gray", 0.08f },
                { "Cyan", 0.08f },
                { "Pink", 0.08f },
                { "Brown", 0.08f },
                { "Black", 0.08f },
                { "White", 0.08f },
                { "Gold", 0.08f },
            }),
            new Wave(80, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.07f },
                { "Red", 0.08f },
                { "Green", 0.08f },
                { "Blue", 0.08f },
                { "Orange", 0.08f },
                { "Gray", 0.08f },
                { "Cyan", 0.08f },
                { "Pink", 0.09f },
                { "Brown", 0.09f },
                { "Black", 0.09f },
                { "White", 0.09f },
                { "Gold", 0.09f },
            }),
            new Wave(100, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.06f },
                { "Red", 0.06f },
                { "Green", 0.07f },
                { "Blue", 0.07f },
                { "Orange", 0.08f },
                { "Gray", 0.08f },
                { "Cyan", 0.09f },
                { "Pink", 0.09f },
                { "Brown", 0.09f },
                { "Black", 0.10f },
                { "White", 0.10f },
                { "Gold", 0.11f },
            }),
            new Wave(120, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.04f },
                { "Red", 0.05f },
                { "Green", 0.06f },
                { "Blue", 0.06f },
                { "Orange", 0.07f },
                { "Gray", 0.08f },
                { "Cyan", 0.09f },
                { "Pink", 0.10f },
                { "Brown", 0.10f },
                { "Black", 0.11f },
                { "White", 0.12f },
                { "Gold", 0.13f },
            }),
            new Wave(140, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.02f },
                { "Red", 0.03f },
                { "Green", 0.04f },
                { "Blue", 0.06f },
                { "Orange", 0.07f },
                { "Gray", 0.08f },
                { "Cyan", 0.09f },
                { "Pink", 0.10f },
                { "Brown", 0.11f },
                { "Black", 0.12f },
                { "White", 0.13f },
                { "Gold", 0.15f },
            }),
            new Wave(160, 15, 0, new Dictionary<string, float>
            {
                { "Yellow", 0.00f },
                { "Red", 0.02f },
                { "Green", 0.03f },
                { "Blue", 0.05f },
                { "Orange", 0.06f },
                { "Gray", 0.08f },
                { "Cyan", 0.09f },
                { "Pink", 0.11f },
                { "Brown", 0.12f },
                { "Black", 0.14f },
                { "White", 0.15f },
                { "Gold", 0.16f },
            }),
        ];
        }
    }

    public class Level18 : Level
    {
        public Level18() // Yellow Red Green Blue Orange Purple Gray Cyan Pink Brown Teal Black White Gold Silver
            : base(maxEnemies: 220, duration: 60)
        {
            Waves = [
                new Wave(0, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.11f },
                { "Red", 0.11f },
                { "Green", 0.10f },
                { "Blue", 0.09f },
                { "Orange", 0.09f },
                { "Purple", 0.08f },
                { "Gray", 0.07f },
                { "Cyan", 0.07f },
                { "Pink", 0.06f },
                { "Brown", 0.05f },
                { "Teal", 0.05f },
                { "Black", 0.04f },
                { "White", 0.03f },
                { "Gold", 0.03f },
                { "Silver", 0.02f },
            }),
            new Wave(20, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.10f },
                { "Red", 0.10f },
                { "Green", 0.09f },
                { "Blue", 0.09f },
                { "Orange", 0.08f },
                { "Purple", 0.08f },
                { "Gray", 0.07f },
                { "Cyan", 0.07f },
                { "Pink", 0.06f },
                { "Brown", 0.06f },
                { "Teal", 0.05f },
                { "Black", 0.05f },
                { "White", 0.04f },
                { "Gold", 0.04f },
                { "Silver", 0.03f },
            }),
            new Wave(40, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.09f },
                { "Red", 0.09f },
                { "Green", 0.08f },
                { "Blue", 0.08f },
                { "Orange", 0.08f },
                { "Purple", 0.07f },
                { "Gray", 0.07f },
                { "Cyan", 0.07f },
                { "Pink", 0.06f },
                { "Brown", 0.06f },
                { "Teal", 0.06f },
                { "Black", 0.05f },
                { "White", 0.05f },
                { "Gold", 0.05f },
                { "Silver", 0.04f },
            }),
            new Wave(60, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.08f },
                { "Red", 0.08f },
                { "Green", 0.08f },
                { "Blue", 0.07f },
                { "Orange", 0.07f },
                { "Purple", 0.07f },
                { "Gray", 0.07f },
                { "Cyan", 0.07f },
                { "Pink", 0.06f },
                { "Brown", 0.06f },
                { "Teal", 0.06f },
                { "Black", 0.06f },
                { "White", 0.06f },
                { "Gold", 0.06f },
                { "Silver", 0.05f },
            }),
            new Wave(80, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.07f },
                { "Red", 0.07f },
                { "Green", 0.07f },
                { "Blue", 0.07f },
                { "Orange", 0.07f },
                { "Purple", 0.07f },
                { "Gray", 0.07f },
                { "Cyan", 0.07f },
                { "Pink", 0.07f },
                { "Brown", 0.07f },
                { "Teal", 0.07f },
                { "Black", 0.07f },
                { "White", 0.07f },
                { "Gold", 0.07f },
                { "Silver", 0.07f },
            }),
            new Wave(100, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.05f },
                { "Red", 0.06f },
                { "Green", 0.06f },
                { "Blue", 0.06f },
                { "Orange", 0.06f },
                { "Purple", 0.06f },
                { "Gray", 0.06f },
                { "Cyan", 0.07f },
                { "Pink", 0.07f },
                { "Brown", 0.07f },
                { "Teal", 0.07f },
                { "Black", 0.07f },
                { "White", 0.08f },
                { "Gold", 0.08f },
                { "Silver", 0.08f },
            }),
            new Wave(120, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.04f },
                { "Red", 0.05f },
                { "Green", 0.05f },
                { "Blue", 0.05f },
                { "Orange", 0.06f },
                { "Purple", 0.06f },
                { "Gray", 0.06f },
                { "Cyan", 0.07f },
                { "Pink", 0.07f },
                { "Brown", 0.07f },
                { "Teal", 0.08f },
                { "Black", 0.08f },
                { "White", 0.08f },
                { "Gold", 0.09f },
                { "Silver", 0.09f },
            }),
            new Wave(140, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.03f },
                { "Red", 0.03f },
                { "Green", 0.04f },
                { "Blue", 0.04f },
                { "Orange", 0.05f },
                { "Purple", 0.06f },
                { "Gray", 0.06f },
                { "Cyan", 0.07f },
                { "Pink", 0.07f },
                { "Brown", 0.08f },
                { "Teal", 0.08f },
                { "Black", 0.09f },
                { "White", 0.09f },
                { "Gold", 0.10f },
                { "Silver", 0.10f },
            }),
            new Wave(160, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.02f },
                { "Red", 0.02f },
                { "Green", 0.03f },
                { "Blue", 0.04f },
                { "Orange", 0.04f },
                { "Purple", 0.05f },
                { "Gray", 0.06f },
                { "Cyan", 0.07f },
                { "Pink", 0.07f },
                { "Brown", 0.08f },
                { "Teal", 0.09f },
                { "Black", 0.10f },
                { "White", 0.10f },
                { "Gold", 0.11f },
                { "Silver", 0.12f },
            }),
            new Wave(180, 15, 0, new Dictionary<string, float>
            {
                { "Yellow", 0.00f },
                { "Red", 0.01f },
                { "Green", 0.02f },
                { "Blue", 0.03f },
                { "Orange", 0.04f },
                { "Purple", 0.05f },
                { "Gray", 0.06f },
                { "Cyan", 0.07f },
                { "Pink", 0.08f },
                { "Brown", 0.09f },
                { "Teal", 0.09f },
                { "Black", 0.10f },
                { "White", 0.11f },
                { "Gold", 0.12f },
                { "Silver", 0.13f },
            }),
        ];
        }
    }

    public class Level19 : Level
    {
        public Level19() // Yellow Red Green Blue Orange Purple Gray Cyan Pink Brown Teal Lime Black White Gold Silver Maroon
            : base(maxEnemies: 230, duration: 60)
        {
            Waves = [
                new Wave(0, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.10f },
                { "Red", 0.10f },
                { "Green", 0.09f },
                { "Blue", 0.09f },
                { "Orange", 0.08f },
                { "Purple", 0.07f },
                { "Gray", 0.07f },
                { "Cyan", 0.06f },
                { "Pink", 0.06f },
                { "Brown", 0.05f },
                { "Teal", 0.05f },
                { "Lime", 0.04f },
                { "Black", 0.04f },
                { "White", 0.03f },
                { "Gold", 0.03f },
                { "Silver", 0.02f },
                { "Maroon", 0.02f },
            }),
            new Wave(20, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.09f },
                { "Red", 0.09f },
                { "Green", 0.08f },
                { "Blue", 0.08f },
                { "Orange", 0.08f },
                { "Purple", 0.07f },
                { "Gray", 0.07f },
                { "Cyan", 0.06f },
                { "Pink", 0.06f },
                { "Brown", 0.05f },
                { "Teal", 0.05f },
                { "Lime", 0.05f },
                { "Black", 0.04f },
                { "White", 0.04f },
                { "Gold", 0.03f },
                { "Silver", 0.03f },
                { "Maroon", 0.03f },
            }),
            new Wave(40, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.08f },
                { "Red", 0.08f },
                { "Green", 0.08f },
                { "Blue", 0.07f },
                { "Orange", 0.07f },
                { "Purple", 0.07f },
                { "Gray", 0.06f },
                { "Cyan", 0.06f },
                { "Pink", 0.06f },
                { "Brown", 0.06f },
                { "Teal", 0.05f },
                { "Lime", 0.05f },
                { "Black", 0.05f },
                { "White", 0.04f },
                { "Gold", 0.04f },
                { "Silver", 0.04f },
                { "Maroon", 0.03f },
            }),
            new Wave(60, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.07f },
                { "Red", 0.07f },
                { "Green", 0.07f },
                { "Blue", 0.07f },
                { "Orange", 0.07f },
                { "Purple", 0.06f },
                { "Gray", 0.06f },
                { "Cyan", 0.06f },
                { "Pink", 0.06f },
                { "Brown", 0.06f },
                { "Teal", 0.06f },
                { "Lime", 0.05f },
                { "Black", 0.05f },
                { "White", 0.05f },
                { "Gold", 0.05f },
                { "Silver", 0.05f },
                { "Maroon", 0.04f },
            }),
            new Wave(80, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.06f },
                { "Red", 0.06f },
                { "Green", 0.06f },
                { "Blue", 0.06f },
                { "Orange", 0.06f },
                { "Purple", 0.06f },
                { "Gray", 0.06f },
                { "Cyan", 0.06f },
                { "Pink", 0.06f },
                { "Brown", 0.06f },
                { "Teal", 0.06f },
                { "Lime", 0.06f },
                { "Black", 0.06f },
                { "White", 0.06f },
                { "Gold", 0.06f },
                { "Silver", 0.05f },
                { "Maroon", 0.05f },
            }),
            new Wave(100, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.05f },
                { "Red", 0.05f },
                { "Green", 0.06f },
                { "Blue", 0.06f },
                { "Orange", 0.06f },
                { "Purple", 0.06f },
                { "Gray", 0.06f },
                { "Cyan", 0.06f },
                { "Pink", 0.06f },
                { "Brown", 0.06f },
                { "Teal", 0.06f },
                { "Lime", 0.06f },
                { "Black", 0.06f },
                { "White", 0.06f },
                { "Gold", 0.06f },
                { "Silver", 0.06f },
                { "Maroon", 0.06f },
            }),
            new Wave(120, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.04f },
                { "Red", 0.05f },
                { "Green", 0.05f },
                { "Blue", 0.05f },
                { "Orange", 0.05f },
                { "Purple", 0.05f },
                { "Gray", 0.06f },
                { "Cyan", 0.06f },
                { "Pink", 0.06f },
                { "Brown", 0.06f },
                { "Teal", 0.06f },
                { "Lime", 0.06f },
                { "Black", 0.07f },
                { "White", 0.07f },
                { "Gold", 0.07f },
                { "Silver", 0.07f },
                { "Maroon", 0.07f },
            }),
            new Wave(140, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.03f },
                { "Red", 0.04f },
                { "Green", 0.04f },
                { "Blue", 0.04f },
                { "Orange", 0.05f },
                { "Purple", 0.05f },
                { "Gray", 0.05f },
                { "Cyan", 0.06f },
                { "Pink", 0.06f },
                { "Brown", 0.06f },
                { "Teal", 0.07f },
                { "Lime", 0.07f },
                { "Black", 0.07f },
                { "White", 0.07f },
                { "Gold", 0.08f },
                { "Silver", 0.08f },
                { "Maroon", 0.08f },
            }),
            new Wave(160, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.02f },
                { "Red", 0.03f },
                { "Green", 0.03f },
                { "Blue", 0.04f },
                { "Orange", 0.04f },
                { "Purple", 0.05f },
                { "Gray", 0.05f },
                { "Cyan", 0.05f },
                { "Pink", 0.06f },
                { "Brown", 0.06f },
                { "Teal", 0.07f },
                { "Lime", 0.07f },
                { "Black", 0.08f },
                { "White", 0.08f },
                { "Gold", 0.09f },
                { "Silver", 0.09f },
                { "Maroon", 0.09f },
            }),
            new Wave(180, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.01f },
                { "Red", 0.02f },
                { "Green", 0.02f },
                { "Blue", 0.03f },
                { "Orange", 0.04f },
                { "Purple", 0.04f },
                { "Gray", 0.05f },
                { "Cyan", 0.05f },
                { "Pink", 0.06f },
                { "Brown", 0.06f },
                { "Teal", 0.07f },
                { "Lime", 0.08f },
                { "Black", 0.08f },
                { "White", 0.09f },
                { "Gold", 0.09f },
                { "Silver", 0.10f },
                { "Maroon", 0.11f },
            }),
            new Wave(200, 15, 0, new Dictionary<string, float>
            {
                { "Yellow", 0.00f },
                { "Red", 0.01f },
                { "Green", 0.02f },
                { "Blue", 0.02f },
                { "Orange", 0.03f },
                { "Purple", 0.04f },
                { "Gray", 0.04f },
                { "Cyan", 0.05f },
                { "Pink", 0.06f },
                { "Brown", 0.07f },
                { "Teal", 0.07f },
                { "Lime", 0.08f },
                { "Black", 0.09f },
                { "White", 0.09f },
                { "Gold", 0.10f },
                { "Silver", 0.11f },
                { "Maroon", 0.12f },
            }),
        ];
        }
    }

    public class Level20 : Level
    {
        public Level20() // Yellow Red Green Blue Orange Purple Gray Cyan Pink Brown Teal Lime Black White Gold Silver Maroon Navy
            : base(maxEnemies: 240, duration: 60)
        {
            Waves = [
                new Wave(0, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.10f },
                { "Red", 0.09f },
                { "Green", 0.09f },
                { "Blue", 0.08f },
                { "Orange", 0.08f },
                { "Purple", 0.07f },
                { "Gray", 0.07f },
                { "Cyan", 0.06f },
                { "Pink", 0.06f },
                { "Brown", 0.05f },
                { "Teal", 0.05f },
                { "Lime", 0.04f },
                { "Black", 0.04f },
                { "White", 0.03f },
                { "Gold", 0.03f },
                { "Silver", 0.02f },
                { "Maroon", 0.02f },
                { "Navy", 0.01f },
            }),
            new Wave(20, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.09f },
                { "Red", 0.08f },
                { "Green", 0.08f },
                { "Blue", 0.08f },
                { "Orange", 0.07f },
                { "Purple", 0.07f },
                { "Gray", 0.07f },
                { "Cyan", 0.06f },
                { "Pink", 0.06f },
                { "Brown", 0.05f },
                { "Teal", 0.05f },
                { "Lime", 0.05f },
                { "Black", 0.04f },
                { "White", 0.04f },
                { "Gold", 0.03f },
                { "Silver", 0.03f },
                { "Maroon", 0.03f },
                { "Navy", 0.02f },
            }),
            new Wave(40, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.08f },
                { "Red", 0.08f },
                { "Green", 0.07f },
                { "Blue", 0.07f },
                { "Orange", 0.07f },
                { "Purple", 0.07f },
                { "Gray", 0.06f },
                { "Cyan", 0.06f },
                { "Pink", 0.06f },
                { "Brown", 0.05f },
                { "Teal", 0.05f },
                { "Lime", 0.05f },
                { "Black", 0.05f },
                { "White", 0.04f },
                { "Gold", 0.04f },
                { "Silver", 0.04f },
                { "Maroon", 0.03f },
                { "Navy", 0.03f },
            }),
            new Wave(60, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.07f },
                { "Red", 0.07f },
                { "Green", 0.07f },
                { "Blue", 0.07f },
                { "Orange", 0.06f },
                { "Purple", 0.06f },
                { "Gray", 0.06f },
                { "Cyan", 0.06f },
                { "Pink", 0.06f },
                { "Brown", 0.05f },
                { "Teal", 0.05f },
                { "Lime", 0.05f },
                { "Black", 0.05f },
                { "White", 0.05f },
                { "Gold", 0.04f },
                { "Silver", 0.04f },
                { "Maroon", 0.04f },
                { "Navy", 0.04f },
            }),
            new Wave(80, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.06f },
                { "Red", 0.06f },
                { "Green", 0.06f },
                { "Blue", 0.06f },
                { "Orange", 0.06f },
                { "Purple", 0.06f },
                { "Gray", 0.06f },
                { "Cyan", 0.06f },
                { "Pink", 0.06f },
                { "Brown", 0.06f },
                { "Teal", 0.05f },
                { "Lime", 0.05f },
                { "Black", 0.05f },
                { "White", 0.05f },
                { "Gold", 0.05f },
                { "Silver", 0.05f },
                { "Maroon", 0.05f },
                { "Navy", 0.05f },
            }),
            new Wave(100, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.06f },
                { "Red", 0.06f },
                { "Green", 0.06f },
                { "Blue", 0.06f },
                { "Orange", 0.06f },
                { "Purple", 0.06f },
                { "Gray", 0.06f },
                { "Cyan", 0.06f },
                { "Pink", 0.06f },
                { "Brown", 0.06f },
                { "Teal", 0.06f },
                { "Lime", 0.06f },
                { "Black", 0.06f },
                { "White", 0.06f },
                { "Gold", 0.06f },
                { "Silver", 0.06f },
                { "Maroon", 0.06f },
                { "Navy", 0.06f },
            }),
            new Wave(120, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.05f },
                { "Red", 0.05f },
                { "Green", 0.05f },
                { "Blue", 0.05f },
                { "Orange", 0.05f },
                { "Purple", 0.05f },
                { "Gray", 0.05f },
                { "Cyan", 0.05f },
                { "Pink", 0.06f },
                { "Brown", 0.06f },
                { "Teal", 0.06f },
                { "Lime", 0.06f },
                { "Black", 0.06f },
                { "White", 0.06f },
                { "Gold", 0.06f },
                { "Silver", 0.06f },
                { "Maroon", 0.06f },
                { "Navy", 0.06f },
            }),
            new Wave(140, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.04f },
                { "Red", 0.04f },
                { "Green", 0.04f },
                { "Blue", 0.04f },
                { "Orange", 0.05f },
                { "Purple", 0.05f },
                { "Gray", 0.05f },
                { "Cyan", 0.05f },
                { "Pink", 0.05f },
                { "Brown", 0.06f },
                { "Teal", 0.06f },
                { "Lime", 0.06f },
                { "Black", 0.06f },
                { "White", 0.06f },
                { "Gold", 0.07f },
                { "Silver", 0.07f },
                { "Maroon", 0.07f },
                { "Navy", 0.07f },
            }),
            new Wave(160, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.03f },
                { "Red", 0.03f },
                { "Green", 0.04f },
                { "Blue", 0.04f },
                { "Orange", 0.04f },
                { "Purple", 0.04f },
                { "Gray", 0.05f },
                { "Cyan", 0.05f },
                { "Pink", 0.05f },
                { "Brown", 0.06f },
                { "Teal", 0.06f },
                { "Lime", 0.06f },
                { "Black", 0.07f },
                { "White", 0.07f },
                { "Gold", 0.07f },
                { "Silver", 0.08f },
                { "Maroon", 0.08f },
                { "Navy", 0.08f },
            }),
            new Wave(180, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.02f },
                { "Red", 0.02f },
                { "Green", 0.03f },
                { "Blue", 0.03f },
                { "Orange", 0.04f },
                { "Purple", 0.04f },
                { "Gray", 0.05f },
                { "Cyan", 0.05f },
                { "Pink", 0.05f },
                { "Brown", 0.06f },
                { "Teal", 0.06f },
                { "Lime", 0.07f },
                { "Black", 0.07f },
                { "White", 0.07f },
                { "Gold", 0.08f },
                { "Silver", 0.08f },
                { "Maroon", 0.09f },
                { "Navy", 0.09f },
            }),
            new Wave(200, 15, 5, new Dictionary<string, float>
            {
                { "Yellow", 0.01f },
                { "Red", 0.02f },
                { "Green", 0.02f },
                { "Blue", 0.03f },
                { "Orange", 0.03f },
                { "Purple", 0.04f },
                { "Gray", 0.04f },
                { "Cyan", 0.05f },
                { "Pink", 0.05f },
                { "Brown", 0.06f },
                { "Teal", 0.06f },
                { "Lime", 0.07f },
                { "Black", 0.07f },
                { "White", 0.08f },
                { "Gold", 0.08f },
                { "Silver", 0.09f },
                { "Maroon", 0.09f },
                { "Navy", 0.10f },
            }),
            new Wave(220, 15, 0, new Dictionary<string, float>
            {
                { "Yellow", 0.00f },
                { "Red", 0.01f },
                { "Green", 0.01f },
                { "Blue", 0.02f },
                { "Orange", 0.03f },
                { "Purple", 0.03f },
                { "Gray", 0.04f },
                { "Cyan", 0.05f },
                { "Pink", 0.05f },
                { "Brown", 0.06f },
                { "Teal", 0.07f },
                { "Lime", 0.07f },
                { "Black", 0.08f },
                { "White", 0.08f },
                { "Gold", 0.09f },
                { "Silver", 0.10f },
                { "Maroon", 0.10f },
                { "Navy", 0.11f },
            }),
        ];
        }
    }
}
