using UnityEngine;
using System.Collections;

public class MotherShipMenu : MonoBehaviour {

    public GameObject msMenu;
   

    public GameObject VHScamera;

    public GameObject soPanel;
    public GameObject UPanel;
    public GameObject RPanel;
    public GameObject MPanel;

	// Use this for initialization
	void Start () {

        soPanel.SetActive(true);
        UPanel.SetActive(false);
        RPanel.SetActive(false);
        MPanel.SetActive(false);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void BackButton()
    {
        Time.timeScale = 1;
        msMenu.SetActive(false);
        VHScamera.SetActive(false);
      
    }

    public void ShipOverview()
    {
        soPanel.SetActive(true);
        UPanel.SetActive(false);
        RPanel.SetActive(false);
        MPanel.SetActive(false);
    }

    public void Upgrades()
    {

        soPanel.SetActive(false);
        UPanel.SetActive(true);
        RPanel.SetActive(false);
        MPanel.SetActive(false);
    }

    public void Research()
    {

        soPanel.SetActive(false);
        UPanel.SetActive(false);
        RPanel.SetActive(true);
        MPanel.SetActive(false);
    }

    public void Map()
    {

        soPanel.SetActive(false);
        UPanel.SetActive(false);
        RPanel.SetActive(false);
        MPanel.SetActive(true);
    }
}
