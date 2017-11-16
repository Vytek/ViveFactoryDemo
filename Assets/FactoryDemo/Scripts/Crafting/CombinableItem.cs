using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinableItem : MonoBehaviour {
    public const string TAG_PREFIX = "CraftPart";
    public GameObject[] CombinesWith;
    public GameObject Becomes;

    bool IsPart(GameObject gameObject)
    {
        foreach (GameObject part in CombinesWith)
        {
            if(part == gameObject)
            {
                return true;
            }
        }

        return false;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject = collision.gameObject;

        if (IsPart(gameObject))
        {
            // Doesnt work:
            //gameObject.transform.parent = this.transform;
            //Destroy(gameObject.GetComponent<Rigidbody>());
            //Debug.Log("One");

            //for (int i = 0; i < Becomes.transform.childCount; i++)
            //{
            //    Transform childTransform = Becomes.transform.GetChild(i);

            //    if (childTransform.tag == gameObject.tag)
            //    {
            //        gameObject.transform.localPosition = childTransform.localPosition;
            //        gameObject.transform.localRotation = childTransform.localRotation;

            //        Debug.Log("Final");
            //    }
            //}
        }
    }
}
