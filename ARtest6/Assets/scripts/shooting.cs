using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject projectile;
    public float speed;
    public float rate;
    private float lasttime;
    public static shooting instance;
    private Camera cam;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) {
            if (Time.time - lasttime >= rate)
            {
                Shoot();
            }
        }

    }
    void Shoot()
    {
        lasttime = Time.time;
        GameObject pro = Instantiate(projectile, cam.transform.position, Quaternion.identity);
        pro.GetComponent<Rigidbody>().velocity = cam.transform.forward * speed;

    }
}
