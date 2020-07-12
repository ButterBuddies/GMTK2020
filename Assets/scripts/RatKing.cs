using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

// hmm this should be interesting?
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(HealthBar))]
public class RatKing : Attention
{
    public float NormalSpeed = 10f;
    public float UpdateRate = 0.2f;
    [SerializeField]
    public Vector2 WanderRange;
    public float TimerDelayForRespawn = 5f;
    public int NumberOfRatSpawnPerRound = 15;

    public GameObject RatPrefab;

    private NavMeshAgent _agent;
    private float _wanderAngle = 2;
    private float _t;
    private float _spawnTimer;
    private float _wanderTarget;
    private Vector3 _wanderDir = Vector3.zero;
    private HealthBar _healthBar;
    private bool _canSpawnAgain = false;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        RaycastHit[] hits = Physics.SphereCastAll(this.transform.position, Radius, Vector3.down);
        foreach (var h in hits)
        {
            Cat c = h.collider.GetComponent<Cat>();
            if (c != null)
            {
                Gizmos.DrawLine(h.transform.position, transform.position);
            }
        }
    }

    public void OnDestroy()
    {
        Debug.Log("rat king defeated");
        //SceneManager.LoadScene("Win");
    }

    private void Start()
    {
        // for some reason this guy isn't getting called... hmm 
        RaycastHit[] hits = Physics.SphereCastAll(this.transform.position, Radius, Vector3.down);
        foreach (var h in hits)
        {
            Cat c = h.collider.GetComponent<Cat>();
            if (c != null)
            {
                c.ChaseTowards(this.gameObject);
            }
        }
        _healthBar = GetComponent<HealthBar>();
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = NormalSpeed;
        _wanderTarget = UnityEngine.Random.Range(WanderRange.x, WanderRange.y);
        PseudoUpdate();
    }

    public Vector3 Wander()
    {
        // Change wanderAngle just a bit, so it
        // won't have the same value in the
        // next game frame.
        _wanderAngle += UnityEngine.Random.Range(-360, 360); //ANGLE_CHANGE - ANGLE_CHANGE * .5;

        // Finally calculate and return the wander force
        Vector3 wanderForce;
        wanderForce = transform.position + SetAngle(_wanderAngle) * 10f;
        return wanderForce;
    }

    private void PseudoUpdate()
    {
        if (_healthBar.state == HealthBar.State.Dead)
            return;

        _t += UpdateRate;
        if (_t > _wanderTarget)
        {
            _t = 0;
            _wanderTarget = UnityEngine.Random.Range(WanderRange.x, WanderRange.y);
            _wanderDir = Wander();
            _agent.destination = _wanderDir;
        }

        // calculate total 
        Invoke("PseudoUpdate", UpdateRate);
    }

    private void OnTriggerEnter(Collider other)
    {
        // so... if a collder is a cat, we need to add them to the list.
        Cat cat = other.gameObject.GetComponent<Cat>();
        if (cat != null)
        {
            cat.ChaseTowards(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Cat c = collision.gameObject.GetComponent<Cat>();
        if (c != null)
        {
            c.Feed(this);
            // just for example right now
            _healthBar.InflictDamage(15);
            // in this case here, sarah wants to see what happen if the rat king spawns wave of rats?
            if (_canSpawnAgain)
            {
                _canSpawnAgain = false;
                _spawnTimer = TimerDelayForRespawn;
                for (int i = 0; i < NumberOfRatSpawnPerRound; i++)
                {
                    Instantiate(RatPrefab, SetAngle(Random.Range(-360, 360)) * 2f + transform.position, Quaternion.identity);
                }
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        // needs a timer hmm..
        Cat cat = collision.gameObject.GetComponent<Cat>();
        if (cat != null)
        {
            cat.Feed(this);
            _healthBar.InflictDamage(15);
            return;
        }
    }

    private void Update()
    {
        if (_spawnTimer > 0 && _canSpawnAgain == false )
        {
            _spawnTimer -= Time.deltaTime;
            if(_spawnTimer <= 0 )
            {
                _canSpawnAgain = true;
                _spawnTimer = 0;
            }
        }
    }

    /// <summary>
    /// Return the direction of which the angle points at in World Space
    /// </summary>
    /// <param name="dir"></param>
    /// <returns></returns>
    private Vector3 SetAngle(float dir)
    {
        Vector3 org = Vector3.zero;
        org.x = Mathf.Cos(dir);
        org.z = Mathf.Sin(dir);
        return org;
    }
}
