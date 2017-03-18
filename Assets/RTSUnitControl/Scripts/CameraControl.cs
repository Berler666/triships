using UnityEngine;
using UnityEngine.EventSystems;

public class CameraControl : MonoBehaviour
{
    #region CONSTANTS
    const float MAX_HEIGHT = 50;
    const float MIN_HEIGHT = 10;
    #endregion

    #region INSPECTOR FIELDS
    [Range(MIN_HEIGHT, MAX_HEIGHT)] public float height = 15;
    [Range(1, 100)] public float movementSpeed = 20;
    [Range(1, 200)] public float rotationSpeed = 100;
    [Range(1, 200)] public float scrollingSpeed = 100;
    public float movementDistance = 150;
    #endregion

    #region PRIVATE FIELDS
    Vector3 pivot;

    Vector3 position;
    Vector3 rotation;
    #endregion

    #region PRIVATE METHODS
    void CheckHeight()
    {
        RaycastHit hit;
        if (Physics.Raycast(position, Vector3.down, out hit)) position.y = hit.point.y + height;
        else if (Physics.Raycast(position, Vector3.up, out hit)) position.y = hit.point.y + height;
    }
    void Move(Vector3 direction, float speed)
    {
        direction.y = 0;
        direction.Normalize();
        position += direction * speed * Time.deltaTime;
    }
    void Rotate(float speed)
    {
        rotation.y += speed * Time.deltaTime;
    }
    void SetHeight(float speed)
    {
        if (speed < 0 && height > MIN_HEIGHT)
        {
            height += speed * Time.deltaTime;
            rotation.x = height / MAX_HEIGHT * 85;
        }
        else if (speed > 0 && height < MAX_HEIGHT)
        {
            this.height += speed * Time.deltaTime;
            rotation.x = height / MAX_HEIGHT * 85;
        }
    }
    void SmoothUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, position, 0.01f);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(rotation), 0.01f);
    }
    #endregion

    #region ENGINE MESSAGES
    void Start()
    {
        pivot = transform.position;
        position = transform.position;
        rotation = transform.eulerAngles;
    }
    void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            SetHeight(Input.GetAxis("Mouse ScrollWheel") * scrollingSpeed);

            Vector2 inputPos = Common.GetInputPosition();
            if (Input.GetButton("Fire3")) Rotate(Input.GetAxis("Mouse X") * rotationSpeed);
            else if (inputPos != Vector2.zero)
            {
                if (inputPos.x < 10 && pivot.x - position.x < movementDistance) Move(transform.right, -movementSpeed);
                else if (inputPos.x > Screen.width - 10 && position.x - pivot.x < movementDistance) Move(transform.right, movementSpeed);

                if (inputPos.y < 10 && pivot.z - position.z < movementDistance) Move(transform.forward, -movementSpeed);
                else if (inputPos.y > Screen.height - 10 && position.z - pivot.z < movementDistance) Move(transform.forward, movementSpeed);
            }
        }

        CheckHeight();
        SmoothUpdate();
    }
    #endregion
}