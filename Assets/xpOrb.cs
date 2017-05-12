using UnityEngine;
using System.Collections;

public class xpOrb : MonoBehaviour {

    int xpValue;

	// Use this for initialization
	void Start () {

        xpValue = Random.Range(2, 10);
	
	}
	

    void OnTriggerEnter(Collider obj)
    {
        x1Ship ship = obj.GetComponent<x1Ship>();
       
        if(ship)
        {
            Debug.Log("found script");
        }

        if (!ship)
        {
            Debug.Log("collied");
        }
      

    
       
    }
}
