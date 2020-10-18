using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectal : MonoBehaviour
{
    
    private Camera cam;
    
    private int status = 0;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }
    public void shooting()
    {
        status = 0;
    }
    public void staying()
    {
        status = 1;
    }
    // Update is called once per frame
    void Update()
    {
        if (status == 1)
        {
            transform.position = cam.transform.position+new Vector3(0.15f,0,0);
            transform.rotation = cam.transform.rotation;
        }
    }
    
   
    private void OnTriggerEnter(Collider other)
    {
        
       core tar = other.GetComponent<core>();
        if (tar != null)
        {
            
            Destroy(gameObject);
        }
    }
}
