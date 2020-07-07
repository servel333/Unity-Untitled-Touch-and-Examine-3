using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookAndMovement : MonoBehaviour
{

    public GameObject targetHead;
    public GameObject targetBody;
    public float horizontalLookSpeed = 2f;
    public float verticalLookSpeed = 2f;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;
    public float movementSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (targetHead == null)
        {
            targetHead = gameObject; //GetComponent<Rigidbody>();
        }

        if (targetBody == null)
        {
            targetBody = gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        yRotation += Input.GetAxis("Mouse X") * horizontalLookSpeed;
        xRotation -= Input.GetAxis("Mouse Y") * verticalLookSpeed;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        targetHead.transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        targetBody.GetComponent<Rigidbody>().velocity
            = (targetHead.transform.right * moveHorizontal * movementSpeed)
            + (targetHead.transform.forward * moveVertical * movementSpeed);

    }
}
