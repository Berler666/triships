using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Skirmish : MonoBehaviour {

    public Dropdown mapDropdown;
    public string[] maps;

	// Use this for initialization
	void Start () {
      

        foreach (string scene in maps )
        {
            mapDropdown.options.Add(new Dropdown.OptionData(scene.ToString()));
        }
		
	}

  
	
	// Update is called once per frame
	void Update () {
		
	}
}
