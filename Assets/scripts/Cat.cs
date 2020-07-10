using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Cat : MonoBehaviour
{
    #region variables
    public enum Behavior { Flee, Chase, Idle, Freeze }
    //public enum Emotion { Lonely, Scared, Happy, Clean, Scout, Sleep, Eating}

    // in this case we can determine the shape and size of a cat object.
    public float speed = 5f;
    // if the cat weights gets too much, then thespeed of the cat and the emotion of the cat gets inflicted. 
    public float weight = 1f;
    // Time it takes for cat to change it's behavior decisions beacse you know.. cats get weird and strange to predict?
    public float timeToChangeDecision = 20.0f;
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

#endregion

    #region Implementations
    public void MoveTowards( GameObject obj )
    {
        // in case of a laser pointer or some kind of target to
        CurrentBehavior = Behavior.Chase;
        _suspectedTarget = obj;
    }

    public void FleeFrom( GameObject obj )
    {
        CurrentBehavior = Behavior.Flee;
        _suspectedTarget = obj;
    }

    public void Feed(Food food)
    {
        // feed a cat based on the items?
        foodConsumption += food.ConsumeRate;
        foodConsumption = Mathf.Clamp01(foodConsumption);
        CurrentBehavior = Behavior.Idle;
    }

    /// <summary>
    /// In case when another cat identifies an object that might be particular interesting. 
    /// </summary>
    /// <param name="obj"></param>
    public void Provoke(GameObject obj )
    {
        // invoke the cat somehow? and how does the cat behaves to this reaction.
        // this will be a chances to either fight or flee...
        float t = Random.Range(0, 3);
        
        // could be Chase, Flee, or Idle (Frozen)...
        switch( Mathf.Round(t))
        {
            case 0: MoveTowards(obj); break;                    // we can chase the object? Why not!
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

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void OnDrawGizmosSelected()
    {
        // Show the max area of which the range is given to the cat.
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, MaxRadius);
        Gizmos.DrawWireSphere(transform.position, MinRadius);

        if ( _agent == null ) return;
        Vector3[] v = _agent.path.corners;
        Gizmos.color = Color.yellow;
        if (v.Length == 1)
        {
            Gizmos.DrawLine(this.transform.position, v[0]);
        }
        else
        {
            for (int i = 1, n = v.Length - 1; i < n - 1; i++)
            {
                Gizmos.DrawLine(v[i - 1], v[i]);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch(CurrentBehavior)
        {
            case Behavior.Chase: break;
            case Behavior.Flee: break;
            case Behavior.Freeze: break;
            case Behavior.Idle: break;
            default: // hmm you did something wrong to make this happen shame on you and yoru code design... 
                break;
        }
        _t += Time.deltaTime;

        if( timeToChangeDecision < _t )
        {
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
                float x = Mathf.Sin(Random.Range(-360.0f, 360.0f)) * Random.Range(MinRadius, MaxRadius) + transform.position.x;
                float z = Mathf.Cos(Random.Range(-360.0f, 360.0f)) * Random.Range(MinRadius, MaxRadius) + transform.position.z;
                Vector3 dir = new Vector3(x, this.transform.position.y + 10f, z);
                CurrentBehavior = Behavior.Chase;
                // in this case we want the cat to be just walking.... instead of chasing?
                _agent.SetDestination(dir);
            //}
        }
    }
   
    #endregion
}
