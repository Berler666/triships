using UnityEngine;
using System.Collections;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
[RequireComponent(typeof(Unit))]
public class LogicWarrior : MonoBehaviour
{
    #region INSPECTOR FIELDS
    [Header("Attack Settings")]
    public float attackDelay = 1;
    public float attackDistance = 5;
    public float Wdamage = 5;
    public float shootForce = 50;
    public GameObject laser;
    public GameObject shipGun;
    public AudioClip laserSound;
    private AudioSource source;
    public AudioClip engineSound;

   


    [Header("Enemy Detection")]
    public bool detectEnemies = true;
    public float detectionDistance = 10;

    [Header("Patrol Area")]
    public bool patrolArea = true;
    public float patrolDelay = 5;
    public float patrolDistance = 10;
    float xx, yy, zz;

    #endregion

    #region PRIVATE FIELDS
    UnityEngine.AI.NavMeshAgent navagent;
    Unit unit;
    bool selected;
    float attackTime = 0;
    float patrolTime = 0;
    Vector3 pivot;
    public Unit target = null;
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
            StartCoroutine(_moveWaitForEndFRame(point));
        }
    }

    IEnumerator _moveWaitForEndFRame(Vector3 point)
    {
        yield return new WaitForEndOfFrame();
        navagent.destination = point;
        source.PlayOneShot(engineSound);
        
       
        target = null;
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
        source = GetComponent<AudioSource>();
        navagent = GetComponent<UnityEngine.AI.NavMeshAgent>();
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

    void Select()
    {
        selected = true;
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

                if (attackTime < Time.time && checkIfObjectFacingTheEnemy(transform.rotation, rotation))
                {
                    attackTime = Time.time + attackDelay;
                    GameObject thisLaser = Instantiate(laser, shipGun.transform.position, shipGun.transform.rotation) as GameObject;
                    source.PlayOneShot(laserSound);
                    Physics.IgnoreCollision(thisLaser.GetComponent<Collider>(), GetComponent<Collider>());
                   
                    thisLaser.GetComponent<Rigidbody>().AddForce((shipGun.transform.forward) * shootForce);
                    if (unit.team == Team.playerTeam )
                    {
                        thisLaser.GetComponent<LaserBasic>().myship = this.gameObject;
                    }
                    else
                    {
                        thisLaser.GetComponent<enemyLazer>().myship = this.gameObject;
                    }
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

    bool checkIfObjectFacingTheEnemy(Quaternion self, Quaternion targetRot)
    {
        xx = Mathf.Abs(Mathf.Abs(self.x) - Mathf.Abs(targetRot.x));
        yy = Mathf.Abs(Mathf.Abs(self.y) - Mathf.Abs(targetRot.y));
        zz = Mathf.Abs(Mathf.Abs(self.z) - Mathf.Abs(targetRot.z));
        if (xx < .05f && yy < .05f && zz < .05f)
            return true;
        else
            return false;
    }
}