using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    public GameObject campaignMenu;
    public GameObject singleplayerMenu;
    public GameObject settingsMenu;

	// Use this for initialization
	void Start () {
        campaignMenu.SetActive(false);
        singleplayerMenu.SetActive(false);
        settingsMenu.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenCampaignMenu()
    {
        campaignMenu.SetActive(true);
        singleplayerMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }

    public void OpenSingleplayerMenu()
    {
        campaignMenu.SetActive(false);
        singleplayerMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void OpenSettingsMenu()
    {
        campaignMenu.SetActive(false);
        singleplayerMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void loadtest()
    {
        SceneManager.LoadScene("Scene");
    }

}
