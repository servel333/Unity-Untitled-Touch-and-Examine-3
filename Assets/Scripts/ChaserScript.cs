using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserScript : MonoBehaviour
{

    public GameObject target;
    //public float maxRange = 10.0f;
    public float minDistance = 3.0f;
    public Rigidbody targetRigidbody;
    public float speed = 1000.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (targetRigidbody == null)
        {
            targetRigidbody = GetComponent<Rigidbody>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 heading = target.transform.position - gameObject.transform.position;
        float distance = heading.magnitude;
        Vector3 direction = heading / distance; // This is now the normalized direction.

        // targetRigidbody.AddForce(direction * (distance) * Time.deltaTime);

        if (distance > minDistance)
        {
            targetRigidbody.velocity = direction * (distance / 10);
        }

        // if (heading.sqrMagnitude < maxRange * maxRange)
        // {
        //     // Target is within range.
        // }

        // float distance = Vector3.Distance(target.transform.position, gameObject.transform.position);

    }
}
