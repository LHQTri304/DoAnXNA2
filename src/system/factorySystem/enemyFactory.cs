using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public static class EnemyFactory
    {
        public static Enemy CreateEnemy(string type, Vector2 position)
        {
            return type switch
            {
                "Red" => new ERed(position),
                "Yellow" => new EYellow(position),
                "Green" => new EGreen(position),
                "Blue" => new EBlue(position),
                "Orange" => new EOrange(position),
                "Purple" => new EPurple(position),
                "Gray" => new EGray(position),
                "Cyan" => new ECyan(position),
                "Pink" => new EPink(position),
                "Brown" => new EBrown(position),
                "Teal" => new ETeal(position),
                "Lime" => new ELime(position),
                "Black" => new EBlack(position),
                "White" => new EWhite(position),
                "Gold" => new EGold(position),
                "Silver" => new ESilver(position),
                "Maroon" => new EMaroon(position),
                "Navy" => new ENavy(position),
                _ => null
            };
        }
    }
}
