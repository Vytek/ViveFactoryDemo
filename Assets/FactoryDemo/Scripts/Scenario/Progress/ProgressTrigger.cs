using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressTrigger : MonoBehaviour
{
    public ProgressController ProgressController;

    void OnTriggerEnter(Collider other)
    {
        ProgressItem progressItem = other.gameObject.GetComponent("ProgressItem") as ProgressItem;

        if (progressItem != null && progressItem.Controller == ProgressController)
        {
            Destroy(other.gameObject);

            ProgressController.AddPoints(progressItem.Modifier);
        }
    }
}
