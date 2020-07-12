using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(NavMeshAgent))]
public class Cat : MonoBehaviour
{
    #region variables

    /*
     * The hungry script
     * When the cat moves or finds interesting object, they will lose weight over the time
     * When the cat becomes too hungry, they will become influence by the food more than attention
     * if the cat becoming too full, they will try to play and chase after some things.
     * 
     * Quite a interesting balance as all life should be... #Thanos
     */

    public Animator anim;
    public enum Behavior { Flee, Chase, Idle, Freeze }
    //public enum Emotion { Lonely, Scared, Happy, Clean, Scout, Sleep, Eating }

    // in this case we can determine the shape and size of a cat object.
    public float NormalSpeed = 15f;
    public float NormalWeightDeduction = 0.01f;
    public float FleeSpeed = 50f;
    public float FleeWeightDeduction = 0.02f;
    public float ChaseSpeed = 35f;
    public float ChaseWeightDeduction = 0.04f;

    public float FleeDistance = 5f;

    // if the cat weights gets too much, then thespeed of the cat and the emotion of the cat gets inflicted.
    [Range(0,1)]
    public float weight = 0.5f;
    public AnimationCurve weightScale = new AnimationCurve();

    // Time it takes for cat to change it's behavior decisions beacse you know.. cats get weird and strange to predict?
    public float MaxTimeToChangeDecision = 20.0f;
    public float MinTimeToChangeDecision = 5f;
    private float _timeToChangeDirection;
    // Hmm.... over the time if the cat consume too much then the weight becomes a factor
    [Range(0,1)]
    public float foodConsumption = 0.5f;
    // if the cat is losing weight then the speed and performance of the cat gets afected. affects tolerance and attention span?

    public float MaxRadius = 10f;
    public float MinRadius = 2f;

    public Behavior CurrentBehavior = Behavior.Idle;
    public float AttentionSpan = 10f;

    [Range(0, 1)]
    public float tolerance = 0.5f;

    // in case the cat have found a target to aim for.
    private GameObject _suspectedTarget;
    private NavMeshAgent _agent;
    private float _t = 0;
    private float _scaredTimer = 0;
    private float _currentWeightDeduction = 0;
    private float _speedMagnitude = 0;

    public bool ShowDebug = false;

    public Material[] mats;
    public Renderer TargetRender;

    public Material[] matsEyes;
    public Renderer EyeRender;

    #endregion

    #region Implementations
    public void ChaseTowards( GameObject obj )
    {
        // I'm already chasing!! Go away!
        if (CurrentBehavior == ( Behavior.Chase | Behavior.Flee ) ) return;

        // So here's where the weight system comes to play.
        Item i = GetComponent<Item>();
        switch( i )
        {
            case Food food:
                {
                    if( weight < 0.5 || Random.Range(0.5f, 1.0f) > weight )
                    {
                        SetChaseMode(obj);
                    }
                    break;
                }
            case Attention attention:
                {
                    if( weight >= 0.5 || Random.Range(0.0f, 0.51f) < weight )
                    {
                        SetChaseMode(obj);
                    }
                    break;
                }
            default:
                {
                    // in case of a laser pointer or some kind of target to then we'll just force it?
                    SetChaseMode(obj);
                    break;
                }
        }
    }

    public void WalkTowards( GameObject obj)
    {
        _suspectedTarget = obj;
        _agent.SetDestination(obj.transform.position);
        if ( CurrentBehavior == ( Behavior.Idle ) ) return;
        CurrentBehavior = Behavior.Idle;
        _currentWeightDeduction = NormalWeightDeduction;
        _speedMagnitude = NormalSpeed;
    }

    public void FleeFrom( GameObject obj )
    {
        SetFleeMode(obj);
    }

    public void Feed(Item item)
    {
        // feed a cat based on the items?
        switch( item )
        {
            case Food food:
                {
                    foodConsumption += food.ConsumeRate;
                    foodConsumption = Mathf.Clamp01(foodConsumption);
                    CurrentBehavior = Behavior.Idle;
                    break;
                }
            case Attention attention:
                {

                    break;
                }
        }
    }

    /// <summary>
    /// In case when another cat identifies an object that might be particular interesting. 
    /// </summary>
    /// <param name="obj"></param>
    public void Provoke(GameObject obj )
    {
        // invoke the cat somehow? and how does the cat behaves to this reaction.
        // this will be a chances to either fight or flee...
        float t = UnityEngine.Random.Range(0, 3);
        
        // could be Chase, Flee, or Idle (Frozen)...
        switch( Mathf.Round(t))
        {
            case 0: ChaseTowards(obj); break;                    // we can chase the object? Why not!
            case 1: CurrentBehavior = Behavior.Freeze; break;   // cat scared, can't move?
            case 2: FleeFrom(obj); break;                       // Cat afraid, flee from object.
            default:
                {
                    // hmm we broke here?
                    CurrentBehavior = Behavior.Freeze;
                    Debug.Log("This should not happen... But whatever!");
                    break;
                }
        }
    }

    #endregion

    #region Behavior engine

    private void SetChaseMode(GameObject obj)
    {
        CurrentBehavior = Behavior.Chase;
        _suspectedTarget = obj;
        _currentWeightDeduction = ChaseWeightDeduction;
        _speedMagnitude = ChaseSpeed;
        _agent.SetDestination(obj.transform.position);
        StopCoroutine(PseudoUpdate());
    }

    private void SetNormalMode()
    {
        CurrentBehavior = Behavior.Idle;
        _suspectedTarget = null;
        _speedMagnitude = NormalSpeed;
        _currentWeightDeduction = NormalWeightDeduction;
        StopCoroutine(PseudoUpdate());
    }

    private void SetFleeMode(GameObject source)
    {
        CurrentBehavior = Behavior.Flee;
        _suspectedTarget = null;
        _currentWeightDeduction = FleeWeightDeduction;
        _speedMagnitude = FleeSpeed;
        Vector3 newDir = (this.transform.position - source.transform.position).normalized * FleeDistance + this.transform.position;
        _agent.SetDestination(newDir);
        _agent.destination = newDir;
        StopCoroutine(PseudoUpdate());
        StartCoroutine(PseudoUpdate());
        _scaredTimer = 5f;
    }

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        if(mats.Length > 0 && TargetRender != null )
        {
            int i = UnityEngine.Random.Range(0, mats.Length);
            TargetRender.material = mats[i];
        }

        if( matsEyes.Length > 0 && EyeRender != null )
        {
            int i = UnityEngine.Random.Range(0, matsEyes.Length);
            EyeRender.material = matsEyes[i];
        }
        weight = UnityEngine.Random.Range(0.0f,1.1f);
        _currentWeightDeduction = NormalWeightDeduction;
        _speedMagnitude = NormalSpeed;
    }

    private void Start()
    {
        _timeToChangeDirection = UnityEngine.Random.Range(MinTimeToChangeDecision, MaxTimeToChangeDecision);
    }

    private void OnDrawGizmosSelected()
    {
        if (!ShowDebug) return;

        Gizmos.DrawWireCube(_agent.destination, Vector3.one * 1f);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, FleeDistance);

        if (_agent != null)
        {
            Vector3[] v = _agent.path.corners;
            Gizmos.color = Color.yellow;
            if (v.Length == 1)
                Gizmos.DrawLine(this.transform.position, _agent.destination);
            else
            {
                for (int i = 1, n = v.Length - 1; i < n - 1; i++)
                    Gizmos.DrawLine(v[i - 1], v[i]);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (CurrentBehavior)
        {
            case Behavior.Chase: ChaseObject();  break;
            case Behavior.Flee:
                {
                    if (_scaredTimer > 0)
                    {
                        _scaredTimer -= Time.fixedDeltaTime;
                        if ( _scaredTimer == 0 )
                        {
                            SetNormalMode();
                        }
                    }
                    break;
                }
            case Behavior.Freeze: break;    //no code implemented yet.
            case Behavior.Idle: IdleRandomBehavior(); break;
            default: // hmm you did something wrong to make this happen shame on you and yoru code design... 
                break;
        }
        
        weight -= Time.fixedDeltaTime * _currentWeightDeduction * _agent.velocity.normalized.magnitude;
        weight = Mathf.Clamp01(weight);
        _agent.speed = weightScale.Evaluate(weight) * _speedMagnitude;

        anim.SetBool("IsWalking", false);
        if (_agent.velocity != Vector3.zero)
        {   //not walking
            anim.SetBool("IsWalking", true);
        }
    }

    private void ChaseObject()
    {
        if ( _suspectedTarget != null )
        {
            if (!_suspectedTarget.activeSelf)
                _suspectedTarget = null;
            else
                _agent.destination = _suspectedTarget.transform.position;
            weight -= ChaseWeightDeduction * Time.deltaTime;
        }
        else
        {
            CurrentBehavior = Behavior.Idle;
            _currentWeightDeduction = NormalWeightDeduction;
            _speedMagnitude = NormalSpeed;
        }
    }

    private void IdleRandomBehavior()
    {
        _t += Time.deltaTime;

        if (_timeToChangeDirection < _t)
        {
            _timeToChangeDirection = UnityEngine.Random.Range(MinTimeToChangeDecision, MaxTimeToChangeDecision);
            _t = 0;
            // somehow we're going to randomized the cat's behavior here?
            //float i = Random.Range(0, 2);
            //if (i < 1)
            //{
            //    CurrentBehavior = Behavior.Idle;
            //}
            //else
            //{
            // let's make it interesting? Let's find a marker somewhere on the map and pick it random?
            float x = Mathf.Sin(UnityEngine.Random.Range(-360.0f, 360.0f)) * UnityEngine.Random.Range(MinRadius, MaxRadius) + transform.position.x;
            float z = Mathf.Cos(UnityEngine.Random.Range(-360.0f, 360.0f)) * UnityEngine.Random.Range(MinRadius, MaxRadius) + transform.position.z;
            Vector3 dir = new Vector3(x, this.transform.position.y, z);
            //CurrentBehavior = Behavior.Chase;
            // in this case we want the cat to be just walking.... instead of chasing?
            _agent.SetDestination(dir);
            //}
        }
    }

    private void OnDisable()
    {
        StopCoroutine(PseudoUpdate());
    }

    private void OnEnable()
    {
        StartCoroutine(PseudoUpdate());
    }

    // Hmm might need to edit this later... or somehow?
    IEnumerator PseudoUpdate()
    {
        yield return new WaitForSeconds(0);

        if (CurrentBehavior == Behavior.Flee && _agent.isActiveAndEnabled && _agent.isStopped)
        {
            SetNormalMode();
            yield return null;
        }
        
        yield return new WaitForSeconds(0.5f);
    }

    public void OnTriggerStay(Collider other)
    {
        Food food = other.GetComponent<Food>();
        //May want to only have cats interact with food in certain states, like "Hungry" and not "Scared"
        if (food != null)
        {
            food.Eaten();
        }
    }

    //public void OnCollisionStay(Collision collision)
    //{
    //    Rat rat = collision.transform.GetComponent<Rat>();
    //    if( rat != null )
    //    {
    //        rat.Feed
    //    }
    //}

    // Wander wants to see if we can try implemented "Leader packs" in this game where we have a pack of cats gather together only and if only if they're hungry asf...
    #region Leader Follows

    // in this behavior example, we need to determine if one qualify as a leader.... 
    // 

    #endregion


    #endregion
}
