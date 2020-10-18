using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouch : MonoBehaviour
{
    public GameObject[] go;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount >0) 
     {
         RaycastHit hit;
         Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
         if (Physics.Raycast(ray, out hit))
             
         {
             Destroy(hit.collider.gameObject,0.2f);
             //cubes.rigidbody.AddForce(Vector3.forward * Time.deltaTime *500);
             
         }        
     }
    }
}
