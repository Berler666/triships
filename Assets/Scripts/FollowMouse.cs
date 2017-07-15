using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    


    void Start()
    {
        BuildingController.CollisionTest = true;
    }

    void Update()
    {
        transform.position = new Vector3(BuildingController.GroundMousePoint.x, BuildingController.GroundMousePoint.y + 0.5f, BuildingController.GroundMousePoint.z);


        if (Input.GetMouseButtonUp(1))
        {
            BuildingController.ghostActive = false;
            Destroy(this.gameObject);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        BuildingController.CollisionTest = false;
        Debug.Log("Object");
    }

    void OnTriggerExit(Collider other)
    {
        BuildingController.CollisionTest = true;

    }
}
