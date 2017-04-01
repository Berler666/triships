using UnityEngine;
using System.Collections;

public class LaserBasic : MonoBehaviour {

    Unit enemy;

	// Use this for initialization
	void Start () {

        Destroy(gameObject, 3);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider enemy)
    {
        if(enemy.tag == "enemy")
        {
            HitTarget();
        }
    }

    void HitTarget()
    {
        Destroy(gameObject);
    }
}
