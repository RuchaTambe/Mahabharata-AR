using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectal : MonoBehaviour
{
    public static projectal instance;

    private int times=0;
    void Awake(){
        instance=this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getNumberOfCollisions(){
        return times;
    }
    private void OnTriggerEnter(Collider other)
    {
        //spawner.instance.test();
       core tar = other.GetComponent<core>();
        if (tar != null)
        {

            //tar.takeshoot();

            times++;
            Debug.Log("Collision detected " +times);

            Destroy(gameObject);
        }
    }
}
