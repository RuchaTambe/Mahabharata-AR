using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class core : MonoBehaviour
{
    private int times=0;
    public static core instance;
    private spawner spawn = spawner.instance;
    public AudioSource mp3;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public int get_score()
    {
        return times;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeshoot()
    {
        times++;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //spawner.instance.test();
        mp3.Play();
        Destroy(gameObject);
        spawn.spawn_target();
        //instantiate a new 
       
    }
}
