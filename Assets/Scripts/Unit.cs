using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
public class Unit : MonoBehaviour
{  public static Unit ins;
	public HighlighterInteractive hi;
    #region INSPECTOR FIELDS
    [Range(0, Team.TEAMS_COUNT - 1)]
    public uint teamNumber = 1;
	 
    Color32 Full = new Color32(255, 255, 255, 255);
    Color32 Empty = new Color32(255, 255, 255, 0);

    bool fade = true;
    
    public Sprite icon;
    public GameObject xpOrb1;
    GameObject mothership;
    public GameObject killedByShip;

    public GameObject[] debris;

    int xpSpawmAmount;

    public GameObject shipcanvas;
    int debrisAmount;

    Text[] shipsTxts;
    Image[] shipsImages;

    public GameObject explosion;
    public GameObject model;

    [Header("Health")]
    public float health = 100;
    public float maxHealth = 100;
    public float regeneration = 1;
    public Image healthBar;
	[HideInInspector]
	public Color color;
    #endregion

    #region PUBLIC FIELDS
    public bool selected { get; private set; }
    public Team team { get; private set; }
    #endregion

    #region EVENTS DEFINITION
    public delegate void OnUnitEventHandle(Unit unit);
    public static event OnUnitEventHandle OnUnitIsSelected;
    #endregion

    #region EVENTS IMPLEMENTATION
	 
	void Start(){
		if (teamNumber == 1)
			color = Color.green;
		else
			color = Color.red;
	}

																// try catch block is used for bool set reset for 
																// the case when is ship got destroyed by the enemy....
     void DeSelect(){
		try{
			hi.canCallFlash = false;     						// bool is reset for switching off the flashing effect when unit in unselected
		}catch{			
		}
        if (selected){
			selected = false;

		}
    }
    void Select(Unit unit){
		
		if (unit == this) {
			selected = true;
			try{
				hi.canCallFlash = true;    						 // bool is set for switching on the flashing effect when unit is selected
			}catch{
			}
			if (OnUnitIsSelected != null) {
				OnUnitIsSelected (this);
			}

 		}
    }
    void SelectRect(Rect rect)
    {
        if (rect.Contains(Camera.main.WorldToScreenPoint(transform.position)))
		{  
            if(team == Team.playerTeam)
            {
                selected = true;
                try
                {
                    hi.canCallFlash = true;    // bool is set for switching on the flashing effect when unit is selected
                }
                catch
                {
                }
                if (OnUnitIsSelected != null)
                {
                    OnUnitIsSelected(this);
                }

            }


        }
    }
     #endregion

    #region ENGINE MESSAGES

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }

    void Awake()
	{   ins = this;
        team = Team.teams[teamNumber];

         if (!icon) Debug.LogWarning("The Icon field is empty in the " + this);
   
        if(teamNumber == 1)
        {
           GameObject.Find("PlayerMothership").GetComponent<playerMotherShip>().units += 1;
            
        }
		 
         UnitControl.OnDeSelect += DeSelect;
        UnitControl.OnSelect += Select;
        UnitControl.OnSelectRect += SelectRect;
    }
    void OnDestroy()
	{   
        UnitControl.OnDeSelect -= DeSelect;
        UnitControl.OnSelect -= Select;
        UnitControl.OnSelectRect -= SelectRect;
    }
    void Update()
    {

        if(Input.GetMouseButtonDown(0) && selected == true)
        {
            DeSelect();
        }


       

        if(health >= 0)
        {
            healthBar.fillAmount = Map(health, 0, maxHealth, 0, 1);

        }

     
        if (health != maxHealth)
        {
            if (health <= 0)
            {
                
                xpSpawmAmount = Random.Range(10, 20);
                for (int i = 0; i < xpSpawmAmount; i++)
                {
                    float ranX = Random.Range(-.1f, .1f);
                    float ranZ = Random.Range(-.1f, .1f);

                    GameObject xporb = Instantiate(xpOrb1, new Vector3(transform.position.x + ranX, transform.position.y, transform.position.z + ranZ), transform.rotation) as GameObject;
                    xporb.GetComponent<xpOrb>().GotoObject = killedByShip;
                }

                debrisAmount = Random.Range(2, 6);
                for (int j = 0; j < debrisAmount; j++)
                {

                    Instantiate(debris[Random.Range(0, debris.Length)], transform.position, transform.rotation);
                }

                if (teamNumber == 1)
                {
                    GameObject.Find("PlayerMothership").GetComponent<playerMotherShip>().units -= 1;

                }


                
                GameObject shipboom = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
                
                DeSelect();
                Destroy(gameObject);
            }
            else if (health < maxHealth)
            {
                health += regeneration * Time.deltaTime;

            }
            else
            {
                health = maxHealth;
             
            }
        }
    }
    #endregion
}