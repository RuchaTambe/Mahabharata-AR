using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class core : MonoBehaviour
{
    private int times=0;
    public static core instance;
    private spawner spawn = spawner.instance;
    public AudioSource mp3;
    private Vector3 scaleChange;
    private Vector3 originalPosition;
    bool flag;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        times=0;
        flag=false;
         scaleChange = new Vector3(0.1f, 0.1f,  0.1f);
         originalPosition=this.transform.position;
    }
    public int get_score()
    {
        return times;
    }
    // Update is called once per frame
    void Update()
    {
        if(!flag && Input.GetMouseButtonDown(0)){
            this.transform.localScale+=scaleChange;
            Debug.Log("new position "+this.transform.position);
            flag=true;
            
        }
        if(Input.GetMouseButtonUp(0)){
            this.transform.localScale-=scaleChange;
            this.transform.position=originalPosition;
            Debug.Log("Set to original position "+this.transform.position);
            flag=false;
        }
        
    }
    public void takeshoot()
    {
        times++;
        
    }
    private void OnTriggerEnter(Collider other)
    {   
        // Debug.Log("before Collision detected "+times);
        // times=times+1;
        // Debug.Log("Collision detected "+times);
        //spawner.instance.test();
        mp3.Play();
        Destroy(gameObject);
        spawn.spawn_target();
        //instantiate a new 
       
    }
}
