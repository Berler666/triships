using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour {

    public GameObject Mothership;
    public GameObject ResearchCenterBtn;
    public GameObject Turrent1Btn;
//	[HideInInspector]
	public bool canPlaceAsteroidSheild= false;

    public bool researchFacility = false;
    public static bool AsteroidShield = false;


    [Header("Building")]
    public bool inDistance = true;
    public bool inMenu;
    public bool isBuilding = false;
    public bool canBuild = false;
    public static bool ghostActive = false;
    public static bool CollisionTest;
    public GameObject ghost;
    public GameObject Building;
    public LineRenderer Line;
    public Material GreenTransparent;
    public Material RedTransparent;
    public static BuildingController buildControl;
    public static Vector3 GroundMousePoint;
    public LayerMask GroundOnly;
    RaycastHit hit;

    [Header("circle renderer")]
    public GameObject circleRenderer;
    public bool canRotateRenderer = true;
    public float DistanceMax = 10;
	public LayerMask layer;

    [Header("Moduels")]
    public GameObject ResearchCenter;
    public GameObject ResearchCenterGhost;
    public GameObject Moduel2;
    public GameObject Moduel3;
	public GameObject bridge;
	public Transform  bridgeParent;
	public GameObject _AsteroidShield;
	public Transform sheildParent;

    [Header("Objects")]
    public GameObject _turrentUp, motherShip;
    public Transform parentTurrent;
    public GameObject turrentMouseFollow;
	Vector3 sphereMousePoint;

   
    void Start () {
        buildControl = this;

     }
	
	// Update is called once per frame
	void Update () {

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         if (Physics.Raycast(ray, out hit, Mathf.Infinity, GroundOnly)){
			GroundMousePoint = new Vector3( hit.point.x, Mothership.transform.position.y, hit.point.z);

        }

		if (ghostActive) {
 			if (Vector3.Distance (ghost.transform.position, Mothership.transform.position) > DistanceMax) {
				inDistance = false;
			} else {
				inDistance = true;
			}

			Line = ghost.GetComponentInChildren<LineRenderer> ();
			Line.SetPosition (0, ghost.transform.position);
			Line.SetPosition (1, Mothership.transform.position);
			if (canRotateRenderer) {
				circleRenderer.transform.parent.LookAt (ghost.transform.position);
			}
		}
      }
	 
    void LateUpdate()
    {
		if (ghostActive) {
			if (inDistance == true && CollisionTest == true) {
				canBuild = true;
				ghost.GetComponent<Renderer> ().material = GreenTransparent;
				Line.material = GreenTransparent;
			} else {
				canBuild = false;
				ghost.GetComponent<Renderer> ().material = RedTransparent;
				Line.material = RedTransparent;
			}   

			if (Input.GetMouseButtonUp (0) && canBuild && !inMenu) {
				Debug.Log ("Building the unit");
				GameObject newUnit = Instantiate (Building, GroundMousePoint, Quaternion.identity) as GameObject;
				newUnit.tag = "ResearchLab";
				newUnit.transform.eulerAngles = ghost.transform.eulerAngles;
				makeBridge (newUnit);
				ghostActive = false;
				Destroy (ResearchCenterBtn);
				Destroy (ghost);
				circleRenderer.SetActive (false);
				Cursor.visible = true;
			}

			if (Input.GetMouseButtonUp (0) && !canBuild && inMenu) {
				Debug.Log ("Cannot build");
			}
			if (Input.GetMouseButtonDown (1)) {
				circleRenderer.SetActive (false);
				Cursor.visible = true;
			}
		}

        //inMenu = false;
    }
	void FixedUpdate () {
		if(canPlaceAsteroidSheild){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Input.GetMouseButtonDown (1)) {
				if (Physics.Raycast (ray, out hit,150,layer)) {
					if (hit.collider.name == "Mother Ship Collider Turrentz" ) {
 						sphereMousePoint = new Vector3 (hit.point.x, hit.point.y, hit.point.z);
						AsteroidSheilds (hit.point);
					}
				}
			}
		}
 	}
 
    //Object Placing

        public void Turrent1()
    {
        GameObject.Find("Mothership UI Controller").GetComponent<MotherShipMenu>().BackButton();
        placingTurrent.ins.canPlaceTurrent = true;
        turrentMouseFollow.SetActive(true);
          inMenu = false;
        Destroy(Turrent1Btn);
        
    }

	public void AsteroidSheilds(Vector3 dir)
	{   
         GameObject.Find("Mothership UI Controller").GetComponent<MotherShipMenu>().BackButton();
		print ("asteroid sheild is called");
         inMenu = false;
		GameObject asteroidSheild;
 		canPlaceAsteroidSheild = false;
		asteroidSheild = Instantiate (_AsteroidShield,motherShip.transform.position,Quaternion.identity);
 		asteroidSheild.transform.LookAt (dir);
		asteroidSheild.transform.localEulerAngles = new Vector3(asteroidSheild.transform.localEulerAngles.x+90, asteroidSheild.transform.localEulerAngles.y, asteroidSheild.transform.localEulerAngles.z);
 		asteroidSheild.transform.SetParent (sheildParent);
    		
 
    }



    public void buildObject1()
    {
        if (ghostActive)
        {
            Destroy(ghost);
        }
		ghost = Instantiate(ResearchCenterGhost, Vector3.zero, Quaternion.identity) as GameObject;
         Building = ResearchCenter;
        ghostActive = true;
        GameObject.Find("Mothership UI Controller").GetComponent<MotherShipMenu>().BackButton();
        inMenu = false;
		circleRenderer.SetActive (true);
		Cursor.visible = false;
    }
	public void makeBridge(GameObject newUnit){
 		bridge = Instantiate (bridge,Mothership.transform.position, Quaternion.identity);
		bridge.tag="Bridge";
		bridge.transform.SetParent (bridgeParent);
		float distance = Vector3.Distance (Mothership.transform.position, newUnit.transform.position);
		bridge.transform.LookAt (newUnit.transform);
		bridge.transform.localScale =new Vector3(0.4f,0.4f, distance);
		circleRenderer.SetActive (false);
		Cursor.visible = true;
//		print (distance);
	}
 }
