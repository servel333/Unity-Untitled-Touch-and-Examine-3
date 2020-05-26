using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchAndExamineTarget : MonoBehaviour
{

    public float TouchDistance = 6.0f;
    public Camera PlayerCamera;
    private Renderer PreviousRenderer;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCamera == null) {
            PlayerCamera = Camera.main;
        }

        Ray ray = PlayerCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0)); // Point at center of view
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.distance < TouchDistance) {
            Renderer renderer = hit.collider.gameObject.GetComponent<Renderer>();

            if (renderer != PreviousRenderer) {
                Deselect(PreviousRenderer);
                Select(renderer);
                PreviousRenderer = renderer;
            }
        }
        else if (PreviousRenderer != null) {
            Deselect(PreviousRenderer);
            PreviousRenderer = null;
        }
    }

    void Select(Renderer target) {
        if (target != null) {
            target.material.color = Color.yellow
        }
    }

    void Deselect(Renderer target) {
        if (target != null) {
            target.material.color = Color.white
        }
    }

}
