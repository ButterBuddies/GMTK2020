//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class SheepController : MonoBehaviour
//{
//    public SteeringBehavior steeringB;
//    private Virus virus;
//    private SpriteRenderer sprite;
//    private Animator anim;
//    private Rigidbody2D rb;
//    private Transform dog;
//    public float grazeTimer = 5;
//    public float countDown = 1;
//    public float fleeFromDogRange;
//    private float tint;
//    private float scaleFactor;
//    public Vector3 arrivalTarget;
//    public bool isOnFire;
//    public GameObject fireSprite;
//    public GameObject biohazardIcon;
//    public GameObject skelePrefab;
//    public float fireLife = 5;

//    private Text virusScoreCount;

//    // Start is called before the first frame update
//    void Start()
//    {
//        grazeTimer = UnityEngine.Random.Range(1, 5);
//        countDown = 0;
//        steeringB = GetComponent<SteeringBehavior>();
//        rb = GetComponent<Rigidbody2D>();
//        virus = GetComponent<Virus>();
//        sprite = GetComponent<SpriteRenderer>();
//        dog = GameObject.FindGameObjectWithTag("Dog").GetComponent<Transform>();
//        scaleFactor = Random.Range(0.7f, 1);
//        gameObject.transform.localScale = new Vector3( scaleFactor, scaleFactor, 1);
//        anim = GetComponent<Animator>();
//        virusScoreCount = GameObject.FindGameObjectWithTag("VirusScoreCount").GetComponent<Text>();
//    }

//    private void FixedUpdate()
//    {
//        CheckVirus();
//        HandleSteering();
       
//    }

//    private void CheckVirus()
//    {
//        //change sprite renderer color to virus.infectionLevelPercent
//        if (virus.infectionLevel > 0)
//        {
//            tint = virus.infectionLevel / 100; //a value 0 to 1

//            sprite.color = new Color((1 - tint), 1, (1 - tint), 1);
//        }

//        if (virus.infectionLevel > 50 && !virus.infectionRange.enabled) //infectious
//        {
//            //check bounds for nearby uninfected sheep
//            //increase their infection level
//            virus.infectionRange.enabled = true;
//            biohazardIcon.SetActive(true);
//        }
//    }

//    private void HandleSteering()
//    {
//        if (isOnFire)
//        {
//            steeringB.steering = steeringB.steering + (Vector2)steeringB.Wander();
//            steeringB.steering = steeringB.steering + (Vector2)steeringB.collisionAvoidance();
//        }
//        else if (Vector2.Distance(transform.position, dog.position) < fleeFromDogRange)
//        {
//            steeringB.steering = steeringB.steering + (Vector2)steeringB.Flee(dog.position);
//            steeringB.steering = steeringB.steering + (Vector2)steeringB.collisionAvoidance();
//            //Debug.Log("fleeing dog");
//        }
//        else if (arrivalTarget != Vector3.zero)
//        {
//            steeringB.Arrival(arrivalTarget);
//            //steeringB.steering = steeringB.steering + (Vector2)steeringB.Flee(dog.position);
//            //steeringB.steering = steeringB.steering + (Vector2)steeringB.collisionAvoidance();
//            //Debug.Log("trying to arrive");
//        }
//        else
//        { //stop fleeing, maybe switch to wander
//            countDown -= Time.deltaTime;
//            if (countDown > 0)
//            {
//                steeringB.steering = steeringB.steering + (Vector2)steeringB.Wander();
//                steeringB.steering = steeringB.steering + (Vector2)steeringB.collisionAvoidance();
//                //Debug.Log("wandering");
//            }
//            else
//            { //grazing
//                grazeTimer -= Time.deltaTime;
//                if (grazeTimer < 0)
//                {
//                    grazeTimer = UnityEngine.Random.Range(0, 5);
//                    countDown = UnityEngine.Random.Range(0, 2);
//                }
//                steeringB.Stop();
//                //Debug.Log("grazing");
//            }
//        }
//        steeringB.CalculateSteering();
//    }

//    public void SetArrival(Vector3 pos)
//    {
//        arrivalTarget = pos;
//    }

//    public void CatchOnFire()
//    {
//        isOnFire = true;
//        fireSprite.SetActive(true);
//        fireSprite.GetComponent<FireController>().lifeTime = fireLife;
//        steeringB.maxForce = 5;
//        steeringB.maxSpeed = 5;
//        Destroy(gameObject, fireLife);
//        GetComponent<Animator>().speed = 2;
//        Invoke("SpawnSkele", fireLife - 0.1f);
//        Invoke("Death", fireLife - 1f);
//    }

//    private void Death()
//    {
//        anim.SetTrigger("Death");
//        steeringB.maxForce = 0;
//        steeringB.maxSpeed = 0;
//        if (virusScoreCount != null)
//            virusScoreCount.text = ((System.Convert.ToInt32(virusScoreCount.text)) + 1).ToString();
//    }

//    private void SpawnSkele()
//    {
//        Instantiate(skelePrefab, transform.position, 
//                    Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f)));
//    }
//}
