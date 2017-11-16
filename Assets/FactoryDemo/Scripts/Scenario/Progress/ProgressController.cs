using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressController : MonoBehaviour {
    public string Name;
    public int Points;
    public int Goal;
    public TextMesh TextMesh;
    public RemoveOnTouch Remover;

    public int AddPoints(int points)
    {
        Points += points;

        UpdateTextMesh();

        return Points;
    }

    // Use this for initialization
    void Start () {
        UpdateTextMesh();

        if(Remover != null)
        {
            Remover.GameObjectRemoved += Remover_GameObjectRemoved;
        }
    }

    void Remover_GameObjectRemoved(object sender, GameObjectRemovedEventArgs e)
    {
        if(e.GameObject.GetComponent<ProgressItem>() != null)
        {
            // Do something
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    void UpdateTextMesh()
    {
        if (TextMesh)
        {
            TextMesh.text = Points.ToString();
        }
    }
}
