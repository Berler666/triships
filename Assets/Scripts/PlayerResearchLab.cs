using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerResearchLab : MonoBehaviour {

    bool isPlayer;
    GameObject rcMenu;
    GameObject MainCamera;
    GameObject UI;
   


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
            rcMenu = GameObject.Find("Mothership UI Controller").GetComponent<MotherShipMenu>().rcMenu;
            MainCamera = GameObject.Find("Main Camera");
            UI = GameObject.Find("OnScreenButtons");
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        if (isPlayer == true)
        {

            rcMenu.SetActive(true);
            MainCamera.GetComponent<ISRTSCamera>().enabled = false;
            MainCamera.GetComponent<ISRTSCamera>().StopAllCoroutines();
            UI.SetActive(false);

        }
    }


}
