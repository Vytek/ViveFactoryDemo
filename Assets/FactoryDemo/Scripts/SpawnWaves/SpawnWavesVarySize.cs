using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWavesVarySize : BaseSpawnWave
{
    protected override GameObject InstantiateGameObject(GameObject gameObject, Transform transform)
    {
        float size = RandomNumber.Next(100) / 100f - .5f;

        GameObject newObject = GameObject.Instantiate(gameObject);
        newObject.transform.position = transform.position;
        newObject.transform.eulerAngles = transform.eulerAngles;
        newObject.transform.localScale += new Vector3(size, size, size);

        return newObject;
    }
}
