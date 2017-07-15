using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnitControl : MonoBehaviour
{
    #region INSPECTOR FIELDS
    public Image selectBox;
    public GameObject waypoint;
    #endregion

    #region INPUT EVENTS DEFINITION
    public delegate void OnEventHandle();
    public static event OnEventHandle OnDeSelect;

    public delegate void OnPointEventHandle(Vector3 point);
    public static event OnPointEventHandle OnMove;

    public delegate void OnRectEventHandle(Rect rect);
    public static event OnRectEventHandle OnSelectRect;

    public delegate void OnUnitEventHandle(Unit unit);
    public static event OnUnitEventHandle OnAttack;
    public static event OnUnitEventHandle OnSelect;
    #endregion

    #region PRIVATE FIELDS
    Vector2 downPos = Vector2.zero;
    Canvas selectCanvas;
    #endregion

    #region ENGINE MESSAGES
    void Start()
    {
        if (!selectBox) Debug.LogWarning("The SelectBox fields is empty in the " + this);
        else
        {
            selectCanvas = selectBox.GetComponentInParent<Canvas>();
            if (!selectCanvas) Debug.LogWarning("The SelectBox must to have parent game object with a Canvas component in the " + this);
            else selectCanvas.renderMode = RenderMode.ScreenSpaceOverlay;

            selectBox.enabled = false;
            selectBox.rectTransform.pivot = Vector2.zero;

            CanvasGroup group = selectBox.GetComponent<CanvasGroup>();
            if (!group) group = selectBox.gameObject.AddComponent<CanvasGroup>();
            group.blocksRaycasts = false;
        }
    }
    void Update()
    {
        Vector2 position = Common.GetInputPosition();
        if ((Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
        && !EventSystem.current.IsPointerOverGameObject()) downPos = position;

        Rect selectRect = new Rect();
        if (downPos != Vector2.zero && !Common.Round(downPos, position))
        {
            selectRect = Common.GetScreenRect(downPos, position);

            if (selectBox)
            {
                selectBox.enabled = true;
                selectBox.rectTransform.position = selectRect.position;
                if (selectCanvas) selectBox.rectTransform.sizeDelta = selectRect.size / selectCanvas.scaleFactor;
            }
        }

        if(Input.GetButtonUp("Fire1"))
{
            if (Common.Round(downPos, position))
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(position), out hit))
                {
                    Unit unit = hit.transform.GetComponent<Unit>();
                    if (unit)
                    {
                        if (unit.team == Team.playerTeam && OnDeSelect != null && OnSelect != null)
                        {
                            OnDeSelect();
                            OnSelect(unit);
                        }
                    }
                }
            }
            else if (downPos != Vector2.zero && OnDeSelect != null && OnSelectRect != null)
            {
                OnDeSelect();
                OnSelectRect(selectRect);
            }

            downPos = Vector2.zero;
            selectBox.enabled = false;
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(position), out hit, Mathf.Infinity))
            {
                Unit unit = hit.transform.GetComponent<Unit>();
                if (unit)
                {
                    if (unit.team != Team.playerTeam && OnAttack != null) OnAttack(unit);
                }
                else if (OnMove != null)
                {
                    OnMove(hit.point);
                    if(GameObject.FindGameObjectWithTag("Waypoint"))
                    {
                        Destroy(GameObject.FindGameObjectWithTag("Waypoint"));
                        GameObject NewWaypoint = Instantiate(waypoint, new Vector3(hit.point.x, hit.point.y + 2f, hit.point.z), transform.rotation);
                    }
                    else
                    {
                        GameObject NewWaypoint = Instantiate(waypoint, new Vector3(hit.point.x, hit.point.y + 2f, hit.point.z), transform.rotation);
                    }
                    
                }
            }

            downPos = Vector2.zero;
            selectBox.enabled = false;
        }
    }
    #endregion
}