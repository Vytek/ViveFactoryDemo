using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltController : MonoBehaviour {
    private const float SPEED_MODIFIER = 0.01f;

    [System.Serializable]
    public class ConveyorBelt
    {
        public Collider Collider;
        public int SpeedZ;
        public int SpeedX;
    }

    public ConveyorBelt[] ConveyorBelts;

    // Use this for initialization
    void Start () {

    }
	
    void OnTriggerStay(Collider other)
    {
        foreach (ConveyorBelt conveyor in ConveyorBelts)
        {
            if (other.gameObject.transform.parent == null && conveyor.Collider.bounds.Contains(other.gameObject.transform.position))
            {
                Rigidbody otherRigidbody = other.gameObject.GetComponent<Rigidbody>();
                Vector3 oldPosition = otherRigidbody.transform.position;
                //otherRigidbody.transform.position = new Vector3(oldPosition.x + (conveyor.SpeedX * SPEED_MODIFIER), oldPosition.y, oldPosition.z + (conveyor.SpeedZ * SPEED_MODIFIER));
                //otherRigidbody.WakeUp();
                otherRigidbody.AddForce(new Vector3(conveyor.SpeedX * SPEED_MODIFIER, 0, conveyor.SpeedZ * SPEED_MODIFIER), ForceMode.VelocityChange);
            }
        }
    }
}
