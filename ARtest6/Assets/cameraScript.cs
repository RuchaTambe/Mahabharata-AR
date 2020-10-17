using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{

    public float cameraPositionDelta;
    private Vector3 fixedCameraPosition;
    private bool cameraIsMoved;
    // Start is called before the first frame update
    void Start()
    {
        cameraIsMoved=false;
        fixedCameraPosition=this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!cameraIsMoved && Input.GetMouseButtonDown(0)){
            this.transform.position+=this.transform.forward*cameraPositionDelta;
            Debug.Log("camera new pos "+this.transform.position);
            cameraIsMoved=true;
        }
        if(Input.GetMouseButtonUp(0)){
            this.transform.position=fixedCameraPosition;
            cameraIsMoved=false;
        }
    }
}
