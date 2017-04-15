using UnityEngine;
using System.Collections;

public class MotherShipMenu : MonoBehaviour {

    public GameObject msMenu;

	// Use this for initialization
	void Start () {

       
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void BackButton()
    {
        Time.timeScale = 1;
        msMenu.SetActive(false);
    }
}
