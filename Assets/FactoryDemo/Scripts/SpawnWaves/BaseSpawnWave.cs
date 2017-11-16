using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnWaveRepeatMode
{
    LINEAR
}

public class BaseSpawnWave : MonoBehaviour {
    public SpawnWave[] SpawnWaves;
    public GameObject SpawnObject;
    public int WaveDelayInSeconds;
    public int StartWave = 0;
    public bool RepeatIndefinitly;
    public SpawnWaveRepeatMode RepeatMode;

    private int currentWave;
    private long nextWave;

    private void DelayNextWave()
    {

        nextWave = DateTime.Now.Ticks + (TimeSpan.TicksPerSecond * WaveDelayInSeconds);
    }


    // Use this for initialization
    void Start () {
        currentWave = StartWave;

        DelayNextWave();
    }
	
	// Update is called once per frame
	void Update () {
        if (nextWave <= DateTime.Now.Ticks && (currentWave < SpawnWaves.Length || RepeatIndefinitly))
        {
            DelayNextWave();

            StartCoroutine(TryInstantiateGameObjects());

            currentWave++;
        }
	}

    protected IEnumerator TryInstantiateGameObjects()
    {
        SpawnWave spawnWave;
        int spawnedObjects = 0;

        if(currentWave < SpawnWaves.Length)
        {
            spawnWave = SpawnWaves[currentWave];
        }
        else
        {
            spawnWave = SpawnObject.AddComponent<RepeatLinearSpawnWave>();
            ((RepeatLinearSpawnWave) spawnWave).LearnFrom(SpawnWaves, currentWave + 1 - SpawnWaves.Length);
        }

        while (spawnedObjects < spawnWave.ObjectsPerWave)
        {
            if (!IsSpawnBlocked())
            {
                foreach (SpawnWave.GameObjectWithChance data in spawnWave.WaveObjects)
                {
                    if (RandomNumber.Next(100) < data.ChanceInAHundred)
                    {
                        InstantiateGameObject(data.GameObject, SpawnObject.transform);

                        spawnedObjects++;
                    }
                }
            }

            yield return new WaitForSeconds(.1f);
        }
    }

    protected virtual bool IsSpawnBlocked()
    {
        Collider[] hitColliders = Physics.OverlapSphere(SpawnObject.transform.position, .01f);
        return hitColliders.Length > 0;
    }

    protected virtual GameObject InstantiateGameObject(GameObject gameObject, Transform transform)
    {
        GameObject newObject = GameObject.Instantiate(gameObject);
        newObject.transform.position = transform.position;
        newObject.transform.eulerAngles = transform.eulerAngles;

        return newObject;
    }
}
