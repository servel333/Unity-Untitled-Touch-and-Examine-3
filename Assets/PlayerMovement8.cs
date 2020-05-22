using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement8 : MonoBehaviour
{
    private CharacterController characterController;
    public float MovementSpeed = 3;
    public float Gravity = 9.8f;
    public float jumpSpeed = 10.0F;
    // private float velocity = 0;
    private Vector3 moveDirection = Vector3.zero;
    public float horizontalLookSpeed = 1f;
    public float verticalLookSpeed = 1f;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        // if (Input.GetKeyDown(KeyCode.Escape)) { // True only once on transition to pressed
        //     Debug.Log("Input.GetKeyDOWN(KeyCode.Escape)");
        // }

        // if (Input.GetKeyDown("escape")) { // True only once on transition to pressed
        //     Debug.Log("Input.GetKeyDOWN(\"escape\")");
        // }

        // if (Input.GetKey("escape")) { // True every frame the key is pressed
        //     Debug.Log("Input.GetKey(\"escape\")");
        // }

        if (Input.GetButton("Jump")) {
            // Debug.Log("Input.GetButton(\"Jump\")");
            characterController.Move(new Vector3(0, jumpSpeed * Time.deltaTime, 0));
        }

        // if (characterController.isGrounded)
        // {
        //     if (Input.GetButton("Jump"))
        //     {
        //         characterController.Move(new Vector3(0, jumpSpeed * Time.deltaTime, 0));
        //         // moveDirection.y = jumpSpeed;
        //     }
        // }

        // if (!characterController.isGrounded)
        // {
        //     Debug.Log("!characterController.isGrounded");
        //     velocity -= Gravity * Time.deltaTime;
        //     characterController.Move(new Vector3(0, velocity, 0));
        // }

        // moveDirection.y -= gravity * Time.deltaTime;

        // characterController.transform.rotation

        float horizontal = Input.GetAxis("Horizontal") * MovementSpeed;
        float vertical = Input.GetAxis("Vertical") * MovementSpeed;
        characterController.Move((Vector3.right * horizontal + Vector3.forward * vertical) * Time.deltaTime);

#region Mouse Look Controls

        float mouseX = Input.GetAxis("Mouse X") * horizontalLookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * verticalLookSpeed;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        characterController.transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);

#endregion
    }
}
