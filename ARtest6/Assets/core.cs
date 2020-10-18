using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class core : MonoBehaviour
{
    
   
    private spawner spawn = spawner.instance;
    public AudioSource mp3;
   
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
        
        mp3.Play();
        Destroy(gameObject);
        Shooting.instance.get_score();
        spawn.spawn_target();
        //instantiate a new 
       
    }
}
