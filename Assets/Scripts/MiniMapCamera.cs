using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MiniMapCamera : MonoBehaviour
{
    #region INSPECTOR FIELDS
    public Vector3 followPosition = new Vector3(0, 100, 25);
    public Transform followTarget;
    #endregion

    #region ENGINE MESSAGES
    void Start()
    {
        if (!followTarget)
            Debug.LogWarning("The FollowTarget field requires an initialization in the " + this);
    }
    void Update()
    {
        if (followTarget)
        {
            Vector3 newPosition = followTarget.position + followPosition;
            Vector3 newEulerAgles = new Vector3(transform.eulerAngles.x, followTarget.eulerAngles.y, transform.eulerAngles.z);

            if (newPosition != transform.position)
                transform.position = newPosition;

            if (newEulerAgles != transform.eulerAngles)
                transform.eulerAngles = newEulerAgles;
        }
    }
    #endregion
}