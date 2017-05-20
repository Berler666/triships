using UnityEngine;
using System.Collections;

public class xpOrb : MonoBehaviour {

    int xpValue;

	// Use this for initialization
	void Start () {

        xpValue = Random.Range(5, 20);
	
	}
	

    void OnTriggerEnter(Collider obj)
    {

        x1Ship ship = obj.gameObject.GetComponent<x1Ship>();

        if(!ship)
        {
            Debug.Log("Not a ship");
        }

        if(ship)
        {
            obj.GetComponent<x1Ship>().experince += xpValue;
            Debug.Log("xp gathered");
            Destroy(gameObject);
        }
        
    }
}
