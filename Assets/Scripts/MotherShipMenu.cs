using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MotherShipMenu : MonoBehaviour {

    public GameObject msMenu;
   
    public GameObject VHScamera;

    public GameObject soPanel;
    public GameObject UPanel;
    public GameObject RPanel;
    public GameObject MPanel;

    public GameObject healthText;
    public GameObject powerText;
    public GameObject ammoText;
    public GameObject scrapText;
    public GameObject unitsText;

    
    GameObject mothership;
    float health;
    float maxHealth;

	// Use this for initialization
	void Start () {

        mothership = GameObject.Find("PlayerMothership");
        if (!mothership)
            Debug.Log("Can not find player mothership");
        

        soPanel.SetActive(true);
        UPanel.SetActive(false);
        RPanel.SetActive(false);
        MPanel.SetActive(false);
	
	}
	
	
	void Update ()
    {
        health = mothership.GetComponent<Unit>().health;
        maxHealth = mothership.GetComponent<Unit>().maxHealth;

        healthText.GetComponent<Text>().text = (health + "/" + maxHealth);
        powerText.GetComponent<Text>().text = (mothership.GetComponent<playerMotherShip>().power + "/" + mothership.GetComponent<playerMotherShip>().maxPower);
        ammoText.GetComponent<Text>().text = (mothership.GetComponent<playerMotherShip>().ammo + "/" + mothership.GetComponent<playerMotherShip>().maxAmmo);
        scrapText.GetComponent<Text>().text = (mothership.GetComponent<playerMotherShip>().scrap + "/" + mothership.GetComponent<playerMotherShip>().maxScrap);
        unitsText.GetComponent<Text>().text = (mothership.GetComponent<playerMotherShip>().units + "/" + mothership.GetComponent<playerMotherShip>().maxUnits);

    }

    public void BackButton()
    {
        Time.timeScale = 1;
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
