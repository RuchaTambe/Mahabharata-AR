using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class SquareScript : MonoBehaviour {
     public float dimX;
     public float dimY;
     public GameObject[] spawntest;
     private GameObject spawnNew;
     static List<GameObject> spawnedobjects=new List<GameObject>();
    static int itest = 0;
    int index;
     void Start () {
         Mesh _mesh = transform.GetComponent<MeshFilter> ().mesh;
         dimX = _mesh.bounds.size.x;
         dimY = _mesh.bounds.size.y;//I assume here that the square is on x and z, otherwise replace for the correct plane axis
     }
 
     //to test purpose, attach to default plane and set a gameobject on spawntest variable
     void Update(){
         if (itest < 10){
            index = Random.Range (0, spawntest.Length);
         spawnNew = spawntest[index];
           
              SpawnInside (spawnNew);
             spawnedobjects.Add(spawnNew);
             //  Debug.Log(spawnNew.transform.position);
              spawnNew.SetActive(false);
             itest++;
         }
           foreach (GameObject a in spawnedobjects)
           {
               Debug.Log("the position of the spawned object"+a.transform.position);
               Debug.Log("the camera position is"+Camera.main.transform.position);
               Debug.Log(Vector3.Distance(a.transform.position, Camera.main.transform.position));
               if(Vector3.Distance(a.transform.position, Camera.main.transform.position) < 1.0f) 
           {
               a.SetActive(true);
           }
           }
        
         /* if(Vector3.Distance(spawnNew.transform.position, Camera.main.transform.position) < 1.0f) //set this to whatever suits best
              {
                  posProgress++;
              }*/
        /* if(Input.GetMouseButtonDown(0))
         {
             Debug.Log
             ("on touch");
             RaycastHit hit;
             Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
             if(Physics.Raycast(ray, out hit))
             {
                 Debug.Log
             ("in raycasthit");
                 BoxCollider bc=hit.collider as BoxCollider;
                 if(bc!=null)
                 {
                      Debug.Log
             ("in collider");
                     Destroy(bc.gameObject);
                 } 
             }
         }*/
     }
 
     public void SpawnInside(GameObject spawnObject){
         Vector3 randpos = Vector3.zero;
         randpos.x = Random.Range(-dimX/2f, dimX/2f);//assume mesh of the plane is centered, view mesh.bounds.min.x and mesh.bounds.max.x if not centered
         randpos.z = 0f;//"level" hoy much up to the plane spawn the objects
         randpos.y = Random.Range(-dimY/2f, dimY/2f);
         Transform instance = Instantiate (spawnObject, this.transform).transform;
         instance.localPosition = randpos;
     }
 }
