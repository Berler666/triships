using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerResearch : MonoBehaviour {

    public bool isResearhing;

    bool junkShip = false;
    bool powerStorage1 = false;

    Color32 myBlue = new Color32(0, 230, 254, 255);
    Color32 myGren = new Color32(0, 255, 0, 255);
   

    public string researchPublic;
    public float timePublic;
    public string descriptionPublic;

    playerMotherShip mothership;

    public GameObject researchList;

    public GameObject reserchbutton;

    public GameObject junkshipBtn;
    public Text junkshipTime;

    public GameObject powerstorage1Btn;
    public Text ps1Time;

    string timeDis;

    

    // Use this for initialization
    void Start () {

        

        isResearhing = false;

        mothership = GameObject.Find("PlayerMothership").GetComponent<playerMotherShip>();


    }
	
	// Update is called once per frame
	void Update () {

        if (isResearhing == true)
        {
            timePublic -= Time.unscaledDeltaTime;
        }else 
        {
            timePublic = 0;
        }

        if (timePublic == 0 || timePublic <= 0)
        {
            timePublic = 0;
           
          
        }


       timeDis = string.Format("{0:00}:{1:00}:{2:00}", (int)timePublic / 3600, (int)timePublic / 60, (int)timePublic % 60);


      

    }

    public IEnumerator Research(string research, int time, string description)
    {
       
        Debug.Log(research + time + description);
        researchPublic = research;
        timePublic = time;
        descriptionPublic = description;
        yield return new WaitForSecondsRealtime(time);
        research = "";
        time = 0;
        description = "";
    }

    public IEnumerator JunkShip()
    {

      
            isResearhing = true;
            junkshipBtn.GetComponent<Image>().color = myGren;
            Text[] jkbTxt = junkshipBtn.GetComponentsInChildren<Text>();
            
            foreach (Text text in jkbTxt)
                text.color = myGren;

            yield return new WaitForSecondsRealtime(timePublic);
            junkShip = true;
            isResearhing = false;
            Destroy(junkshipBtn);
            Debug.Log("junkship researched");
           

      
    }

    public void ResearchJunkShip()
    {

    if (mothership.power >= 10 && mothership.Biosium >= 15 && isResearhing == false)
    {

        StartCoroutine(Research("Junk Ship", 20, "Junk ships collect Power, Ammo and Biosium from defeated enemies"));
        StartCoroutine(JunkShip());

        }
        else
        {
            Debug.Log("not enough resources");
        }


    }

    public IEnumerator PowerStorage1()
    {

        if (mothership.power >= 10 && mothership.Biosium >= 15)
        {
            isResearhing = true;
            powerstorage1Btn.GetComponent<Image>().color = myGren;
            Text[] psbTxt = powerstorage1Btn.GetComponentsInChildren<Text>();

            foreach (Text text in psbTxt)
                text.color = myGren;

            yield return new WaitForSecondsRealtime(timePublic);
            powerStorage1 = true;
            isResearhing = false;
            Debug.Log("Power Upgrade Complete");

        }
        else
        {
            Debug.Log("not enough resources");
        }


    }

    public void ResearchPowerStorage1()
    {

        StartCoroutine(Research("Power Storage +", 90, "Max Power +20"));
        StartCoroutine(PowerStorage1());
    }

    public void AddBtn(GameObject btn)
    {
        Instantiate(btn);
        btn.transform.SetParent(researchList.transform, false);

    }
}
