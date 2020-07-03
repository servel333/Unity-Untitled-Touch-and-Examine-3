using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchAndExamineTarget : MonoBehaviour
{

    public float TouchDistance = 6.0f;
    public Camera targetCamera;
    private GameObject SelectedGameObject;
    private Renderer PreviousRenderer;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (targetCamera == null) {
            targetCamera = Camera.main;
        }

        // if (SelectedGameObject == null) {
        //     if (Input.GetKeyDown("E")) {

        //     }
        //     else {
        //         HighlightObjectUnderCenterOfView();
        //     }
        // }

        Ray ray = targetCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0)); // Point at center of view
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.distance < TouchDistance) {
            Renderer renderer = hit.collider.gameObject.GetComponent<Renderer>();

            if (renderer != PreviousRenderer) {
                Unhighlight(PreviousRenderer);
                Highlight(renderer);
                PreviousRenderer = renderer;
            }
        }
        else if (PreviousRenderer != null) {
            Unhighlight(PreviousRenderer);
            PreviousRenderer = null;
        }

    }

    void Highlight(Renderer target) {
        if (target != null) {
            target.material.color = Color.yellow;
        }
    }

    void Unhighlight(Renderer target) {
        if (target != null) {
            target.material.color = Color.white;
        }
    }

}
