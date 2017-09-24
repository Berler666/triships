using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placingTurrent : MonoBehaviour {
	public static placingTurrent ins;
  	RaycastHit hit;
	Vector3 sphereMousePoint;
	public bool canPlaceTurrent;
	public GameObject _turrentUp, motherShip, turrentMouseFollow  ;
	public Transform parentTurrent;
	public LayerMask layer;
	public Material turrentPlacerMat;
	public bool canFlashMothership=false;
 	// Use this for initialization
	void Awake () {
		ins = this;
 	}
	
	// Update is called once per frame
	void FixedUpdate () {
  		if (canPlaceTurrent) {
 			Ray rayPlacerChecker = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast (rayPlacerChecker, out hit, 500, layer)) {
				if (hit.collider.name == "Mother Ship Collider Turrentz") {
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
				if (Physics.Raycast (ray, out hit,150,layer)) {
					if (hit.collider.name == "Mother Ship Collider Turrentz" ) {
 						sphereMousePoint = new Vector3 (hit.point.x, hit.point.y, hit.point.z);
						placeTurrentsOnMesh (sphereMousePoint, hit.point);
					}
				}
			}
		}
  	}

	public void placeTurrentsOnMesh( Vector3 sphereMousePoint , Vector3 dir){
		GameObject newTurrent;
  		Quaternion lookat= new Quaternion(dir.x,dir.y,dir.z,0);
		newTurrent = Instantiate (_turrentUp,motherShip.transform.position,/* new Quaternion (_turrentUp.transform.rotation.x, _turrentUp.transform.rotation.y, _turrentUp.transform.rotation.z, _turrentUp.transform.rotation.w)*/Quaternion.identity);
 		newTurrent.transform.SetParent ( parentTurrent);
		turrentMouseFollow.SetActive (false);
		newTurrent.transform.LookAt (dir);
 		canPlaceTurrent = false;
		canFlashMothership = false;
		turrentPlacerMat.color = Color.red;
  	}
}
