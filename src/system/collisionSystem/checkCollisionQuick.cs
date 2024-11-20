

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

        public static void PlayerVsBulletEnemy(Game1 game1, Action onCollisionBonusAction = null)
        {
            var player = game1._playerShip;
            var playerBounds = QuickGetUtilities.GetPlayerBounds(player.Position, player.Texture);
            game1._allBullets.RemoveAll(bullet =>
            {
                if (bullet is BulletEnemy bulletEnemy)
                {
                    var bulletBounds = QuickGetUtilities.GetBounds(bulletEnemy.Position, bulletEnemy.Texture);
                    return CheckCollision.CheckBounds(
                        playerBounds,
                        bulletBounds,
                        () =>
                        {
                            player.TakeDamage(bulletEnemy.Damage);
                            System.Diagnostics.Debug.WriteLine($"bạn đã bị bắn\nHP còn: {player.HP}");
                        }
                    );
                }
                return false;
            });
        }

        public static void PlayerVsEnemy(Game1 game1, Action onCollisionBonusAction = null)
        {
            var player = game1._playerShip;
            var playerBounds = QuickGetUtilities.GetPlayerBounds(player.Position, player.Texture);
            game1._allEnemies.RemoveAll(bullet =>
            {
                if (bullet is Enemy Enemy)
                {
                    var bulletBounds = QuickGetUtilities.GetBounds(Enemy.Position, Enemy.Texture);
                    return CheckCollision.CheckBounds(
                        playerBounds,
                        bulletBounds,
                        () =>
                        {
                            player.TakeDamage(DMGStatsManager.InstantKill);
                            System.Diagnostics.Debug.WriteLine($"bạn đã bị bắn\nHP còn: {player.HP}");
                        }
                    );
                }
                return false;
            });
        }
    }
}