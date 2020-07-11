//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerController : MonoBehaviour
//{
//    public GameObject firePrefab;
//    private float thrust = 10.0f;
//    private float fireDistance = 4;

//    public int movementSpeed = 300;
//    public int runSpeed = 600;
//    private int turnSpeed = 200;
//    bool isMoving;
//    private float y, x;
//    public float lastH, lastV;
//    private Vector3 lastVelocity;
//    public bool disableEmber;

//    private Rigidbody2D myRigidbody;
//    private Animator anim;
//    public AudioSource audioEmber;
//    public AudioSource audioWalk;
//    public AudioSource audioRun;

//    private float timeLeftBeforeSleep = 10;
//    private float timeBeforeSleepDuration = 10;
//    private float timeLeftBeforeSit = 3;
//    private float timeBeforeSitDuration = 3;

//    private void Start()
//    {
//        myRigidbody = GetComponent<Rigidbody2D>();
//        anim = GetComponent<Animator>();
//    }

//    public void Move(bool shiftHeldDown)
//    {
//        if (shiftHeldDown) //running
//        {
//            y = Time.deltaTime * runSpeed * Input.GetAxisRaw("Vertical");
//            x = Time.deltaTime * runSpeed * Input.GetAxisRaw("Horizontal");
//            //anim.SetFloat("WalkSpeed", 1.5f);
//            anim.SetBool("Run", true);
//            if (!audioRun.isPlaying)
//            {
//                audioRun.Play();
//                audioWalk.Stop();
//            }
//        }
//        else //walking
//        {
//            y = Time.deltaTime * movementSpeed * Input.GetAxisRaw("Vertical");
//            x = Time.deltaTime * movementSpeed * Input.GetAxisRaw("Horizontal");
//            anim.SetFloat("WalkSpeed", 1);
//            anim.SetBool("Run", false);
//            if (!audioWalk.isPlaying)
//            {
//                audioWalk.Play();
//                audioRun.Stop();
//            }
//        }
//        myRigidbody.velocity = new Vector2(x, y);
//        if (myRigidbody.velocity != Vector2.zero) //moving
//        {
//            lastVelocity = myRigidbody.velocity;
//            timeLeftBeforeSleep = timeBeforeSleepDuration;
//            timeLeftBeforeSit = timeBeforeSitDuration;
//        }
//        else //not moving
//        {
//            audioWalk.Stop();
//            audioRun.Stop();
//        }
//    }

//    private void Ember()
//    {
//        anim.SetTrigger("Ember");
//        GameObject fire = Instantiate(firePrefab, GetFireSpawnPos(), transform.rotation);
//        audioEmber.Play();
//    }

//    private Vector3 GetFireSpawnPos()
//    {
//        Vector3 fireSpawnPos = transform.position;
//        lastH = anim.GetFloat("IdleHorizontal");
//        lastV = anim.GetFloat("IdleVertical");

//        if (lastH > 0) //facing R
//            fireSpawnPos.x += fireDistance;
//        else if (lastH < 0)
//            fireSpawnPos.x -= fireDistance;

//        if (lastV > 0)
//            fireSpawnPos.y += fireDistance;
//        else if (lastV < 0)
//            fireSpawnPos.y -= fireDistance;

//        return fireSpawnPos;
//    }

//    public void FixedUpdate()
//    {
//        anim.SetBool("Sleep", false);
//        anim.SetBool("Sit", false);

//        timeLeftBeforeSleep -= Time.deltaTime;
//        timeLeftBeforeSit -= Time.deltaTime;

//        if (timeLeftBeforeSleep < 0)
//        {
//            anim.SetBool("Sleep", true);
//        }

//        if (timeLeftBeforeSit < 0)
//        {
//            anim.SetBool("Sit", true);
//        }

//        if (Input.GetKeyDown(KeyCode.Space) && !disableEmber)
//        {
//            Ember();
//            timeLeftBeforeSleep = timeBeforeSleepDuration;
//            timeLeftBeforeSit = timeBeforeSitDuration;
//        }
//        else
//        {
//            Move(Input.GetKey(KeyCode.LeftShift));

//        }
//    }
//}
