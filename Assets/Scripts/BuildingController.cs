using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour {

    public bool isBuilding = false;
    public bool canBuild = false;
    public static bool ghostActive = false;
    public static bool CollisionTest;
    public static bool AsteroidShield = false;
    public bool inDistance = true;
    public bool inMenu;

    public GameObject ResearchCenterBtn;
 
	public GameObject circleRenderer;
    public GameObject ghost;
    public GameObject Building;
    public LineRenderer Line;
	public float DistanceMax=10;

    public Material GreenTransparent;
    public Material RedTransparent;

    public bool researchFacility = false;

    public GameObject Mothership;
    public float maxDistance = 10;
	[Header("check if you want to rotate the " +
		"circle renderer")]
	public bool canRotateRenderer = true;
    [Header("Moduels")]
    public GameObject Moduel1;
    public GameObject ghost1;
    public GameObject Moduel2;
    public GameObject Moduel3;
	public GameObject bridge;
	public Transform  bridgeParent;


    public static BuildingController buildControl;
    public static Vector3 GroundMousePoint;
    public LayerMask GroundOnly;
    RaycastHit hit;

	 
    // Use this for initialization
    void Start () {
        buildControl = this;
     }
	
	// Update is called once per frame
	void Update () {

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

 
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, GroundOnly)){
            GroundMousePoint = new Vector3( hit.point.x, hit.point.y +1.5f, hit.point.z);

        }

		if (ghostActive) {
			print (Vector3.Distance (ghost.transform.position, Mothership.transform.position));
			if (Vector3.Distance (ghost.transform.position, Mothership.transform.position) > DistanceMax) {
				inDistance = false;
			} else {
				inDistance = true;
			}

			Line = ghost.GetComponentInChildren<LineRenderer> ();
			Line.SetPosition (0, ghost.transform.position);
			Line.SetPosition (1, Mothership.transform.position);
			if (canRotateRenderer) {
				circleRenderer.transform.parent.LookAt (GroundMousePoint);
			}
		}
      }
	 
    void LateUpdate()
    {
        if (ghostActive)
        {
            if (inDistance == true && CollisionTest == true)
            {
                canBuild = true;
                ghost.GetComponent<Renderer>().material = GreenTransparent;
                Line.material = GreenTransparent;
            }
            else
            {
                canBuild = false;
                ghost.GetComponent<Renderer>().material = RedTransparent;
                Line.material = RedTransparent;
            }   

            if (Input.GetMouseButtonUp(0) && canBuild && !inMenu)
            {
                Debug.Log("Building the unit");
                GameObject newUnit = Instantiate(Building, GroundMousePoint, Quaternion.identity) as GameObject;
                newUnit.transform.eulerAngles = ghost.transform.eulerAngles;
				makeBridge (newUnit);
                ghostActive = false;
                Destroy(ResearchCenterBtn);
                Destroy(ghost);
				circleRenderer.SetActive (false);
             }

            if (Input.GetMouseButtonUp(0) && !canBuild && inMenu)
            {
                Debug.Log("Cannot build");
            }
			if (Input.GetMouseButtonDown (1))
				circleRenderer.SetActive (false);
         }

        //inMenu = false;
    }

    public void buildObject1()
    {
        if (ghostActive)
        {
            Destroy(ghost);
        }
		ghost = Instantiate(ghost1, Vector3.zero, Quaternion.identity) as GameObject;
        Building = Moduel1;
        ghostActive = true;
        GameObject.Find("Mothership UI Controller").GetComponent<MotherShipMenu>().BackButton();
        inMenu = false;
		circleRenderer.SetActive (true);
    }
	public void makeBridge(GameObject newUnit){
 		bridge = Instantiate (bridge,Mothership.transform.position, Quaternion.identity);
		bridge.transform.SetParent (bridgeParent);
		float distance = Vector3.Distance (Mothership.transform.position, newUnit.transform.position);
		bridge.transform.LookAt (newUnit.transform);
		bridge.transform.localScale =new Vector3(0.4f,0.4f, distance);
		circleRenderer.SetActive (false);
//		print (distance);
	}
 }
