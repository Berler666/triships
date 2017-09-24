using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StevieModelE : MonoBehaviour
{

    public int experince;
    int maxXp;


    int level;
    int evolveLevel = 0;

    public Text shipLevel;

    public GameObject EvolveEffect;
    public GameObject LevelUpEffect;
    public GameObject shipModel;

    public GameObject shipV1;

    public Image xpBar;

    Unit unit;
    LogicWarrior logicWar;


    // Use this for initialization
    void Start()
    {

        unit = GetComponent<Unit>();
        logicWar = GetComponent<LogicWarrior>();

        level = 0;
        experince = 0;
        maxXp = 50;

        shipLevel.GetComponent<Text>();

        Upgrades();

    }

    // Update is called once per frame
    void Update()
    {

        if (experince >= maxXp)
        {
            Levelup();
        }

        shipLevel.text = (" LVL: " + level);

        xpBar.fillAmount = Map(experince, 0, maxXp, 0, 1);

       

    }

    public void Upgrades()
    {
        if (PlayerResearch.WorkerUnitHp1 == true)
        {
            unit.maxHealth += 10;
            unit.health = unit.maxHealth;

        }

        if (PlayerResearch.WorkerUnitAtck1 == true)
        {
            logicWar.Wdamage += 5;

        }
    }

    void Levelup()
    {
        level += 1;
        experince = 0;
        GameObject Lvlparticle = Instantiate(LevelUpEffect, transform.position, transform.rotation) as GameObject;
        Lvlparticle.transform.parent = gameObject.transform;
        Debug.Log("Level " + level + "!");

        if (level == 1)
        {
            maxXp = 75;
            logicWar.Wdamage += Random.Range(1, 10);
            unit.maxHealth += Random.Range(1, 10);
            unit.health = unit.maxHealth;
            Debug.Log("Level up! damage:" + GetComponent<LogicWarrior>().Wdamage);
        }



        if (level == 2)
        {
            maxXp = 100;
            logicWar.Wdamage += Random.Range(1, 10);
            unit.maxHealth += Random.Range(1, 10);
            unit.health = unit.maxHealth;
            Debug.Log("Level up! damage:" + GetComponent<LogicWarrior>().Wdamage);
        }


        if (level == 3)
        {
            maxXp = 150;
            logicWar.Wdamage += Random.Range(1, 10);
            unit.maxHealth += Random.Range(1, 10);
            unit.health = unit.maxHealth;
            Debug.Log("Level up! damage:" + GetComponent<LogicWarrior>().Wdamage);
        }


        if (level == 4)
        {
            maxXp = 220;
            logicWar.Wdamage += Random.Range(1, 10);
            unit.maxHealth += Random.Range(1, 10);
            unit.health = unit.maxHealth;
            Debug.Log("Level up! damage:" + GetComponent<LogicWarrior>().Wdamage);
        }


        if (level == 5)
        {
            maxXp = 300;
            logicWar.Wdamage += Random.Range(1, 10);
            unit.maxHealth += Random.Range(1, 10);
            unit.health = unit.maxHealth;
            Debug.Log("Level up! damage:" + GetComponent<LogicWarrior>().Wdamage);
        }

        if (level == 6)
        {
            maxXp = 380;
            logicWar.Wdamage += Random.Range(1, 10);
            unit.maxHealth += Random.Range(1, 10);
            unit.health = unit.maxHealth;
            Debug.Log("Level up! damage:" + GetComponent<LogicWarrior>().Wdamage);
        }

        if (level == 7)
        {
            maxXp = 460;
            logicWar.Wdamage += Random.Range(1, 10);
            unit.maxHealth += Random.Range(1, 10);
            unit.health = unit.maxHealth;
            Debug.Log("Level up! damage:" + GetComponent<LogicWarrior>().Wdamage);
        }

        if (level == 8)
        {
            maxXp = 550;
            logicWar.Wdamage += Random.Range(1, 10);
            unit.maxHealth += Random.Range(1, 10);
            unit.health = unit.maxHealth;
            Debug.Log("Level up! damage:" + GetComponent<LogicWarrior>().Wdamage);
        }

        if (level == 9)
        {
            maxXp = 650;
            logicWar.Wdamage += Random.Range(1, 10);
            unit.maxHealth += Random.Range(1, 10);
            unit.health = unit.maxHealth;
            Debug.Log("Level up! damage:" + GetComponent<LogicWarrior>().Wdamage);
        }

        if (level == 10)
        {
            maxXp = 750;
            Evolve();
            logicWar.Wdamage += Random.Range(1, 20);
            unit.maxHealth += Random.Range(1, 20);
            unit.health = unit.maxHealth;
            Debug.Log("Level up! damage:" + GetComponent<LogicWarrior>().Wdamage);
        }

        if (level == 11)
        {
            maxXp = 750;
            logicWar.Wdamage += Random.Range(1, 10);
            unit.maxHealth += Random.Range(1, 10);
            unit.health = unit.maxHealth;
            Debug.Log("Level up! damage:" + GetComponent<LogicWarrior>().Wdamage);
        }

        if (level == 12)
        {
            maxXp = 650;
            logicWar.Wdamage += Random.Range(1, 10);
            unit.maxHealth += Random.Range(1, 10);
            unit.health = unit.maxHealth;
            Debug.Log("Level up! damage:" + GetComponent<LogicWarrior>().Wdamage);
        }

        if (level == 13)
        {
            maxXp = 650;
            logicWar.Wdamage += Random.Range(1, 10);
            unit.maxHealth += Random.Range(1, 10);
            unit.health = unit.maxHealth;
            Debug.Log("Level up! damage:" + GetComponent<LogicWarrior>().Wdamage);
        }

        if (level == 14)
        {
            maxXp = 650;
            logicWar.Wdamage += Random.Range(1, 10);
            unit.maxHealth += Random.Range(1, 10);
            unit.health = unit.maxHealth;
            Debug.Log("Level up! damage:" + GetComponent<LogicWarrior>().Wdamage);
        }

        if (level == 15)
        {
            maxXp = 650;
            logicWar.Wdamage += Random.Range(1, 10);
            unit.maxHealth += Random.Range(1, 10);
            unit.health = unit.maxHealth;
            Debug.Log("Level up! damage:" + GetComponent<LogicWarrior>().Wdamage);
        }



    }

    void Evolve()
    {
        GameObject particle = Instantiate(EvolveEffect, transform.position, transform.rotation) as GameObject;
        particle.transform.parent = gameObject.transform;
        evolveLevel += 1;
        Debug.Log("Evolving");

        if (evolveLevel == 1)
        {
            shipModel.SetActive(false);
            shipV1.SetActive(true);
        }

    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}