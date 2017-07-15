using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotEoughResources : MonoBehaviour {

    public float waitTime;
    public static bool showNER = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(showNER == true)
        {
            StartCoroutine(WaitToDisable());
            showNER = false;
        }
		
	}

    public IEnumerator WaitToDisable()
    {
        gameObject.GetComponent<Text>().enabled = true;
        yield return new WaitForSeconds(waitTime);
        gameObject.GetComponent<Text>().enabled = false;

    }
}
