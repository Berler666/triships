using UnityEngine;
using UnityEngine.UI;

public class UnitView : MonoBehaviour
{
    #region EVENTS IMPLEMENTATION
    void Add(Unit unit)
    {
        UnitIcon icon = new GameObject().AddComponent<UnitIcon>();
        icon.unit = unit;
        icon.transform.SetParent(transform);
    }
    void Clear()
    {
        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; ++i)
                Destroy(transform.GetChild(i).gameObject);
        }
    }
    #endregion

    #region ENGINE MESSAGES
    void OnDestroy()
    {
        UnitControl.OnDeSelect -= Clear;
		Unit.OnUnitIsSelected -= Add;
	
    }
	 
    void Start()
    {
        UnitControl.OnDeSelect += Clear;
        Unit.OnUnitIsSelected += Add;
    }
    #endregion
}