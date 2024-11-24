using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace DoAnXNA2
{
    public abstract class Level
    {
        public int MaxEnemies { get; protected set; }
        protected int SpawnedEnemies;
        protected double Duration; // Thời gian tối đa của màn chơi (giây)
        protected double ElapsedTime;
        protected Random random = new();

        public List<Wave> Waves { get; protected set; } = []; // Danh sách các đợt tấn công
        private int CurrentWaveIndex;
        private bool IsResting;

        public Level(int maxEnemies, double duration, List<Wave> waves = null)
        {
            MaxEnemies = maxEnemies;
            Duration = duration;
            if (waves != null)
                Waves = waves;
            CurrentWaveIndex = 0;
            SpawnedEnemies = 0;
            ElapsedTime = 0;
            IsResting = false;
        }

        public void Update(GameTime gameTime)
        {
            ElapsedTime += gameTime.ElapsedGameTime.TotalSeconds;

            if (CurrentWaveIndex >= Waves.Count && SpawnedEnemies >= MaxEnemies)
            {
                // Kết thúc màn chơi nếu đã hết đợt hoặc số lượng kẻ địch đạt giới hạn
                MainRes.IsAbleToWin = true;
                return;
            }

            Wave currentWave = Waves[CurrentWaveIndex];

            if (IsResting)
            {
                if (ElapsedTime >= currentWave.EndTime + currentWave.RestDuration)
                {
                    // Kết thúc giai đoạn nghỉ, chuyển sang đợt tiếp theo
                    IsResting = false;
                    CurrentWaveIndex++;
                    if (CurrentWaveIndex < Waves.Count)
                        ElapsedTime = Waves[CurrentWaveIndex].StartTime; // Đồng bộ thời gian cho wave tiếp theo
                }
            }
            else
            {
                if (ElapsedTime >= currentWave.StartTime && ElapsedTime <= currentWave.EndTime)
                {
                    // Spawn kẻ địch trong wave hiện tại
                    currentWave.SpawnEnemies(gameTime, ref SpawnedEnemies);
                }
                else if (ElapsedTime > currentWave.EndTime)
                {
                    // Kết thúc wave, bắt đầu giai đoạn nghỉ
                    IsResting = true;
                }
            }
        }
    }

    public class Wave
    {
        public double StartTime { get; }
        public double EndTime { get; }
        public double RestDuration { get; }
        private Dictionary<string, float> EnemySpawnRates;
        private Random random = new();
        private double LastSpawnTime;
        private double SpawnInterval;

        public Wave(double startTime, double duration, double restDuration, Dictionary<string, float> enemySpawnRates, double spawnInterval = 0.5)
        {
            StartTime = startTime;
            EndTime = startTime + duration;
            RestDuration = restDuration;
            EnemySpawnRates = enemySpawnRates;
            SpawnInterval = spawnInterval;
            LastSpawnTime = 0;
        }

        public void SpawnEnemies(GameTime gameTime, ref int spawnedEnemies)
        {
            double currentTime = gameTime.TotalGameTime.TotalSeconds;

            if (currentTime - LastSpawnTime >= SpawnInterval)
            {
                // Sinh kẻ địch
                string enemyType = SelectEnemyType();
                MainRes.AllSpawners[enemyType].SpawnEnemy();

                LastSpawnTime = currentTime;
                spawnedEnemies++;
            }
        }

        private string SelectEnemyType()
        {
            float randValue = (float)random.NextDouble();
            float cumulative = 0;

            foreach (var entry in EnemySpawnRates)
            {
                cumulative += entry.Value;
                if (randValue <= cumulative)
                {
                    return entry.Key;
                }
            }

            return EnemySpawnRates.Keys.First();
        }
    }
}