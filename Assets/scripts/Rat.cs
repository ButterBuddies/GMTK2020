using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(HealthBar))]
public class Rat : Attention
{
    public float NormalSpeed = 10f;
    public float AlertSpeed = 30f;
    public float AlertRadius = 10f;
    public float UpdateRate = 0.2f;
    [SerializeField]
    public Vector2 WanderRange;

    public enum State { Wander, Panic };
    public State state = State.Wander;

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
        Gizmos.DrawSphere(SafeDirection(), 1f);
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
        RaycastHit[] hits = Physics.SphereCastAll(this.transform.position, Radius, Vector3.down);
        foreach( var h in hits )
        {
            Cat c = h.collider.GetComponent<Cat>();
            if( c != null )
            {
                _nearbyCats.Add(c);
                c.MoveTowards(this.gameObject);
            }
        }
        _healthBar = GetComponent<HealthBar>();
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = NormalSpeed;
        _wanderTarget = UnityEngine.Random.Range(WanderRange.x, WanderRange.y);
        PseudoUpdate();
    }

    private void Alerted()
    {
        state = State.Panic;
        _agent.speed = AlertSpeed;
    }

    private void Calmed()
    {
        state = State.Wander;
        _agent.speed = NormalSpeed;
    }

    //public Vector3 Flee(Vector3 newTarget)
    //{
    //    desiredVelocity = (transform.position - newTarget);
    //    desiredVelocity = desiredVelocity.normalized;
    //    desiredVelocity = desiredVelocity * maxVelocity;
    //    steering = desiredVelocity - rigidbody.velocity;

    //    steering = Vector3.ClampMagnitude(steering, maxForce);
    //    steering = steering / rigidbody.mass;

    //    return Vector3.ClampMagnitude(rigidbody.velocity + steering, maxSpeed);
    //    //rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity + steering, maxSpeed);
    //}

    private Vector3 SetAngle(float dir)
    {
        Vector3 org = Vector3.zero;
        org.x = Mathf.Cos(dir);
        org.z = Mathf.Sin(dir);
        return org;
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

    private bool CheapDist(Vector2 a, Vector2 b, float d )
    {
        // instead of using the expensive function of square root, we'll square them all and compare the result instead.
        return d * d > ( a.x - b.x ) * ( a.x - b.x ) + ( a.y - b.y ) * ( a.y - b.y );
    }

    // check the distance of nearby cat and determine if the rat is threaten or not.
    public bool IsThreaten()
    {
        // Gene and Sarah, forgive me on this lol.
        return _nearbyCats.Where(x => CheapDist(x.transform.position, transform.position, AlertRadius)).Any();
        //for (int i = 0, n = _nearbyCats.Count; i < n; i++)
        //{
        //    if (CheapDist(transform.position, _nearbyCats[i].gameObject.transform.position, AlertRadius))
        //        return true;
        //}
        //return false;
    }

    private Vector3 SafeDirection()
    {
        Vector3 dir = Vector3.zero;
        // if the array list 
        if (_nearbyCats.Count == 0) return dir;
        // sum all nearby cat position
        _nearbyCats.ForEach(x=>dir+=x.transform.position);
        // divided it by the number of count for average danger position.
        dir /= _nearbyCats.Count;
        // subtract that by current player position to find the direction, then invert it.
        dir -= transform.position;
        // return the inverse direction of which the rat needs to flee safely.
        return -dir;
    }    

    private void PseudoUpdate()
    {
        switch( state )
        {
            case State.Wander: WanderCondition(); break;
            case State.Panic: PanicCondition(); break;
        }

        // calculate total 
        Invoke("PseudoUpdate", UpdateRate);
    }

    private void PanicCondition()
    {
        if( !IsThreaten() )
        {
            state = State.Wander;
            _agent.speed = NormalSpeed;
        }
        else
        {
            if( _t > UpdateRate)
            _agent.destination = SafeDirection();
        }
    }

    private void WanderCondition()
    {
        if (IsThreaten())
        {
            state = State.Panic;
            _agent.speed = AlertSpeed;
        }
        else
        {
            _t += UpdateRate;
            if (_t > _wanderTarget)
            {
                _t = 0;
                _wanderTarget = UnityEngine.Random.Range(WanderRange.x, WanderRange.y);
                _wanderDir = Wander();
                _agent.destination = _wanderDir;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // so... if a collder is a cat, we need to add them to the list.
        Cat c = other.gameObject.GetComponent<Cat>();
        if( c != null )
        {
            _nearbyCats.Add(c);
            c.MoveTowards(this.gameObject);
        }
    }

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
            Debug.Log("AHH I'VE BEEN CONSUMED!");
            c.Feed(this);
            // just for example right now
            _healthBar.InflictDamage(15);
            return;
        }

        // If the player suddenly were to run over the rats... splat them.
        FirstPersonController fpcontroller = collision.transform.GetComponent<FirstPersonController>();
        if (fpcontroller != null && fpcontroller.m_MoveDir != Vector3.zero)
        {
            _healthBar.Oblierated();
        }
    }
}
