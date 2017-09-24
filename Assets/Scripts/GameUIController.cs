using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIController : MonoBehaviour {

    bool isZoomed = true;
    bool menuOpen = false;
     GameObject cameraControl;
    public GameObject GameMenu;
	  ParticleSystem particlesys;
	public GameObject _particles;
	// Use this for initialization
	void Start () {
		particlesys = _particles.GetComponent<ParticleSystem> ();
		particlesys.Stop ();
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

    public void OpenGameMenu() {
        GameMenu.SetActive(true);
           menuOpen = true;
        Time.timeScale = 0;
		particlesys.Play ();

    }

    public void CloseGameMenu()  {
        GameMenu.SetActive(false);
		particlesys.Stop ();
          menuOpen = false;
        Time.timeScale = 1;
    }

    public void QuitCurrentGame()
	{   particlesys.Stop ();
         Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void CloseGame()
    {
        Time.timeScale = 1;
		particlesys.Stop ();
         Application.Quit();
    }

    public void Focus(Transform target)
    {
        ISRTSCamera.JumpToTargetForMain(target);
    }
}
