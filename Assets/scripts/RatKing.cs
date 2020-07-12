using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;
using Random = UnityEngine.Random;

// hmm this should be interesting?
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(HealthBar))]
public class RatKing : Attention
{
    public float NormalSpeed = 10f;
    public float AlertSpeed = 30f;
    public float AlertRadius = 10f;
    public float UpdateRate = 0.2f;
    public float FleeDistance = 20f;
    [SerializeField]
    public Vector2 WanderRange;

    public GameObject RatPrefab;

    private NavMeshAgent _agent;
    private List<Cat> _nearbyCats = new List<Cat>();
    private float _wanderAngle = 2;
    private float _t;
    private float _wanderTarget;
    private Vector3 _wanderDir = Vector3.zero;
    private HealthBar _healthBar;


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(Evading(), 10f);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, AlertRadius);
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

    private void Start()
    {
        // for some reason this guy isn't getting called... hmm 
        RaycastHit[] hits = Physics.SphereCastAll(this.transform.position, Radius, Vector3.down);
        foreach( var h in hits )
        {
            Cat c = h.collider.GetComponent<Cat>();
            if( c != null )
            {
                _nearbyCats.Add(c);
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
        wanderForce = transform.position + SetAngle(_wanderAngle) * AlertRadius;
        return wanderForce;
    }

    /// <summary>
    ///  check the distance of nearby cat and determine if the rat is threaten or not.
    /// </summary>
    /// <returns></returns>
    public bool IsThreaten()
    {
        // Gene and Sarah, forgive me on this lol.
        return _nearbyCats.Where(x => CheapDist(x.transform.position, transform.position, AlertRadius)).Any();
    }

    private Vector3 Evading()
    {
        Vector3 dir = Vector3.zero;
        // if the array list 
        if (_nearbyCats.Count == 0) return dir;
        // sum all nearby cat position
        _nearbyCats.ForEach( x => dir += x.transform.position );
        // Divide the sum of dir to the total count of cats.
        dir /= _nearbyCats.Count;
        // subtract average herd of cats by rat position to find the direction.
        dir = ( dir - transform.position ).normalized * AlertRadius;
        // return the inverse direction of which the rat needs to flee safely.
        return -dir * FleeDistance + transform.position;
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
        Cat c = other.gameObject.GetComponent<Cat>();
        if( c != null )
        {
            _nearbyCats.Add(c);
            c.ChaseTowards(this.gameObject);
        }
    }

    // hmm...?
    private void OnTriggerExit(Collider other)
    {
        Cat c = other.gameObject.GetComponent<Cat>();
        if( c != null )
        {
            _nearbyCats.Remove(c);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Cat c = collision.gameObject.GetComponent<Cat>();
        if( c != null )
        {
            c.Feed(this);
            // just for example right now
            _healthBar.InflictDamage(15);
            // in this case here, sarah wants to see what happen if the rat king spawns wave of rats?
            for(int i = 0; i < 5; i++)
            {
                Instantiate(RatPrefab, SetAngle(Random.Range(-360, 360)) * 2f + transform.position, Quaternion.identity);
            }
            return;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        // needs a timer hmm..
        Cat cat = collision.gameObject.GetComponent<Cat>();
        if( cat != null )
        {
            cat.Feed(this);
            _healthBar.InflictDamage(15);
            return;
        }
    }


    #region Function
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

    /// <summary>
    /// Because Gene wants to learn more about this function here you go! lol.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="d"></param>
    /// <returns></returns>
    private bool CheapDist(Vector2 a, Vector2 b, float d)
    {
        // instead of using the expensive function of square root, we'll square them all and compare the result instead.
        return d * d > (a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y);
    }

    #endregion

}
