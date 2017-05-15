using UnityEngine;
using System.Collections;

public class enemyLazer : MonoBehaviour
{


    public GameObject Laserhit;

    int tnumber = 2;


    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider enemy)
    {
        Unit obj = enemy.gameObject.GetComponent<Unit>();


        if (!obj && enemy.tag != "laser")
        {
           
            Destroy(gameObject);
        }

        if (obj.teamNumber == 1)
        {
           
            obj.health -= LogicWarrior.damage;

            GameObject hit = Instantiate(Laserhit, transform.position, Quaternion.Euler(0, 180, 0)) as GameObject;
            Destroy(gameObject);
        }

        if (obj.GetComponent<Unit>().teamNumber == tnumber)
        {
            Debug.Log("Friendly fire");
            Physics.IgnoreCollision(GetComponent<Collider>(), obj.GetComponent<Collider>());
        }

        if(!enemy)
        {
            Debug.Log("whyyy");
        }

    }

}
