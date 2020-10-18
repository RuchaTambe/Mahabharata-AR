using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScreenDisplay : MonoBehaviour
{
    public Text display;
    private string s;
    // Start is called before the first frame update
    void Start()
    {
        
        display=GetComponent<Text>();

        s="Hello"; 
    }

    // Update is called once per frame
    void Update()
    {
        display=GetComponent<Text>();
        s=s+"In update";
        display.text=s;

    }
}
