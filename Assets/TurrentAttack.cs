using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurrentAttack : MonoBehaviour {
	Ray ray;
	public Transform direction;
	public bool canCastRay;
	RaycastHit hit;
	Vector3 startPoint;
 	public GameObject _targetD, laser;
	public GameObject barrel;
    public GameObject barrelLookAt, gun;
	int i;
	public LayerMask layer;
    float attackTime = 0, attackDelay=1; 
    // Use this for initialization
    void Start () {
		//direction = placingTurrent.ins.direction;
 		castRay ();
		startPoint = new Vector3 (transform.position.x, transform.position.y, transform.position.z + 5.5f);
		i = 0;
	}
	
	// Update is called once per frame
	void castRay () {
 
        //Collider[] objectsInRange = Physics.OverlapBox(new Vector3(transform.position.x,transform.position.y, transform.position.z+10), new Vector3(1,1,10), transform.rotation);

        Collider[] objectsInRange = Physics.OverlapCapsule(direction.transform.position,  direction.transform.position, 10);

        foreach ( Collider temp in objectsInRange  ) { if (_targetD == null) {
                if (temp.gameObject.CompareTag("enemy")) { _targetD = temp.gameObject; attackTime = Time.time;  break; }
            }  }

        if (_targetD != null){
            barrelLookAt.transform.LookAt (_targetD.transform.position);
            gun.transform.LookAt(_targetD.transform.position);
            if (barrelLookAt.transform.localEulerAngles.x > 270 && barrelLookAt.transform.localEulerAngles.x < 360) {
                barrel.transform.localEulerAngles = barrelLookAt.transform.localEulerAngles;
                StartCoroutine("fireLaser");
            }
        }
       StartCoroutine("giveWait");	 
	}

    IEnumerator fireLaser() {
        if (attackTime < Time.time)  {
            attackTime = Time.time + attackDelay;
            GameObject thisLaser = Instantiate(laser, gun.transform.position, gun.transform.rotation) as GameObject;
            thisLaser.GetComponent<Rigidbody>().AddForce((gun.transform.forward) * 50);
            thisLaser.GetComponent<LaserBasic>().myship = this.gameObject;
        }
        yield return null;

    }

    IEnumerator giveWait(){
		yield return null;
 		castRay ();
	}
}
