using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchAndExamineTarget : MonoBehaviour
{

    private Renderer CurrentRenderer;
    public float TouchDistance = 6.0f;
    public Camera PlayerCamera;

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
}
