using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerResearch : MonoBehaviour {

    public bool isResearhing;
    string timeDis;
    public string researchPublic;
    public float timePublic;
    public string descriptionPublic;
    playerMotherShip mothership;
    public GameObject researchList;
    public GameObject reserchbutton;

    Color32 myBlue = new Color32(0, 230, 254, 255);
    Color32 myGren = new Color32(0, 255, 0, 255);


    //Research Bools
    bool x1Hp1 = false;
    bool x1Atk1 = false;
    bool msTurrent1 = false;
    bool junkShip = false;
    bool powerStorage1 = false;
    bool x1SpawnTime1 = false;


    //Research things
    public GameObject junkshipBtn;
    public Text junkshipTime;
    bool showjunkshipTime = false;

    public GameObject powerstorage1Btn;
    public Text ps1Time;

    public GameObject x1hpIBtn;
    Text x1hp1Time;
    bool showx1hp1Time = false;

    public GameObject x1atkBtn;
    Text x1atk1Time;
    bool showx1atk1Time = false;

    public GameObject msTurrent1Btn;
    Text msturrent1Time;
    bool showmsTurrent1Time = false;

    public GameObject x1Spawnupgrade1Btn;
    Text x1spawn1Time;
    bool showx1spawn1Time = false;

  

    

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
       

        if(showjunkshipTime == true)
        {
            junkshipTime.text = timeDis;
        }

        if(showx1hp1Time == true)
        {
            x1hp1Time.text = timeDis;
        }

        if(showx1atk1Time == true)
        {
            x1atk1Time.text = timeDis;
        }

        if(showmsTurrent1Time == true)
        {
            msturrent1Time.text = timeDis;
        }

        if (showx1spawn1Time == true)
        {
            x1spawn1Time.text = timeDis;
        }


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



    public IEnumerator X1HpUpgrade1()
    {


        isResearhing = true;
        showx1hp1Time = true;
        x1hpIBtn.GetComponent<Image>().color = myGren;
        Text[] x1hptxts = x1hpIBtn.GetComponentsInChildren<Text>();
       
        foreach (Text text in x1hptxts)
            text.color = myGren;

        yield return new WaitForSecondsRealtime(timePublic);
        x1Hp1 = true;
        isResearhing = false;
        showx1hp1Time = false;
        Destroy(x1hpIBtn);
        Debug.Log("X1 Health Upgrade researched");



    }

    public void ResearchX1Hp1()
    {
        x1hp1Time = x1hpIBtn.transform.Find("Time").GetComponent<Text>();

        if (mothership.power >= 10 && isResearhing == false)
        {
            mothership.power -= 10;
           
            StartCoroutine(Research("X1 HP Upgrade", 30, "+5 health to the X1"));
            StartCoroutine(X1HpUpgrade1());

        }
        else
        {
            Debug.Log("not enough resources");
        }


    }

    public IEnumerator X1AtkUpgrade1()
    {


        isResearhing = true;
        showx1atk1Time = true;
        x1atkBtn.GetComponent<Image>().color = myGren;
        Text[] x1atk1txts = x1atkBtn.GetComponentsInChildren<Text>();

        foreach (Text text in x1atk1txts)
            text.color = myGren;

        yield return new WaitForSecondsRealtime(timePublic);
        x1Atk1 = true;
        isResearhing = false;
        showx1atk1Time = false;
        Destroy(x1atkBtn);
        Debug.Log("X1 Attack Upgrade researched");



    }

    public void ResearchX1Atk1()
    {
        x1atk1Time = x1atkBtn.transform.Find("Time").GetComponent<Text>();

        if (mothership.power >= 12 && isResearhing == false)
        {
            mothership.power -= 12;

            StartCoroutine(Research("X1 Attack Upgrade", 30, "+1 attack to the X1"));
            StartCoroutine(X1AtkUpgrade1());

        }
        else
        {
            Debug.Log("not enough resources");
        }


    }

    public IEnumerator MsTurentUpgrade1()
    {


        isResearhing = true;
        showmsTurrent1Time = true;
        msTurrent1Btn.GetComponent<Image>().color = myGren;
        Text[] msTurrent1texts = msTurrent1Btn.GetComponentsInChildren<Text>();

        foreach (Text text in msTurrent1texts)
            text.color = myGren;

        yield return new WaitForSecondsRealtime(timePublic);
        msTurrent1 = true;
        isResearhing = false;
        showmsTurrent1Time = false;
        Destroy(msTurrent1Btn);
        Debug.Log("Mothership Turrent Upgrade researched");



    }

    public void ResearchMsTurrent1()
    {
        msturrent1Time = msTurrent1Btn.transform.Find("Time").GetComponent<Text>();

        if (mothership.power >= 10 && isResearhing == false)
        {
            mothership.power -= 10;

            StartCoroutine(Research("Mothership Turrent Upgrade 1", 25, "Allows you to build a turrent on the mothership"));
            StartCoroutine(MsTurentUpgrade1());

        }
        else
        {
            Debug.Log("not enough resources");
        }


    }

    public IEnumerator x1SpawnTimeUpgrade1()
    {


        isResearhing = true;
        showx1spawn1Time = true;
        x1Spawnupgrade1Btn.GetComponent<Image>().color = myGren;
        Text[] x1spawn1Texts = x1Spawnupgrade1Btn.GetComponentsInChildren<Text>();

        foreach (Text text in x1spawn1Texts)
            text.color = myGren;

        yield return new WaitForSecondsRealtime(timePublic);
        x1SpawnTime1 = true;
        isResearhing = false;
        showx1spawn1Time = false;
        Destroy(x1Spawnupgrade1Btn);
        Debug.Log("x1 Spawn time Upgrade researched");



    }

    public void ResearchX1SpawnTime1()
    {
        x1spawn1Time = x1Spawnupgrade1Btn.transform.Find("Time").GetComponent<Text>();

        if (mothership.power >= 15 && isResearhing == false)
        {
            mothership.power -= 15;

            StartCoroutine(Research("X1 Spawn Time Upgrade", 30, "-1 second to spawn time"));
            StartCoroutine(x1SpawnTimeUpgrade1());

        }
        else
        {
            Debug.Log("not enough resources");
        }


    }

    public IEnumerator JunkShip()
    {

      
            isResearhing = true;
        showjunkshipTime = true;
            junkshipBtn.GetComponent<Image>().color = myGren;
            Text[] jkbTxt = junkshipBtn.GetComponentsInChildren<Text>();
            
            foreach (Text text in jkbTxt)
                text.color = myGren;

            yield return new WaitForSecondsRealtime(timePublic);
            junkShip = true;
            isResearhing = false;
        showjunkshipTime = false;
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
