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
	{  try{
         if (obj.transform.name == GotoObject.transform.name && noship == false)
        {

                x1Ship ship = obj.gameObject.GetComponent<x1Ship>();

                if(ship)
                {
                    obj.GetComponent<x1Ship>().experince += xpValue;
                  
                }
               

                if(!ship)
                {
                    StevieModelE shipStevie = obj.gameObject.GetComponent<StevieModelE>();

                    if(shipStevie)
                    {
                        obj.GetComponent<StevieModelE>().experince += xpValue;
                    }
                }

           
         
            Destroy(gameObject);
            
			}
		}
		catch{}
       
        
    }


  
}
