using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour
{
    #region INSPECTOR FIELDS
    public float rayLife = 0.5f;
    public float raySpeed = 0.5f;
    public float rayTiling = 1;
    #endregion

    #region PRIVATE FIELDS
    LineRenderer render;

    float fireExitTime = 0;
    Transform target = null;
    #endregion

    #region PUBLIC METHODS
    public void Fire(Transform enemy)
    {
        fireExitTime = Time.time + rayLife;
        render.enabled = true;
        target = enemy;
    }
    #endregion

    #region PRIVATE METHODS
    Vector3 GetHitPosition()
    {
        RaycastHit hit;
        if (target.GetComponent<Collider>().Raycast(new Ray(transform.position, target.position - transform.position), out hit, 100)) return hit.point;
        else return target.position;
    }
    #endregion

    #region ENGINE MESSAGES
    void Start()
    {
        render = GetComponent<LineRenderer>();
        render.enabled = false;
    }
    void Update()
    {
        if (render.enabled)
        {
            if (fireExitTime < Time.time) render.enabled = false;
            else if (target)
            {
                render.SetPosition(0, transform.position);
                render.SetPosition(1, GetHitPosition());

                render.material.mainTextureOffset = new Vector2(
                    render.material.mainTextureOffset.x - raySpeed / rayTiling,
                    render.material.mainTextureOffset.y);
                render.material.mainTextureScale = new Vector2(
                    Vector3.Distance(transform.position, target.transform.position) / rayTiling,
                    render.material.mainTextureScale.y);
            }
        }
    }
    #endregion
}