using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableHealthXp : MonoBehaviour {
	public Unit unit;
	public GameObject healthBarD, XpBarD;

    bool mouseover = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (unit.selected) {
			healthBarD.SetActive (true);
			XpBarD.SetActive (true);
		} else if (!unit.selected) {
			healthBarD.SetActive (false);
			XpBarD.SetActive (false);
		}

        if(mouseover == true)
        {
            healthBarD.SetActive(true);
            XpBarD.SetActive(true);
        }
		
	}

    private void OnMouseOver()
    {
        mouseover = true;
    }

    private void OnMouseExit()
    {
        mouseover = false;
    }
}
