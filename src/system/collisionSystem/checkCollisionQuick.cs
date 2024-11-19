

using System;
using System.Collections.Generic;
using System.Linq;

namespace DoAnXNA2
{
    public static class CheckCollisionQuick
    {
        public static void EnemyVsBulletPlayer(Enemy enemy, List<Bullet> allBullets, Action onCollision)
        {
            allBullets.OfType<BulletPlayer>().ToList().RemoveAll(bullet =>
            {
                return CheckCollision.CheckBounds(
                    enemy.Position, enemy.Texture,
                    bullet.Position, bullet.Texture,
                    onCollision
                );
            });
        }
        public static void PlayerVsBulletEnemy(PlayerShip player, List<Bullet> allBullets, Action onCollision)
        {
            var playerBounds = QuickGetUtilities.GetPlayerBounds(player.Position, player.Texture);
            allBullets.OfType<BulletEnemy>().ToList().RemoveAll(bullet =>
            {
                var bulletBounds = QuickGetUtilities.GetBounds(bullet.Position, bullet.Texture);
                return CheckCollision.CheckBounds(
                    playerBounds,
                    bulletBounds,
                    onCollision
                );
            });
        }
        public static void PlayerVsEnemy(PlayerShip player, List<EnemySpawner> allEnemySpawners, Action onCollision)
        {
            var playerBounds = QuickGetUtilities.GetPlayerBounds(player.Position, player.Texture);
            allEnemySpawners.SelectMany(spawner => spawner.Enemies).ToList().RemoveAll(enemy =>
            {
            var enemyBounds = QuickGetUtilities.GetBounds(enemy.Position, enemy.Texture);
            return CheckCollision.CheckBounds(
                    playerBounds,
                    enemyBounds,
                    onCollision
                );
            });
        }
    }
}