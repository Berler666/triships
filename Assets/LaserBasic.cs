using UnityEngine;
using System.Collections;

public class LaserBasic : MonoBehaviour {

    float tnumber = 1;
    public GameObject Laserhit;


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
        

        if (!obj && enemy.tag != "laser")
        {
            Debug.Log("missed");
            Destroy(gameObject);
        }

        if (obj && enemy.GetComponent<Unit>().teamNumber != tnumber)
        {
            Debug.Log("hit");
            obj.health -= LogicWarrior.damage;

            GameObject shipboom = Instantiate(Laserhit, transform.position, Quaternion.Euler(0, 180, 0)) as GameObject;
            Destroy(gameObject);
        }

        if(obj && enemy.GetComponent<Unit>().teamNumber == tnumber)
        {
            Debug.Log("Friendly fire");
            Physics.IgnoreCollision(GetComponent<Collider>(), obj.GetComponent<Collider>());
        }
       

        
        

    }

}
