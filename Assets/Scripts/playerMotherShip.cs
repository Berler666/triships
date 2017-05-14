using UnityEngine;
using System.Collections;

public class playerMotherShip : MonoBehaviour {

    public GameObject x1;

    public GameObject VHScamera;
   

    public GameObject mothershipMenu;

    public float spawntime = 5f;

    bool isPlayer = true;
  

    

	void Awake () {

        StartCoroutine(SpawnShip());

        VHScamera.SetActive(false);

       if(gameObject.GetComponent<Unit>().teamNumber != 1)
        {
            isPlayer = false;
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
        if (isPlayer == true)
        {
            Debug.Log("paused");
            VHScamera.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
