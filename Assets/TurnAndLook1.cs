using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAndLook1 : MonoBehaviour
{
    public float horizontalLookSpeed = 2f;
    public float verticalLookSpeed = 2f;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
    	if (target == null) {
    		target = gameObject;
    	}
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * horizontalLookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * verticalLookSpeed;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        target.transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);
    }
}
