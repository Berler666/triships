using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour {

    bool isZoomed = true;

    GameObject cameraControl;

	// Use this for initialization
	void Start () {

       cameraControl = GameObject.Find("Main Camera");
       
        
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Zoom()
    {
        if(isZoomed == false)
        {
            
            
        }
    }
}
