using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectRemovedEventArgs : EventArgs
{
    public GameObject GameObject;
}

public class RemoveOnTouch : MonoBehaviour {
    public event EventHandler<GameObjectRemovedEventArgs> GameObjectRemoved;

    void OnTriggerEnter(Collider other)
    {
        GameObject otherGameObject = other.gameObject;
        IRemoveOnTouch removeOnTouch = otherGameObject.GetComponent<IRemoveOnTouch>();

        if(removeOnTouch != null && removeOnTouch.ShouldRemove())
        {
            Destroy(otherGameObject);

            if(GameObjectRemoved != null)
            {
                GameObjectRemoved.Invoke(this, new GameObjectRemovedEventArgs()
                {
                    GameObject = otherGameObject,
                });
            }
        }
    }
}
