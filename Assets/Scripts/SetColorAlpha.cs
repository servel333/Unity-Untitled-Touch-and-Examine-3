using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColorAlpha : MonoBehaviour
{
    public float alpha = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        var material = GetComponent<Renderer>().material;
        Color color = material.color;
        color.a = alpha;
        material.color = color;
        // GetComponent<MeshRenderer>().material.color.a = alpha;
        // GetComponent<Renderer>().material.color.a = alpha;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
