using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turrentFollow : MonoBehaviour {
 	  
	void Update () {
		
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);		
		transform.position = ray.GetPoint (1);
 	}

	 
}
