using UnityEngine;
using System.Collections;

public class enemyLazer : MonoBehaviour
{


    public GameObject Laserhit;

    int tnumber = 2;

    public float damage = 5;


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

        if (obj && obj.teamNumber == 1)
        {
           
            obj.health -= damage;

            GameObject hit = Instantiate(Laserhit, transform.position, Quaternion.Euler(0, 180, 0)) as GameObject;
            Destroy(gameObject);
        }

        if (obj && obj.GetComponent<Unit>().teamNumber == tnumber)
        {
           
            Physics.IgnoreCollision(GetComponent<Collider>(), obj.GetComponent<Collider>());
        }

        

    }

}

                           

                          