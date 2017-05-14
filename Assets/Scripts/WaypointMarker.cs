using UnityEngine;
using System.Collections;

public class WaypointMarker : MonoBehaviour {

    public float waitTime;
    bool scale = false;

   
   

  

	// Use this for initialization
	void Start () {

        StartCoroutine(waitforDrop());
	
	}
	
	// Update is called once per frame
	void Update () {

        if(scale == true)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0f, 0f, 0f), 2f * Time.deltaTime);
        }

	
	}

    IEnumerator waitforDrop()
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        scale = true;
        Destroy(gameObject, 2);
       
    }
}
