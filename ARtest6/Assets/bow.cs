using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bow : MonoBehaviour
{
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v3= cam.transform.position;
        transform.position = v3+ cam.transform.forward * 0.6f;
        transform.rotation = cam.transform.rotation;

    }
}
