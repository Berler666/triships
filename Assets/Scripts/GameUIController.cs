using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIController : MonoBehaviour {

    bool isZoomed = true;
    bool menuOpen = false;

    GameObject cameraControl;
    public GameObject GameMenu;

	// Use this for initialization
	void Start () {

       cameraControl = GameObject.Find("Main Camera");
        GameMenu.SetActive(false);
        Time.timeScale = 1;
        
	
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown("escape"))
        {
            if(menuOpen == false)
            {
                OpenGameMenu();
            }else
            {
                CloseGameMenu();
            }
        }
	
	}

    public void OpenGameMenu()
    {
        GameMenu.SetActive(true);
        menuOpen = true;
        Time.timeScale = 0;
    }

    public void CloseGameMenu()
    {
        GameMenu.SetActive(false);
        menuOpen = false;
        Time.timeScale = 1;
    }

    public void QuitCurrentGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void CloseGame()
    {
        Time.timeScale = 1;
        Application.Quit();
    }

    public void Focus(Transform target)
    {
        ISRTSCamera.JumpToTargetForMain(target);
    }
}
