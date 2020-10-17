using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Shooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject shootbutton;
    public float projectileSpeed;
    public float shootRate;
    private float lastShootTime;
    private int status = 0;
    public GameObject end_canvas;
    public TextMeshProUGUI show_result;
    public AudioSource mp3;


    private Camera cam;
    private int times = 0;
    public static Shooting instance;
    void Awake () { instance = this; }
    public void setStatus(int i)
    {
        status = i;
    }
    void Start ()
    {
        cam = Camera.main;
        end_canvas.SetActive(false);
        shootbutton.SetActive(false);
        
    }

    void Update ()
    {
        
        
    }
    public void end_of_game() {
        status = 2;
        int score = projectal.instance.getNumberOfCollisions();//core.instance.get_score();
        show_result.text = "score is "+score + "\n out of "+times+"\n game over";
        end_canvas.SetActive(true);

    }
    public void restart()
    {
        status = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // shoots a new projectile out from the camera
    public void Shoot ()
    {
        if (times >= 10)
        {
            shootbutton.SetActive(false);
            end_of_game();
            return;
        }
        if (Time.time - lastShootTime >= shootRate)
        {
            GameObject proj = Instantiate(projectilePrefab, cam.transform.position, cam.transform.rotation);
            proj.GetComponent<Rigidbody>().velocity = cam.transform.forward * projectileSpeed;
            lastShootTime = Time.time;
            times++;
            mp3.Play();
        }
        if (times == 10)
        {
            shootbutton.GetComponentInChildren<TextMeshProUGUI>().text="end game";
        }
        

    }
    public void pointdown()
    {
       
        //if (cam.orthographic)
        //{
        //    // ... change the orthographic size based on the change in distance between the touches.
        //    cam.orthographicSize += 0.5f;

        //    // Make sure the orthographic size never drops below zero.
        //    cam.orthographicSize = Mathf.Max(cam.orthographicSize, 0.1f);
        //}
        
            // Otherwise change the field of view based on the change in distance between the touches.
           // cam.fieldOfView = 0.1f;

            // Clamp the field of view to make sure it's between 0 and 180.
            //cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, 0.1f, 179.9f);
        
    }

    // called when the "Place Core" button is pressed
    // places down the core and begins the game
   
}