using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
[RequireComponent(typeof(ARRaycastManager))]
//[RequireComponent(typeof(ARReferencePointManager))]
//[RequireComponent(typeof(ARPointCloudManager))]
public class RandomFloorPlacementController : MonoBehaviour
{
    public float radius = 5.0F;
    public float power = 10.0F;
    private ARRaycastManager arRaycastManager;
    Ray ray;
     RaycastHit hit;
    private ARPlaneManager arPlaneManager;
    public GameObject cubePrefab;
    private bool gameStarted;
    static List<ARRaycastHit> hits=new List<ARRaycastHit>();
    private List<Vector3> pointsToPlaceLetters=new List<Vector3>();
  private LineRenderer lineBoundaryForPlane;
    private Pose hitPose;
    public int NUM_OF_OBJECTS=5;
    private ARPlane plane;
   public GameObject display;
    private float dimX;
    private float dimY;
    private int count=0;
   public string answer;
    private bool flag=false;
    private Text temp;
    private string expectedAnswer;
    private TrackableId planeid;
    int index=0;
    public GameObject[] spawntest;
   public AudioSource sound;
    private List<GameObject> listObjects=new List<GameObject>();
    
    private List<GameObject> listObjectsToRespawn;
public static HashSet<string> myhash1 = new HashSet<string>(); 
   public List<string> words=new List<string>();

    private bool objectsPlaced=false;
 //  ARPointCloudManager pointCloudManager;

   // ARReferencePointManager aRReferencePointManager;
    void Awake()
    {
        arRaycastManager=GetComponent<ARRaycastManager>();
        arPlaneManager=GetComponent<ARPlaneManager>();
        sound=GetComponent<AudioSource>();


    }
    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.touchCount>0)
        {
            touchPosition=Input.GetTouch(0).position;
            return true;
        }
        touchPosition=default;
        return false;
    }
    // Start is called before the first frame update
    void Start()
    {
        listObjectsToRespawn=new List<GameObject>();
        expectedAnswer="FOCUS";
        answer=" ";
        count=0;
         display.GetComponent<Text>().text="Welcome! Scan a plane area till you see a red border around the plane ,and then begin the game";
    }
    
    public bool validateArea(){
         Debug.Log(">>>>AREA "+plane.size.x*plane.size.y);

        if(plane.size.x*plane.size.y>5){
            Debug.Log(plane.trackableId);
            planeid=plane.trackableId;
            plane.tag="MainPlane";
           lineBoundaryForPlane=plane.GetComponent<LineRenderer>();
            plane.tag="Plane";

            lineBoundaryForPlane.SetWidth(0.05f,0.05f);
           // Debug.Log("CHANGING THICKNESS OF PLANE to 0.1f ");
            lineBoundaryForPlane.SetColors(new Color(1,0,0,0.5f),new Color(1,0,0,0.5f));
             temp=display.GetComponent<Text>();
             temp.text = "You are set!! \n Move around, tap on the screen to see alphabets and collect them to \n Answer this question "+
                          "What is the most important principle that you learnt from the archery game?"+"\n"+" Your answer:";

          //  Debug.Log("CHANGING COLOR OF PLANE to white ");
            
            return true;
        }
        return false;
    }
     private void canStartGame(){
         gameStarted = validateArea();
     }
    // Update is called once per frame
    void Update()
    {
        if(!TryGetTouchPosition(out Vector2 touchPosition))
        {
        return;
        }      
    
    if(gameStarted && !flag){
      
        count=0; //allow respawning after incorrect answer
          arPlaneManager.enabled=false;
            foreach(ARPlane plane in arPlaneManager.trackables){
             
                Debug.Log("PLANE  coordinates "+plane.transform.position.x+" "+plane.transform.position.y+" "+plane.transform.position.z);
                if(plane.trackableId==planeid)
                {
                   
                     flag=true;
                     Debug.Log("Respawning objects... "+spawntest.Length);
      
                     while(count<spawntest.Length){
                         Debug.Log("ENTERING into loop...");
                            index=count;
                            GameObject spawnNew=spawntest[index];
                            spawnNew=Instantiate(spawnNew, new Vector3(plane.transform.position.x+Random.Range(-dimX/2, dimX/2),plane.transform.position.y+0.4f+spawnNew.transform.localScale.x,plane.transform.position.z+Random.Range(-dimY/2,dimY/2)), Quaternion.identity);
                            spawnNew.AddComponent<Rigidbody>();

                            Debug.Log("spannew"+spawnNew.transform.position.x+" "+spawnNew.transform.position.y+" "+spawnNew.transform.position.z);
                      
                        spawnNew.SetActive(false);
                        
                            listObjects.Add(spawnNew);
                      
                            count++;
                    }
                }
                else{
  //plane.gameObject.SetActive(false);
  //plane.SetTrackablesActive(false);
                }
                
              
            }

          
         
            if(flag)
            {

                touchobjects();
            }
   

            }

        else if(!gameStarted && arRaycastManager.Raycast(touchPosition,hits,UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon) && Input.touchCount>0 )
        {
            temp=display.GetComponent<Text>();
        temp.text="Try to scan more area";

            
      
           
                plane=arPlaneManager.GetPlane(hits[0].trackableId); //we are taking one plane from hits.. is this plane the largest
                
                dimX=plane.size.x;
                dimY=plane.size.y; //subject to change depending on whether horiz plane  is x-z or x-y
                Debug.Log(">>> PLANE dimX "+dimX+" "+dimY);
                hitPose=hits[0].pose;
                canStartGame();
               
                
         }
         else if(flag)
         {
            touchobjects();
         }
         

       //  Debug.Log("Gamestarted "+gameStarted);
        
             
       }

     

        public Transform SpawnInside(GameObject spawnObject){
            
            Vector3 randpos = Vector3.zero;
            randpos.x = Random.Range(-dimX/2f, dimX/2f); //assume mesh of the plane is centered, view mesh.bounds.min.x and mesh.bounds.max.x if not centered
           //Debug.Log("ramdom pos x"+randpos.x);
          
            randpos.y = Random.Range(-dimY/2f, dimY/2f); //"level" hoy much up to the plane spawn the objects
           //   Debug.Log("random pos y "+randpos.x);
            randpos.z = 0f; //Random.Range(-dimY/2f, dimY/2f);
            Transform instance = Instantiate (spawnObject, this.transform).transform;
            instance.position=randpos;
           // instance.SetActive(false);
            return instance;
             //instance.SetActive(false);
            //store in a list
     }
     public void touchobjects()
     {
        
       foreach( GameObject obj in listObjects){
        //    Debug.Log("in touch objects");
        //     Debug.Log("properties of objects"+obj);
            float dist=Vector3.Distance(Camera.main.transform.position, obj.transform.position);
                if(dist<1.8f){
                    
                    obj.SetActive(true);
           }  
       }
  
         RaycastHit hit;
         Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
 
         if (Physics.Raycast(ray, out hit) && hit.collider!=null && hit.collider.gameObject.tag!="Plane" )
         {
 Vector3 explosionPos = hit.collider.gameObject.transform.position;
            temp.text=temp.text+hit.collider.gameObject.tag;
            Rigidbody rb = hit.collider.gameObject.GetComponent<Rigidbody>();
            Debug.Log("rb"+rb);

            if (rb != null)
            {
                 Debug.Log("in rb");
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
            }
        
            sound.Play();
            hit.collider.gameObject.SetActive(false);
             listObjects.Remove(hit.collider.gameObject);
             listObjectsToRespawn.Add(hit.collider.gameObject);
             Debug.Log("temp.text" +temp.text);
             string userAnswer=temp.text.Split(':')[1];
             Debug.Log("USER ANSWER "+userAnswer);
            if(userAnswer.Length==expectedAnswer.Length && userAnswer==expectedAnswer){

                temp=display.GetComponent<Text>();
                temp.text="Correct answer!";
                
        }
        else if(userAnswer.Length>=expectedAnswer.Length && temp.text!=expectedAnswer ){
                temp=display.GetComponent<Text>();
                temp.text="Try again! Alphabets are being respawned:";
               // temp.text=" ";
                flag=false;
        }
        
        
        } 
       
     }

                
   
}