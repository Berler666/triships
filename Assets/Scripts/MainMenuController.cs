using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenuController : MonoBehaviour {

    public GameObject campaignMenu;
    public GameObject singleplayerMenu;
    public GameObject settingsMenu;
    public GameObject SaveSlots;


    // Use this for initialization
    private void Awake()
    {
        gameObject.GetComponent<AudioSource>().Play(0);
    }
    void Start () {
        campaignMenu.SetActive(false);
        singleplayerMenu.SetActive(false);
        settingsMenu.SetActive(false);
        SaveSlots.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenCampaignMenu()
    {
        campaignMenu.SetActive(true);
        singleplayerMenu.SetActive(false);
        settingsMenu.SetActive(false);
        SaveSlots.SetActive(false);
    }

    public void NewGame()
    {
        SaveSlots.SetActive(true);
    }

    public void Load()
    {
        SaveSlots.SetActive(true);
    }

    public void OpenSingleplayerMenu()
    {
        campaignMenu.SetActive(false);
        singleplayerMenu.SetActive(true);
        settingsMenu.SetActive(false);
        SaveSlots.SetActive(false);
    }

    public void OpenSettingsMenu()
    {
        campaignMenu.SetActive(false);
        singleplayerMenu.SetActive(false);
        settingsMenu.SetActive(true);
        SaveSlots.SetActive(false);
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
