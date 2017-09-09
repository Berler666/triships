using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour {

    public bool isBuilding = false;
    public bool canBuild = false;
    public static bool ghostActive = false;
    public static bool CollisionTest;
    public bool inDistance = true;
    public bool inMenu;

    public GameObject ghost;
    public GameObject Building;
    public LineRenderer Line;
  

    public Material GreenTransparent;
    public Material RedTransparent;

    public bool researchFacility = false;

    public GameObject Mothership;
    public float maxDistance = 10;

    [Header("Moduels")]
    public GameObject Moduel1;
    public GameObject ghost1;
    public GameObject Moduel2;
    public GameObject Moduel3;


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

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, GroundOnly))
        {
            GroundMousePoint = hit.point;

        }

        if (ghostActive)
        {

            



            if (Vector3.Distance(ghost.transform.position, Mothership.transform.position) > 10)
            {
                inDistance = false;
            }
            else
            {
                inDistance = true;
            }

            Line = ghost.GetComponentInChildren<LineRenderer>();
            Line.SetPosition(0, ghost.transform.position);
            Line.SetPosition(1, Mothership.transform.position);

         



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
                ghostActive = false;
                Destroy(ghost);

            }

            if (Input.GetMouseButtonUp(0) && !canBuild && inMenu)
            {
                Debug.Log("Cannot build");
            }

          

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

    }

  
}
