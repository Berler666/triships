using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UnitIcon : MonoBehaviour
{
    #region INSPECTOR FIELDS
    public Unit unit;
    public float healthbarHeight = 5;
    #endregion

    #region PRIVATE FIELDS
    Image healthbar;
    #endregion

    #region ENGINE MESSAGES
    void Start()
    {
        name = "UnitIcon";

        if (unit)
        {
            GetComponent<Image>().sprite = unit.icon;
            healthbar = new GameObject().AddComponent<Image>();

            healthbar.color = unit.team.color;
            healthbar.name = "HealthBar";
            healthbar.transform.SetParent(transform);

            healthbar.rectTransform.anchorMax = healthbar.rectTransform.anchorMin =
                healthbar.rectTransform.pivot = Vector2.zero;
        }
    }
    void Update()
    {
        if (unit)
        {
            if (unit.health <= 0) Destroy(gameObject);
            float healthBarWidth = unit.health / unit.maxHealth * ((RectTransform)transform).sizeDelta.x;
            healthbar.rectTransform.sizeDelta = new Vector2(healthBarWidth, healthbarHeight);
        }
    }
    #endregion
}