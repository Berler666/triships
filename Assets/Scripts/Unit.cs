using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Unit : MonoBehaviour
{
    #region INSPECTOR FIELDS
    [Range(0, Team.TEAMS_COUNT - 1)]
    public uint teamNumber = 1;
    // public int tnumber;
    public Sprite icon;
    public GameObject xpOrb1;

    public GameObject[] debris;

    int xpSpawmAmount;
    int debrisAmount;




    public GameObject explosion;
    public GameObject model;

    [Header("Health")]
    public float health = 100;
    public float maxHealth = 100;
    public float regeneration = 1;
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
    void DeSelect()
    {
        if (selected)
        {
            selected = false;
           
        }
    }
    void Select(Unit unit)
    {
        if (unit == this)
        {
            selected = true;

            if (OnUnitIsSelected != null) OnUnitIsSelected(this);
        }
    }
    void SelectRect(Rect rect)
    {
        if (rect.Contains(Camera.main.WorldToScreenPoint(transform.position)))
        {
            selected = true;

            if (OnUnitIsSelected != null) OnUnitIsSelected(this);
        }
    }
    #endregion

    #region ENGINE MESSAGES
    void Awake()
    {
        team = Team.teams[teamNumber];


        if (!icon) Debug.LogWarning("The Icon field is empty in the " + this);





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
        if (selected == false)
        {

        }

        if (health != maxHealth)
        {
            if (health <= 0)
            {

                xpSpawmAmount = Random.Range(4, 10);
                for (int i = 0; i < xpSpawmAmount; i++)
                {
                    float ranX = Random.Range(-.1f, .1f);
                    float ranZ = Random.Range(-.1f, .1f);

                    GameObject xpOrbs = Instantiate(xpOrb1, new Vector3(transform.position.x + ranX, transform.position.y, transform.position.z + ranZ), transform.rotation) as GameObject;
                }

                debrisAmount = Random.Range(2, 6);
                for (int i = 0; i < debrisAmount; i++)
                {

                    Instantiate(debris[Random.Range(0, debris.Length)], transform.position, transform.rotation);
                }

                GameObject shipboom = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
                DeSelect();
                Destroy(gameObject);
            }
            else if (health < maxHealth) health += regeneration * Time.deltaTime;
            else health = maxHealth;
        }
    }
    #endregion
}