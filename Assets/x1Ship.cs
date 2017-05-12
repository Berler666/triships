using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class x1Ship : MonoBehaviour {

    public int experince;
    int maxXp;

    int level;

    public Text shipLevel;


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

        if(level == 1)
        {
            maxXp = 150;
        }
    }
}
