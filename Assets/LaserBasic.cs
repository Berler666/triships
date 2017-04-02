using UnityEngine;
using System.Collections;

public class LaserBasic : MonoBehaviour {

   

	// Use this for initialization
	void Start () {

        Destroy(gameObject, 3);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider enemy)
    {
       
           
        Unit obj = enemy.gameObject.GetComponent<Unit>();

        if(!obj && enemy.tag != "laser")
        {
            Debug.Log("missed");
            Destroy(gameObject);
        }

         if(obj)
        {
            Debug.Log("hit");
            obj.health -= LogicWarrior.damage;
            Destroy(gameObject);
        }
        

    }

}
