using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject tospawn;
    private Camera cam;
    public GameObject placebutton;
    public GameObject shootbutton;
    public static spawner instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //placementt = FindObjectOfType<placement>();
        cam = Camera.main;

    }

    
    //Update is called once per frame
    void Update()
    {
        
    }
    public void spawn_target()
    {
        shootbutton.SetActive(true);
        Vector3 v3 = cam.transform.position + cam.transform.forward * 3f;
         v3[0] += Random.Range(-1f,1f);
         v3[1] += Random.Range(-1f, 0f);
         v3[2] += Random.Range(-1f, 1f);
        Instantiate(tospawn, v3, cam.transform.rotation);
        placebutton.SetActive(false);
        Shooting.instance.setStatus(1);
    }
    
}
