using UnityEngine;
using System.Collections;

public class Lookat : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if(!player)
        {
            player = GameObject.Find("Main Camera");
        }

        transform.LookAt(player.transform) ;
        transform.Rotate(0, 180, 0);


    }
}
