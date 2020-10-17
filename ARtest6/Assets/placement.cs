using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class placement : MonoBehaviour
{
    private ARRaycastManager rayman;
    private GameObject visual;
    // Start is called before the first frame update
    void Start()
    {
        rayman = FindObjectOfType<ARRaycastManager>();
        visual = transform.GetChild(0).gameObject;
        visual.SetActive(false);
        Debug.Log("lalal1");
        print("TEST");

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("lalal2");
        print("TEST");
        List<ARRaycastHit> list = new List<ARRaycastHit>();
        rayman.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), list, TrackableType.Planes);
        if (list.Count > 0) {
            transform.position = list[0].pose.position;
            transform.rotation = list[0].pose.rotation;
            if (!visual.activeInHierarchy)
            {
                visual.SetActive(true);
            }
        }

    }
}
