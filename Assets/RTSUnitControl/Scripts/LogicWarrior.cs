using UnityEngine;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Unit))]
public class LogicWarrior : MonoBehaviour
{
    #region INSPECTOR FIELDS
    [Header("Attack Settings")]
    public float attackDelay = 1;
    public float attackDistance = 5;
    public float damage = 5;
    public Laser laser;

    [Header("Enemy Detection")]
    public bool detectEnemies = true;
    public float detectionDistance = 10;

    [Header("Patrol Area")]
    public bool patrolArea = true;
    public float patrolDelay = 5;
    public float patrolDistance = 10;
    #endregion

    #region PRIVATE FIELDS
    NavMeshAgent navagent;
    Unit unit;

    float attackTime = 0;
    float patrolTime = 0;
    Vector3 pivot;
    Unit target = null;
    #endregion

    #region EVENTS IMPLEMENTATION
    void Attack(Unit enemy)
    {
        if (unit.selected)
        {
            target = enemy;
        }
    }
    void Move(Vector3 point)
    {
        if (unit.selected)
        {
            navagent.destination = point;
            target = null;
        }
    }
    #endregion

    #region ENGINE MESSAGES
    void OnDestroy()
    {
        UnitControl.OnAttack -= Attack;
        UnitControl.OnMove -= Move;
    }
    void Start()
    {
        if (!laser) Debug.LogWarning("The Laser field is empty in the " + this);

        navagent = GetComponent<NavMeshAgent>();
        navagent.stoppingDistance = navagent.radius + 1;

        unit = GetComponent<Unit>();
        if (unit.team == Team.playerTeam)
        {
            patrolArea = false;
            UnitControl.OnAttack += Attack;
            UnitControl.OnMove += Move;
        }

        pivot = transform.position;
    }
    void Update()
    {
        if (target)
        {
            if (Vector3.Distance(transform.position, target.transform.position) < attackDistance)
            {
                navagent.destination = transform.position;
                Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.1f);

                if (attackTime < Time.time)
                {
                    attackTime = Time.time + attackDelay;
                    target.health -= damage;
                    if (laser) laser.Fire(target.transform);
                }
            }
            else navagent.destination = target.transform.position;
        }
        else if (navagent.remainingDistance < navagent.stoppingDistance)
        {
            if (detectEnemies)
            {
                target = Common.GetNearEnemy(unit, detectionDistance);
            }
            
            if (patrolArea && patrolTime < Time.time)
            {
                patrolTime = Time.time + patrolDelay;
                navagent.destination = Common.GetRandomNavPoint(pivot, patrolDistance);
            }
        }
    }
    #endregion
}