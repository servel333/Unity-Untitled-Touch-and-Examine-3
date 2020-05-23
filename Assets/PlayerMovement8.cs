using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement8 : MonoBehaviour
{
    private Vector3 moveDirection = Vector3.zero;
    public float JumpSpeed = 10.0F;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHighlightedObjectUnderView();
        UpdateFlightControls();
        UpdateLookMovement();
        UpdateWorkdMovement();

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
        //         // moveDirection.y = JumpSpeed;
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

    }

#region Gravity

    public float Gravity = 9.8f;
    private float velocity = 0;

    void UpdateGravity() {

    }

#endregion

#region World Movement

    private CharacterController characterController;
    public float MovementSpeed = 3;

    void UpdateWorkdMovement() {

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

#region Highlight target object

    private Renderer CurrentRenderer;
    public float TouchDistance = 6.0f;

    void UpdateHighlightedObjectUnderView()
    {

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0)); // Point at center of view
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.distance < TouchDistance) {
            Renderer renderer = hit.collider.gameObject.GetComponent<Renderer>();

            if (renderer != CurrentRenderer) {
                if (CurrentRenderer != null) {
                    CurrentRenderer.material.color = Color.white;
                }
                renderer.material.color = Color.yellow;
                CurrentRenderer = renderer;
            }
        }
        else if (CurrentRenderer != null) {
            CurrentRenderer.material.color = Color.white;
            CurrentRenderer = null;
        }

    }

#endregion

}
