using UnityEngine;
using System.Collections;

public class playerMotherShip : MonoBehaviour {
    #region INSPECTOR FIELDS

    public GameObject x1;

    public GameObject VHScamera;
   

    public GameObject mothershipMenu;

    public GameObject UI;


    public float spawntime = 5f;

    bool isPlayer = true;
    bool canSpawn = true;

    private float powerRegenTime = 2f;
    private int powerRegen = 1;

    [Header("Resources")]
    public float power;
    public float maxPower;
    public float ammo;
    public float maxAmmo;
    public float scrap;
    public float maxScrap;
    public float units;
    public float maxUnits;

    public int RP;

    #endregion


    void Awake () {

        StartCoroutine(SpawnShip());
        StartCoroutine(PowerRegen());

        VHScamera.SetActive(false);

       if(gameObject.GetComponent<Unit>().teamNumber != 1)
        {
            isPlayer = false;
        }


    }
	
	// Update is called once per frame
	void Update () {

       if(units <= maxUnits)
        {
            canSpawn = true;
        }

       if (units >= maxUnits)
        {
            canSpawn = false;
        }

       if(units == maxUnits)
        {
            canSpawn = false;
        }
	
	}

    IEnumerator SpawnShip()
    {
        
        while (true)
        {
            if (canSpawn == true)
            {
                yield return new WaitForSeconds(spawntime);
                Debug.Log("spawning ship");
                power -= 1;
                Vector3 position = transform.position + new Vector3(Random.Range(-5f, 5f), 0.5f, Random.Range(-5f, 5f));
                GameObject Ship = Instantiate(x1, position, Quaternion.identity) as GameObject;
                

            }

            if (canSpawn == false)
            {
                
                Debug.Log("max units reached");

            }
            yield return null;
        }
        
        
    }
    
    void OnMouseDown()
    {
        if (isPlayer == true)
        {
            Debug.Log("paused");
            VHScamera.SetActive(true);
            UI = GameObject.Find("UICanvas");
            UI.SetActive(false);
            Time.timeScale = 0;
        }
    }

    IEnumerator PowerRegen()
    {
        if(power <= maxPower)
        {
            yield return new WaitForSecondsRealtime(powerRegenTime);
            power += powerRegen;
            StartCoroutine(PowerRegen());
        }
        
        if(power >= maxPower)
        {
            StopCoroutine(PowerRegen());
        }
    }
}
