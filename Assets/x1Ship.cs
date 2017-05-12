using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class x1Ship : MonoBehaviour {

    public int experince;
    int maxXp;

    int level;
    int evolveLevel = 0;

    public Text shipLevel;

    public GameObject EvolveEffect;

    public GameObject shipModel;

    public GameObject shipV1;


	// Use this for initialization
	void Start () {

        level = 0;
        experince = 0;
        maxXp = 50;

        shipLevel.GetComponent<Text>();
	
	}
	
	// Update is called once per frame
	void Update () {

        if (experince >= maxXp)
        {
            Levelup();
        }

        shipLevel.text = ("LEVEL " + level);

    }

    void Levelup()
    {
        level += 1;
        experince = 0;
        Debug.Log("Level " + level + "!");

        if (level == 1)
            maxXp = 75;

        if (level == 2)
            maxXp = 150;

        if (level == 3)
            maxXp = 300;

        if (level == 4)
            maxXp = 450;

        if (level == 5)
            maxXp = 600;

        if (level == 6)
            maxXp = 750;

        if (level == 7)
            maxXp = 900;

        if (level == 8)
            maxXp = 1050;

        if (level == 9)
            maxXp = 1200;

        if (level == 10)
        {
            maxXp = 1350;
            Evolve();
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
}
