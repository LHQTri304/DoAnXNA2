using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public static class EnemyFactory
    {
        public static Enemy CreateEnemy(Game1 game, string type, Vector2 position)
        {
            return type switch
            {
                "Red" => new ERed(game, position),
                "Yellow" => new EYellow(game, position),
                "Green" => new EGreen(game, position),
                "Blue" => new EBlue(game, position),
                "Orange" => new EOrange(game, position),
                "Purple" => new EPurple(game, position),
                "Gray" => new EGray(game, position),
                "Cyan" => new ECyan(game, position),
                "Pink" => new EPink(game, position),
                "Brown" => new EBrown(game, position),
                "Teal" => new ETeal(game, position),
                "Lime" => new ELime(game, position),
                "Black" => new EBlack(game, position),
                "White" => new EWhite(game, position),
                "Gold" => new EGold(game, position),
                "Silver" => new ESilver(game, position),
                "Maroon" => new EMaroon(game, position),
                "Navy" => new ENavy(game, position),
                _ => null
            };
        }
    }
}
