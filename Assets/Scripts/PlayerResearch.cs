using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerResearch : MonoBehaviour {

#region Vars
	public int rotation_X=0;
    public bool isResearhing;
    string timeDis;
    public string researchPublic;
    public float timePublic;
    public string descriptionPublic;
    playerMotherShip mothership;
    public GameObject researchList;
    public GameObject upgradesList;
    public GameObject reserchbutton;
	public GameObject _turrentUp, motherShip;
	public Transform parentTurrent;

    Color32 myBlue = new Color32(0, 230, 254, 255);
    Color32 myGren = new Color32(0, 255, 0, 255);


    //Research Bools
    bool x1Hp1 = false;
    bool x1Atk1 = false;
   
    bool junkShip = false;
    bool powerStorage1 = false;
    bool x1SpawnTime1 = false;


    [Header(" Mothership Research bools")]
    bool MothershipHP1 = false;
    bool msTurrent1 = false;
    bool ResearchCenter = false;
    bool AsteroidShields = false;
    public static bool WorkerUnitHp1 = false;
    public static bool WorkerUnitAtck1 = false;

    //Research Buttons
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

    

    public GameObject x1Spawnupgrade1Btn;
    Text x1spawn1Time;
    bool showx1spawn1Time = false;

  [Header("Mothership Research Buttons")]

    public GameObject mothershipHP1UpgradeBtn;
    Text mothershipHp1Time;
    bool showMothershipHp1Time = false;

    public GameObject msTurrent1Btn;
    public GameObject msUpgradeTurrent1Btn;
    Text msturrent1Time;
    bool showmsTurrent1Time = false;

    public GameObject ResearchCenterUpgradeBtn;
    public GameObject ResearchCenterButton;
    Text researchCenterTime;
    bool showResearchCenterTime = false;
	public GameObject turrentMouseFollow;

    public GameObject AsteroidShieldsUpgradeBtn;
    Text AsteroidShieldsTime;
    bool ShowAsteroidShieldsTime = false;

    public GameObject StevieModelEHp1Btn;
    Text workerHp1Time;
    bool showWorkerHp1Time = false;

    public GameObject StevieModelEAtk1Btn;
    Text workerAtk1Time;
    bool showWorkerAtk1Time = false;


    #endregion

    #region Funky funcs
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

        //Mothership Research Time Display
        if (showMothershipHp1Time == true)
        {
            mothershipHp1Time.text = timeDis;
        }

        if (showmsTurrent1Time == true)
        {
            msturrent1Time.text = timeDis;
        }

        if (showResearchCenterTime == true)
        {
            researchCenterTime.text = timeDis;
        }

        if (ShowAsteroidShieldsTime == true)
        {
            AsteroidShieldsTime.text = timeDis;
        }

        if (showWorkerHp1Time == true)
        {
            workerHp1Time.text = timeDis;
        }

        if (showWorkerAtk1Time == true)
        {
            workerAtk1Time.text = timeDis;
        }






        if (showjunkshipTime == true)
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
    #endregion

#region MotherShip Research Button Functions

    //Mothership Hp1 Upgrade
    public IEnumerator MothershipHp1Upgrade()
    {


        isResearhing = true;
        showMothershipHp1Time = true;
        mothershipHP1UpgradeBtn.GetComponent<Image>().color = myGren;
        Text[] msHp1Txts = mothershipHP1UpgradeBtn.GetComponentsInChildren<Text>();

        foreach (Text text in msHp1Txts)
            text.color = myGren;

        yield return new WaitForSecondsRealtime(timePublic);
        MothershipHP1 = true;
        mothership.GetComponent<Unit>().maxHealth += 25;
        mothership.GetComponent<Unit>().health += 25;
        isResearhing = false;
        showMothershipHp1Time = false;
        Destroy(mothershipHP1UpgradeBtn);
        Debug.Log("Mothership Health Upgrade researched");



    }
    public void ResearchMothershipHp1()
    {
        mothershipHp1Time = mothershipHP1UpgradeBtn.transform.Find("Time").GetComponent<Text>();

        if (mothership.power >= 10 && isResearhing == false)
        {
            mothership.power -= 10;

            StartCoroutine(Research("Mothership Hp I", 30, "+25 health to the Mothership"));
             StartCoroutine(MothershipHp1Upgrade());

        }
        else
        {
            NotEoughResources.showNER = true;
        }


    }

    //MotherShip Turrent 1 Upgrade
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
        GameObject tRchBtn = Instantiate(msUpgradeTurrent1Btn);
        tRchBtn.transform.SetParent(upgradesList.transform, false);
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
			placingTurrent.ins.canPlaceTurrent = true;
			turrentMouseFollow.SetActive (true);
//			placeTurrentsOnMesh ();   // to be called for placing turrents on the mesh of the mothership...
            StartCoroutine(Research("Mothership Turrent Upgrade 1", 25, "Allows you to build a turrent on the mothership"));
            StartCoroutine(MsTurentUpgrade1());
		 

        }
        else
        {
            NotEoughResources.showNER = true;
        }


    }

//	public void placeTurrentsOnMesh( ){
//		GameObject newTurrent;
//		print (" place turrents is called");
//		newTurrent  = Instantiate (_turrentUp,mothership.transform.position,new Quaternion(_turrentUp.transform.rotation.x,_turrentUp.transform.rotation.y, _turrentUp.transform.rotation.z,_turrentUp.transform.rotation.w));
//		newTurrent.transform.SetParent (parentTurrent);
//		newTurrent.transform.localEulerAngles = new Vector3 (rotation_X,newTurrent.transform.localEulerAngles.y,newTurrent.transform.localEulerAngles.z);
//		rotation_X += 15;
//   		
//	}

    //Research Center Upgrade
    public IEnumerator ResearchCenterUpgrade()
    {


        isResearhing = true;
        showResearchCenterTime = true;
        ResearchCenterUpgradeBtn.GetComponent<Image>().color = myGren;
        Text[] ResearhCenterTxts = ResearchCenterUpgradeBtn.GetComponentsInChildren<Text>();

        foreach (Text text in ResearhCenterTxts)
            text.color = myGren;

        yield return new WaitForSecondsRealtime(timePublic);
        ResearchCenter = true;
        ResearchCenterButton.SetActive(true);
        isResearhing = false;
        showResearchCenterTime = false;
        Destroy(ResearchCenterUpgradeBtn);
        Debug.Log("Research Center Upgrade researched");



    }
    public void ResearchResearchCenter()
    {
        researchCenterTime = ResearchCenterUpgradeBtn.transform.Find("Time").GetComponent<Text>();

        if (mothership.power >= 10 && isResearhing == false)
        {
            mothership.power -= 10;

            StartCoroutine(Research("Research Center", 2, "Allows you to build the Research Center extension"));
            StartCoroutine(ResearchCenterUpgrade());

        }
        else
        {
            NotEoughResources.showNER = true;
        }


    }

    //Asteroid Shields Upgrade
    public IEnumerator AsteroidShieldsUpgrade()
    {


        isResearhing = true;
        ShowAsteroidShieldsTime = true;
        AsteroidShieldsUpgradeBtn.GetComponent<Image>().color = myGren;
        Text[] AsteroidShieldTxts = AsteroidShieldsUpgradeBtn.GetComponentsInChildren<Text>();

        foreach (Text text in AsteroidShieldTxts)
            text.color = myGren;

        yield return new WaitForSecondsRealtime(timePublic);
        AsteroidShields = true;
        isResearhing = false;
        ShowAsteroidShieldsTime = false;
        Destroy(AsteroidShieldsUpgradeBtn);
        Debug.Log("Asteroid Shields Upgrade researched");



    }

    public void ResearchAsteroidShields()
    {
        AsteroidShieldsTime = AsteroidShieldsUpgradeBtn.transform.Find("Time").GetComponent<Text>();

        if (mothership.power >= 10 && isResearhing == false)
        {
            mothership.power -= 10;

            StartCoroutine(Research("Asteroid Shields", 25, "Weak shields barly capable of protecting against goat size asteroids"));
            StartCoroutine(AsteroidShieldsUpgrade());

        }
        else
        {
            NotEoughResources.showNER = true;
        }


    }



    //Worker Hp 1 Upgrade
    public IEnumerator WorkerHp1Upgrade()
    {


        isResearhing = true;
        showWorkerHp1Time = true;
        StevieModelEHp1Btn.GetComponent<Image>().color = myGren;
        Text[] WorkerHp1Texts = StevieModelEHp1Btn.GetComponentsInChildren<Text>();

        foreach (Text text in WorkerHp1Texts)
            text.color = myGren;

        yield return new WaitForSecondsRealtime(timePublic);
        WorkerUnitHp1 = true;
        StevieModelE[] StevieEs = FindObjectsOfType(typeof(StevieModelE)) as StevieModelE[];

        foreach (StevieModelE ship in StevieEs)
        {
            ship.Upgrades();
        }
        isResearhing = false;
        showWorkerHp1Time = false;
        Destroy(StevieModelEHp1Btn);
        Debug.Log("Stevie Model e hp1 researched");



    }

    public void ResearchWorkerHp1()
    {
        workerHp1Time = StevieModelEHp1Btn.transform.Find("Time").GetComponent<Text>();

        if (mothership.power >= 10 && isResearhing == false)
        {
            mothership.power -= 10;

            StartCoroutine(Research("Stevie Modle E Hp I", 25, "+10 Hp to Stevie Model E Ships"));
            StartCoroutine(WorkerHp1Upgrade());

        }
        else
        {
            NotEoughResources.showNER = true;
        }


    }


    //Worker Atk 1 Upgrade
    public IEnumerator WorkerAtk1Upgrade()
    {


        isResearhing = true;
        showWorkerAtk1Time = true;
        StevieModelEAtk1Btn.GetComponent<Image>().color = myGren;
        Text[] WorkerAtk1Texts = StevieModelEAtk1Btn.GetComponentsInChildren<Text>();

        foreach (Text text in WorkerAtk1Texts)
            text.color = myGren;

        yield return new WaitForSecondsRealtime(timePublic);
        WorkerUnitAtck1 = true;
        StevieModelE[] StevieEs = FindObjectsOfType(typeof(StevieModelE)) as StevieModelE[];

        foreach (StevieModelE ship in StevieEs)
        {
            ship.Upgrades();
        }
        isResearhing = false;
        showWorkerAtk1Time = false;
        Destroy(StevieModelEAtk1Btn);
        Debug.Log("Stevie Model e Atk1 researched");



    }

    public void ResearchWorkerAtk1()
    {
        workerAtk1Time = StevieModelEAtk1Btn.transform.Find("Time").GetComponent<Text>();

        if (mothership.power >= 10 && isResearhing == false)
        {
            mothership.power -= 10;

            StartCoroutine(Research("Stevie Modle E Atk I", 25, "+5 Atk to Stevie Model E Ships"));
            StartCoroutine(WorkerAtk1Upgrade());

        }
        else
        {
            NotEoughResources.showNER = true;
        }


    }



    #endregion

    #region Other Buttons


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
            NotEoughResources.showNER = true;
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
            NotEoughResources.showNER = true;
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
            NotEoughResources.showNER = true;
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
            NotEoughResources.showNER = true;
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
            NotEoughResources.showNER = true;
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

#endregion
