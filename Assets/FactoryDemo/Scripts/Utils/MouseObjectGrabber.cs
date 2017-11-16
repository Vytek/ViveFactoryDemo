using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseObjectGrabber : MonoBehaviour {
    public Camera Camera;
    public GameObject GrabbingObject;

	// Use this for initialization
	void Start () {
    }
	
	void LateUpdate()
    {
        Ray ray = Camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0.1f));

        RaycastHit rayCastHit;
        bool hit = Physics.Raycast(ray.origin, ray.direction * 5, out rayCastHit);
        Debug.DrawRay(ray.origin, ray.direction * 5, Color.red);

        if (hit)
        {
            Rigidbody body = rayCastHit.rigidbody;

            if (body != null)
            {
                if (Input.GetAxis("Fire1") > 0)
                {
                    if (GrabbingObject == null)
                    {
                        body.transform.parent = Camera.transform;
                        body.useGravity = false;
                        body.velocity = new Vector3(0, 0, 0);
                        body.isKinematic = true;

                        GrabbingObject = body.gameObject;
                    }
                }
                else if (GrabbingObject && body.transform.parent == Camera.transform)
                {
                    body.transform.parent = null;
                    body.isKinematic = false;
                    body.useGravity = true;

                    GrabbingObject = null;
                    body.AddForce(transform.forward * 500);
                }
            }
        }
    }
}
