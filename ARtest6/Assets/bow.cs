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
   
        if (status==0){
            
            transform.position = v3+ cam.transform.forward * 0.3f+new Vector3(0.05f,0,0);
            transform.rotation = cam.transform.rotation;
        }
        else
        {
            transform.position = v3 + cam.transform.forward * 0.6f+new Vector3(0.05f, 0, 0);
            transform.rotation = cam.transform.rotation;
        }

    }
    public void button_down()
    {
        status = 0;
    }
    public void button_up()
    {
        status = 1;
    }
}
