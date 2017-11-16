using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatLinearSpawnWave : SpawnWave {
    private int difficultyIndex;

    public void LearnFrom(SpawnWave[] learningWaves, int difficultyIndex)
    {
        int secondToLastIndex = learningWaves.Length - 2;

        this.difficultyIndex = difficultyIndex;

        if (secondToLastIndex >= 0)
        {
            SpawnWave spawnWaveSecondToLast = learningWaves[secondToLastIndex];
            SpawnWave spawnWaveLast = learningWaves[secondToLastIndex + 1];

            WaveObjects = ProjectWaveObjects(spawnWaveSecondToLast, spawnWaveLast);
            ObjectsPerWave = spawnWaveLast.ObjectsPerWave + ((spawnWaveLast.ObjectsPerWave - spawnWaveSecondToLast.ObjectsPerWave) * difficultyIndex);
        }
    }

    private GameObjectWithChance[] ProjectWaveObjects(SpawnWave one, SpawnWave two)
    {
        // TODO: Make this work properly!
        GameObjectWithChance[] waveObjects = (GameObjectWithChance[]) two.WaveObjects.Clone();
        
        return waveObjects;
    }
}
