using UnityEngine;
using System.Collections;

public class Treasure : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider ship)
    {
        if(ship.GetComponent<Unit>())
        {

            if(ship.GetComponent<Unit>().teamNumber == 1)
            {
                GameObject.Find("PlayerMothership").GetComponent<playerMotherShip>().RP += Random.Range(1, 5);
                GameObject.Find("PlayerMothership").GetComponent<playerMotherShip>().Biosium += Random.Range(1, 5);
                Debug.Log("tresure");
                Destroy(gameObject);

            }
            
        }
        
    }
}
