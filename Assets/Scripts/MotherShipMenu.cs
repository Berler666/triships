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
    public GameObject ResearchOverDisplay;

    public Text rpTxt;

    public Image healthBar;
    public Image powerBar;
    public Image ammoBar;
    public Image scrapBar;
    public Image unitsBar;

    public Text researchTxt;
    public Text timeToResearchTxt;
    public Text researchDescriptionTxt;
    
    private playerMotherShip mothership;
    PlayerResearch playerController;
    float health;
    float maxHealth;

	// Use this for initialization
	void Start () {

        mothership = GameObject.Find("PlayerMothership").GetComponent<playerMotherShip>();
        if (!mothership)
            Debug.Log("Can not find player mothership");

        playerController = GameObject.Find("PlayerController").GetComponent<PlayerResearch>();
        if (!mothership)
            Debug.Log("Can not find PlayerController");


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
        scrapText.GetComponent<Text>().text = (mothership.Biosium + "/" + mothership.maxBiosium);
        unitsText.GetComponent<Text>().text = (mothership.units + "/" + mothership.maxUnits);

        rpTxt.text = "Research Points: " + mothership.RP.ToString();

        healthBar.fillAmount = Map(health,0,maxHealth,0,1);
        powerBar.fillAmount = Map(mothership.power, 0, mothership.maxPower, 0, 1);
        ammoBar.fillAmount = Map(mothership.ammo, 0, mothership.maxAmmo, 0, 1);
        scrapBar.fillAmount = Map(mothership.Biosium, 0, mothership.maxBiosium, 0, 1);
        unitsBar.fillAmount = Map(mothership.units, 0, mothership.maxUnits, 0, 1);

        string timedisplay = string.Format("{0:00}:{1:00}:{2:00}", (int)playerController.timePublic / 3600, (int)playerController.timePublic / 60, (int)playerController.timePublic % 60);

        researchTxt.GetComponent<Text>().text = playerController.researchPublic;
        timeToResearchTxt.GetComponent<Text>().text = "Completed in: " + timedisplay;
        researchDescriptionTxt.GetComponent<Text>().text = playerController.descriptionPublic;

        if(playerController.isResearhing == true)
        {
            ResearchOverDisplay.SetActive(true);
        } 
        else
        {
            ResearchOverDisplay.SetActive(false);
        }
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }

    public void BackButton()
    {
        Time.timeScale = 1;
        VHScamera.SetActive(false);
        mothership.UI.SetActive(true);
        mothership.MainCamera.GetComponent<ISRTSCamera>().enabled = true;
        mothership.MainCamera.GetComponent<ISRTSCamera>().Start();


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
