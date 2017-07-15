using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerResearchLab : MonoBehaviour {

    bool isPlayer;
   

    playerMotherShip Mothership;

	// Use this for initialization
	void Start () {

        if (gameObject.GetComponent<Unit>().teamNumber != 1)
        {
            isPlayer = false;
        }
        else
        {
            isPlayer = true;
            Mothership = GameObject.Find("PlayerMothership").GetComponent<playerMotherShip>();
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

  
}
