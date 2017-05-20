using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

	// Use this for initialization
	void Start () {

        float size = Random.Range(1.0f, 5.0f);

        transform.localScale = new Vector3(size, size, size);

        GetComponent<Rigidbody>().mass = size;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
