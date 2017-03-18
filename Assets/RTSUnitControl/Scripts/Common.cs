using UnityEngine;

public static class Common
{
    #region INPUT
    public static bool touchScreen { get; private set; }

    static Common()
    {
        UseTouchScreen(true);
    }

    public static Vector2 GetInputPosition()
    {
        Vector2 position = Vector2.zero;
        if (!touchScreen) position = Input.mousePosition;
        else if (Input.touchCount > 0) position = Input.touches[0].position;
        return position;
    }

    public static void UseTouchScreen(bool use)
    {
        if (SystemInfo.deviceType == DeviceType.Handheld) touchScreen = use;
        else touchScreen = false;
    }
    #endregion

    #region MATH
    public static bool Round(Vector2 a, Vector2 b, float accuracy = 15)
    {
        return
            (a.x < b.x + accuracy && a.x > b.x - accuracy) &&
            (a.y < b.y + accuracy && a.y > b.y - accuracy);
    }
    #endregion

    #region LOGIC
    public static Unit GetNearEnemy(Unit unit, float distance)
    {
        Collider[] colliders = Physics.OverlapSphere(unit.transform.position, distance);
        for (int i = 0; i < colliders.Length; ++i)
        {
            Unit enemy = colliders[i].GetComponent<Unit>();
            if (enemy && enemy.team != unit.team) return enemy;
        }
        return null;
    }
    public static Vector3 GetRandomNavPoint(Vector3 position, float distance)
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(position + Random.onUnitSphere * distance, out hit, 100, -1)) position = hit.position;
        return position;
    }
    #endregion

    #region SCREEN
    public static Rect GetScreenRect(Vector2 start, Vector2 end)
    {
        Rect rect = new Rect(start, end - start);

        if (rect.width < 0)
        {
            rect.x += rect.width;
            rect.width = -rect.width;
        }

        if (rect.height < 0)
        {
            rect.y += rect.height;
            rect.height = -rect.height;
        }

        return rect;
    }
    #endregion
}