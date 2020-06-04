using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyPlayerMovement1 : MonoBehaviour
{
    public GameObject directionObject;
    public Rigidbody targetRigidbody;
    public float speed = 1000.0f;
    public float maxSpeed = 15.0f;
    public float maxVelocity = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (targetRigidbody == null) {
            targetRigidbody = GetComponent<Rigidbody>();
        }

        if (directionObject == null) {
            directionObject = gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        targetRigidbody.AddForce(directionObject.transform.right * moveHorizontal * speed * Time.deltaTime);

        float moveVertical = Input.GetAxis("Vertical");
        // targetRigidbody.AddForce(directionObject.transform.forward * moveVertical * speed * Time.deltaTime);
        targetRigidbody.AddForce(directionObject.transform.forward * moveVertical * speed * Time.deltaTime);

        // UpdateMaxSpeed();
    }

    void UpdateMaxSpeed()
    {
        // Based on https://answers.unity.com/questions/9985/limiting-rigidbody-velocity.html

        if (maxSpeed != 0.0f) {
            // ##### Method 1
            // float speed = Vector3.Magnitude(targetRigidbody.velocity);  // test current object speed
            // if (speed > maxSpeed) {
            //     float brakeSpeed = speed - maxSpeed;  // calculate the speed decrease
            //     Vector3 brakeVelocity = targetRigidbody.velocity.normalized * brakeSpeed;  // make the brake Vector3 value
            //     targetRigidbody.AddForce(-brakeVelocity);  // apply opposing brake force
            // }
            // ##### Method 1

            // ##### Method 2
            // if (targetRigidbody.velocity.sqrMagnitude > maxVelocity)
            // {
            //     //smoothness of the slowdown is controlled by the 0.99f, 
            //     //0.5f is less smooth, 0.9999f is more smooth
            //     targetRigidbody.velocity *= 0.99f;
            // }
            // ##### Method 2
        }
    }
}
