using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //spawner.instance.test();
        core tar = other.GetComponent<core>();
        if (tar != null)
        {
            tar.takeshoot();

            Destroy(gameObject);
        }
    }
}
