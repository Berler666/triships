using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placingTurrent : MonoBehaviour {
	public static placingTurrent ins;
  	RaycastHit hit;
	Vector3 sphereMousePoint;
	public bool canPlaceTurrent;
	public GameObject turrentMothership, turrentBridge, turrentResearchLab, motherShip,turrentMouseFollow  ;
	public Transform parentTurrent;
	public LayerMask layer;
	public Material turrentPlacerMat;
	Vector3 reseachLabPosition;
	public Vector3 direction;
	public bool canFlashMothership=false;
	public string place;
  	// Use this for initialization
	void Awake () {
		ins = this;
 	}
	
	// Update is called once per frame
	void FixedUpdate () {
  		if (canPlaceTurrent) {
 			Ray rayPlacerChecker = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast (rayPlacerChecker, out hit, 500, layer)) {
				if (hit.collider.name == "Mother Ship Collider Turrentz" || hit.collider.tag== "ResearchLab" || hit.collider.tag=="Bridge") {
					print (hit.collider.name);
					turrentPlacerMat.color = Color.green;
					canFlashMothership = true;
				} else
					turrentPlacerMat.color = Color.red;
				
			} else {
				turrentPlacerMat.color = Color.red;
				canFlashMothership = false;
			}


			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Input.GetMouseButtonDown (1)) {
				if (Physics.Raycast (ray, out hit,150 ,layer)) {
 					if (hit.collider.name == "Mother Ship Collider Turrentz" ) {
 						place= "motherShip";
						placeTurrentsOnMesh (  hit.point, place, turrentMothership );
						direction = hit.normal;
					}
					else if (hit.collider.tag == "ResearchLab" ) {
 						place= "ResearchLab";
						reseachLabPosition = hit.collider.gameObject.transform.position;
						placeTurrentsOnMesh (  hit.point, place, turrentResearchLab );
						direction = hit.normal;
					}
					else if (hit.collider.tag == "Bridge" ) {
						place= "Bridge";
						placeTurrentsOnMesh (  hit.point, place, turrentBridge, hit.collider.transform  );
						direction = hit.normal;
					}

				}
			}
		}
  	}

	public void placeTurrentsOnMesh(Vector3 dir, string place, GameObject turrent, Transform colliderGameobject= null ){
		GameObject newTurrent;
		if (place == "motherShip") {
			newTurrent = Instantiate (turrent, motherShip.transform.position,Quaternion.identity);
			newTurrent.transform.SetParent ( parentTurrent);
			newTurrent.transform.LookAt (dir);
		}

		else if (place == "ResearchLab") {
			newTurrent = Instantiate (turrent, reseachLabPosition,Quaternion.identity);
			newTurrent.transform.SetParent ( parentTurrent);
			newTurrent.transform.LookAt (dir);
		}
		else if(place=="Bridge") {
			newTurrent = Instantiate (turrent, dir,Quaternion.identity);
			newTurrent.transform.SetParent (parentTurrent);
//			newTurrent.transform.eulerAngles = hit.collider.transform.eulerAngles;
			print(hit.collider.name);
            if (hit.collider.name == "Up")
            {
                newTurrent.transform.localEulerAngles = new Vector3(180, 360 + hit.transform.eulerAngles.y, 180);
            }
            else if (hit.collider.name == "Side 2")
            {
                newTurrent.transform.localEulerAngles = new Vector3(180, 360 + hit.transform.eulerAngles.y, 90);
            }
            else if (hit.collider.name == "Side 1")
            {
                newTurrent.transform.localEulerAngles = new Vector3(180, 360 + hit.transform.eulerAngles.y, 270);
            }
            else if (hit.collider.name == "Down")
            {
                newTurrent.transform.localEulerAngles = new Vector3(180, 360 + hit.transform.eulerAngles.y, 360);
            }
            //			newTurrent.transform.LookAt (normal);
        }

 		turrentMouseFollow.SetActive (false);
  		canPlaceTurrent = false;
		canFlashMothership = false;
		turrentPlacerMat.color = Color.red;
  	}
}
