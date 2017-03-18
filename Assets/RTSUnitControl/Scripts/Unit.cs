using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Unit : MonoBehaviour
{
    #region INSPECTOR FIELDS
    [Range(0, Team.TEAMS_COUNT-1)] public uint teamNumber = 1;
    public Sprite icon;
   // public Light light;

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
           // if (light) light.color = Color.green;
        }
    }
    void Select(Unit unit)
    {
        if (unit == this)
        {
            selected = true;
           // if (light) light.color = Color.white;
            if (OnUnitIsSelected != null) OnUnitIsSelected(this);
        }
    }
    void SelectRect(Rect rect)
    {
        if (rect.Contains(Camera.main.WorldToScreenPoint(transform.position)))
        {
            selected = true;
            //if (light) light.color = Color.white;
            if (OnUnitIsSelected != null) OnUnitIsSelected(this);
        }
    }
    #endregion

    #region ENGINE MESSAGES
    void Awake()
    {
        team = Team.teams[teamNumber];

        if (!icon) Debug.LogWarning("The Icon field is empty in the " + this);

      
      //  if (!light) Debug.LogWarning("The light field is empty in the " + this);
       

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
        if (health != maxHealth)
        {
            if (health <= 0) Destroy(gameObject);
            else if (health < maxHealth) health += regeneration * Time.deltaTime;
            else health = maxHealth;
        }
    }
    #endregion
}