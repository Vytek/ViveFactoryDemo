using UnityEngine;

public class SpawnWave : MonoBehaviour
{
    public GameObjectWithChance[] WaveObjects;
    public int ObjectsPerWave = 1;

    [System.Serializable]
    public class GameObjectWithChance
    {
        public GameObject GameObject;
        public int ChanceInAHundred;
    }
}