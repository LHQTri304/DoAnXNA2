

using System;
using System.Collections.Generic;
using System.Linq;

namespace DoAnXNA2
{
    public static class CheckCollisionQuick
    {
        public static void EnemyVsBulletPlayer(Enemy enemy, Action onCollisionBonusAction = null)
        {
            var enemyBounds = QuickGetUtilities.GetPlayerBounds(enemy.Position, enemy.Texture);
            MainRes.AllBullets.RemoveAll(bullet =>
            {
                if (bullet is BulletPlayer bulletPlayer)
                {
                    var bulletBounds = QuickGetUtilities.GetBounds(bulletPlayer.Position, bulletPlayer.Texture);
                    return CheckCollision.CheckBounds(
                        enemyBounds,
                        bulletBounds,
                        () =>
                        {
                            enemy.TakeDamage(bulletPlayer.Damage);
                        }
                    );
                }
                return false;
            });
        }

        public static void PlayerVsBulletEnemy(Action onCollisionBonusAction = null)
        {
            var player = MainRes.PlayerShip;
            var playerBounds = QuickGetUtilities.GetPlayerBounds(player.Position, player.Texture);
            MainRes.AllBullets.RemoveAll(bullet =>
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

        public static void PlayerVsEnemy(Action onCollisionBonusAction = null)
        {
            var player = MainRes.PlayerShip;
            var playerBounds = QuickGetUtilities.GetPlayerBounds(player.Position, player.Texture);
            MainRes.AllEnemies.RemoveAll(bullet =>
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