using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement8 : MonoBehaviour
{
    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // UpdateFlightControls();
        UpdateLookMovement();
        UpdateWorldMovement();
        // UpdateGravityPlayerMomentum();
        // UpdateZeroGravityPlayerMovement();

        // if (Input.GetKeyDown(KeyCode.Escape)) { // True only once on transition to pressed
        //     Debug.Log("Input.GetKeyDOWN(KeyCode.Escape)");
        // }

        // if (Input.GetKeyDown("escape")) { // True only once on transition to pressed
        //     Debug.Log("Input.GetKeyDOWN(\"escape\")");
        // }

        // if (Input.GetKey("escape")) { // True every frame the key is pressed
        //     Debug.Log("Input.GetKey(\"escape\")");
        // }

        // if (characterController.isGrounded)
        // {
        //     if (Input.GetButton("Jump"))
        //     {
        //         characterController.Move(new Vector3(0, JumpSpeed * Time.deltaTime, 0));
        //         // PlayerMomentum.y = JumpSpeed;
        //     }
        // }

        // if (!characterController.isGrounded)
        // {
        //     Debug.Log("!characterController.isGrounded");
        //     velocity -= Gravity * Time.deltaTime;
        //     characterController.Move(new Vector3(0, velocity, 0));
        // }

        // PlayerMomentum.y -= gravity * Time.deltaTime;

        // characterController.transform.rotation

    }

#region Player Momentum, Gravity, Jumping

    public float Gravity = 9.8f;
    // private float velocity = 0;
    public float JumpSpeed = 10.0F;
    private Vector3 PlayerMomentum = Vector3.zero;

    void UpdateGravityPlayerMomentum() {
        if (characterController.isGrounded) {
            // PlayerMomentum.y = 0;

            if (Input.GetButton("Jump")) {
                PlayerMomentum.y += JumpSpeed;
            }
        }
        else {
            PlayerMomentum.y -= Gravity * Time.deltaTime;
        }

        characterController.Move(PlayerMomentum * Time.deltaTime);
    }

#endregion

#region Zero-gravity player Momentum

    private Vector3 SpacePlayerMomentum = Vector3.zero;
    private float JetpackSpeed = 5.0f;

    void UpdateZeroGravityPlayerMovement() {

        if (Input.GetButton("Jump")) {
            SpacePlayerMomentum.y += JetpackSpeed * Time.deltaTime;
        }

        if (Input.GetButton("Crouch")) {
            SpacePlayerMomentum.y -= JetpackSpeed * Time.deltaTime;
        }

        float horizontal = Input.GetAxis("Horizontal") * JetpackSpeed;
        float vertical = Input.GetAxis("Vertical") * JetpackSpeed;
        SpacePlayerMomentum += ((Camera.main.transform.right * horizontal) + (Camera.main.transform.forward * vertical)) * Time.deltaTime;

        characterController.Move(SpacePlayerMomentum * Time.deltaTime);
    }

#endregion

#region World Movement

    private CharacterController characterController;
    public float MovementSpeed = 3;

    void UpdateWorldMovement() {

        float horizontal = Input.GetAxis("Horizontal") * MovementSpeed;
        float vertical = Input.GetAxis("Vertical") * MovementSpeed;
        characterController.Move((Camera.main.transform.right * horizontal + Camera.main.transform.forward * vertical) * Time.deltaTime);

    }

#endregion

#region Mouse Look Controls

    public float horizontalLookSpeed = 2f;
    public float verticalLookSpeed = 2f;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;

    void UpdateLookMovement() {

        float mouseX = Input.GetAxis("Mouse X") * horizontalLookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * verticalLookSpeed;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        characterController.transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);

    }

#endregion

#region Fly Controls

    void UpdateFlightControls() {

        if (Input.GetButton("Jump")) {
            // Debug.Log("Input.GetButton(\"Jump\")");
            characterController.Move(new Vector3(0, 10.0f * Time.deltaTime, 0));
        }

        if (Input.GetButton("Crouch")) {
            // Debug.Log("Input.GetButton(\"Jump\")");
            characterController.Move(new Vector3(0, -10.0f * Time.deltaTime, 0));
        }

    }

#endregion

}
