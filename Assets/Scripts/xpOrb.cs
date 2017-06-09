using UnityEngine;
using System.Collections;

public class xpOrb : MonoBehaviour {

    int xpValue;
    public float speed;

    public GameObject GotoObject;

	// Use this for initialization
	void Start () {

        xpValue = Random.Range(5, 20);
	
	}

     void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, GotoObject.transform.position, step);
    }


    void OnTriggerEnter(Collider obj)
    {

       
        
        

        if(obj == GotoObject)
        {
            x1Ship ship = obj.gameObject.GetComponent<x1Ship>();
            Debug.Log(obj.transform.name + GotoObject.transform.name);
            obj.GetComponent<x1Ship>().experince += xpValue;
            Debug.Log("xp gathered");
            Destroy(gameObject);
            
        }
        else
        {
           
        }
        
    }
}
