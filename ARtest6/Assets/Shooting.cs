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
    private GameObject projone;
 
    private Camera cam;
    private int scores = 0;
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
        show_result.text = "score is "+scores + "\n out of "+times+"\n game over";
        end_canvas.SetActive(true);

    }
    public void restart()
    {
        status = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // shoots a new projectile out from the camera
   
    
    public void get_score() {
        scores++;
    }

    public void button_down()
    {
        if (times == 10)
        {
            return;
        }
        Vector3 v3 = cam.transform.position;
        projone = Instantiate(projectilePrefab, v3 + new Vector3(0.15f, 0, 0), cam.transform.rotation);
        projone.GetComponent<projectal>().staying();
        
    }
    public void button_up() {
        
        if (times >= 10)
        {
            shootbutton.SetActive(false);
            end_of_game();
            return;
        }
        times++;
        mp3.Play();
        Vector3 v3 = cam.transform.position;
        Vector3 v3_copy = new Vector3(v3[0]+0.15f, v3[1], v3[2]);
        projone.GetComponent<projectal>().shooting();
        projone.GetComponent<Rigidbody>().velocity = cam.transform.forward * projectileSpeed;
        if (times == 10)
        {
            shootbutton.GetComponentInChildren<TextMeshProUGUI>().text = "end game";
        }
    }

   
   
}