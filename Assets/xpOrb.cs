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
      

        Debug.Log("collided");

          Destroy(gameObject);
    
       
    }
}
