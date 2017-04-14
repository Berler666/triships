using UnityEngine;
using System.Collections;

public class playerMotherShip : MonoBehaviour {

    public GameObject x1;

    GameObject mothershipMenu;

    public float spawntime = 5f;

    

	void Awake () {

        StartCoroutine(SpawnShip());

        mothershipMenu = gameObject.transform.FindChild("MSMenu").gameObject;

        if (!mothershipMenu)
        {
            Debug.Log("missing mothership ui");
        }
        else
        {
            mothershipMenu.SetActive(false);

        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator SpawnShip()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawntime);
            Debug.Log("spawning ship");
            Vector3 position = transform.position + new Vector3(Random.Range(-5f, 5f), 0.5f, Random.Range(-5f, 5f));
            Instantiate(x1, position, Quaternion.identity);
        }
        
    }

    void OnMouseDown()
    {
        mothershipMenu.SetActive(true);
    }
}
