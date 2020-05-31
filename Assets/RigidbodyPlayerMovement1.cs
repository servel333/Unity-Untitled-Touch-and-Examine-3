using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyPlayerMovement1 : MonoBehaviour
{
    public GameObject directionObject;
    public Rigidbody targetRigidbody;
    public float speed = 10.0f;

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
        float moveVertical = Input.GetAxis("Vertical");

        // Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Vector3 movement = (directionObject.transform.right * moveHorizontal) + (directionObject.transform.forward * moveVertical);

        // characterController.Move((directionObject.transform.right * moveHorizontal + directionObject.transform.forward * moveVertical) * Time.deltaTime);
        targetRigidbody.AddForce(movement * speed * Time.deltaTime);
    }
}
