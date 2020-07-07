using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementWithVelocity : MonoBehaviour
{
    public GameObject directionObject;
    public Rigidbody targetRigidbody;
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (targetRigidbody == null)
        {
            targetRigidbody = GetComponent<Rigidbody>();
        }

        if (directionObject == null)
        {
            directionObject = gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        targetRigidbody.velocity
            = (directionObject.transform.right * moveHorizontal * speed)
            + (directionObject.transform.forward * moveVertical * speed);

        // targetRigidbody.AddForce(directionObject.transform.right * moveHorizontal * speed * Time.deltaTime);

        // targetRigidbody.AddForce(directionObject.transform.forward * moveVertical * speed * Time.deltaTime);
        // targetRigidbody.AddForce(directionObject.transform.forward * moveVertical * speed * Time.deltaTime);
    }
}
