using UnityEngine;
using System.Collections;

public class xpOrb : MonoBehaviour {

    int xpValue;
    public float speed;
    bool noship = false;

    public GameObject GotoObject;

	// Use this for initialization
	void Start () {

        xpValue = Random.Range(5, 40);
	
	}

     void Update()
    {
        float step = speed * Time.deltaTime;
       

        if(!GotoObject)
        {
           
            Destroy(gameObject);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, GotoObject.transform.position, step);
        }

        
    }


    void OnTriggerEnter(Collider obj)
    {





        if (obj.transform.name == GotoObject.transform.name && noship == false)
        {
            x1Ship ship = obj.gameObject.GetComponent<x1Ship>();
          
            obj.GetComponent<x1Ship>().experince += xpValue;
            Debug.Log("xp gathered");
            Destroy(gameObject);
            
        }
       
        
    }


  
}
