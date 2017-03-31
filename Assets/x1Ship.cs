using UnityEngine;
using System.Collections;

public class x1Ship : MonoBehaviour {

    int experince;
    int maxXp;

    int level;


	// Use this for initialization
	void Start () {

        level = 0;
        experince = 0;
        maxXp = 50;
	
	}
	
	// Update is called once per frame
	void Update () {

        if (experince == maxXp)
        {
            Levelup();
        }

    }

    void Levelup()
    {
        level += 1;
        Debug.Log("Level " + level + "!");

        if(level == 1)
        {
            maxXp = 150;
        }
    }
}
