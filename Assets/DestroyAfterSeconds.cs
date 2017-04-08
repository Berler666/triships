using UnityEngine;
using System.Collections;

public class DestroyAfterSeconds : MonoBehaviour {

    public float dieTime;

	void Start () {
        Destroy(gameObject, dieTime);
	
	}
}
