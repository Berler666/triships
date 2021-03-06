﻿using UnityEngine;
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

    public Image healthBar;
    public Image powerBar;
    public Image ammoBar;
    public Image scrapBar;
    public Image unitsBar;


    
    private playerMotherShip mothership;
    float health;
    float maxHealth;

	// Use this for initialization
	void Start () {

        mothership = GameObject.Find("PlayerMothership").GetComponent<playerMotherShip>();
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
        powerText.GetComponent<Text>().text = (mothership.power + "/" + mothership.maxPower);
        ammoText.GetComponent<Text>().text = (mothership.ammo + "/" + mothership.maxAmmo);
        scrapText.GetComponent<Text>().text = (mothership.scrap + "/" + mothership.maxScrap);
        unitsText.GetComponent<Text>().text = (mothership.units + "/" + mothership.maxUnits);

        healthBar.fillAmount = Map(health,0,maxHealth,0,1);
        powerBar.fillAmount = Map(mothership.power, 0, mothership.maxPower, 0, 1);
        ammoBar.fillAmount = Map(mothership.ammo, 0, mothership.maxAmmo, 0, 1);
        scrapBar.fillAmount = Map(mothership.scrap, 0, mothership.maxScrap, 0, 1);
        unitsBar.fillAmount = Map(mothership.units, 0, mothership.maxUnits, 0, 1);
        

    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
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
