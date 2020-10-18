using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bow : MonoBehaviour
{
    private Camera cam;
    private int status = 1;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
         Vector3 v3 = cam.transform.position;
        // transform.position = v3+ cam.transform.forward * 0.6f;
        // transform.rotation = cam.transform.rotation;
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Screen touched ");
            status = 0;
        }
        if (Input.GetMouseButtonUp(0))
        {
            status = 1;
        }
        if (status==0){
            
            transform.position = v3+ cam.transform.forward * 0.3f;
            transform.rotation = cam.transform.rotation;
        }
        else
        {
            transform.position = v3 + cam.transform.forward * 0.6f;
            transform.rotation = cam.transform.rotation;
        }

    }
}
