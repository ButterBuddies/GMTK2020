using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehavior : MonoBehaviour
{
    private Vector2 desiredVelocity; //a force that guides obj towards its target using the shortest path possible
    public Vector2 steering;
    private Vector3 maxVelocity;
    public float maxForce = 1;
    public float maxSpeed = 1;
    public Vector3 circleDistance;
    public Vector3 circleRadius;
    private Vector3 ahead;
    private Vector3 ahead2;
    private Rigidbody2D rigidbody;
    private float slowingRadius = .001f;
    public float wanderAngle = 2;
    private float MAX_SEE_AHEAD = 1;
    private Vector3 MAX_AVOID_FORCE;

    //private Vector3[] listOfObstaclesPos;
    private GameObject[] listOfObstacles;

    private void Awake()
    {
        desiredVelocity = Vector2.zero; //a force that guides obj towards its target using the shortest path possible
        steering = Vector2.zero;
        maxVelocity = new Vector3(2f,2f,0);
        rigidbody = GetComponent<Rigidbody2D>();
        circleDistance = new Vector3(6, 6, 0);
        circleRadius = new Vector3(.1f, .1f, 0);
        MAX_AVOID_FORCE = new Vector3(5, 5, 5);
        listOfObstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        //listOfObstaclesPos = GameObject.FindGameObjectWithTag("TileColliderFinder").GetComponent< TilePosFinder>().tileLocations;
    }

    public Vector3 Seek(Vector3 newTarget)
    {
        desiredVelocity = (newTarget - transform.position);
        desiredVelocity = desiredVelocity.normalized;
        desiredVelocity = desiredVelocity * maxVelocity;
        steering = desiredVelocity - rigidbody.velocity;

        steering = Vector3.ClampMagnitude(steering, maxForce);
        steering = steering / rigidbody.mass;

        return Vector3.ClampMagnitude(rigidbody.velocity + steering, maxSpeed);
        //rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity + steering, maxSpeed);
    }

    public Vector3 Flee(Vector3 newTarget)
    {
        desiredVelocity = (transform.position - newTarget);
        desiredVelocity = desiredVelocity.normalized;
        desiredVelocity = desiredVelocity * maxVelocity;
        steering = desiredVelocity - rigidbody.velocity;

        steering = Vector3.ClampMagnitude(steering, maxForce);
        steering = steering / rigidbody.mass;

        return Vector3.ClampMagnitude(rigidbody.velocity + steering, maxSpeed);
        //rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity + steering, maxSpeed);
    }

    public void Arrival(Vector3 newTarget)
    {
        float distance = 0;

        // Calculate the desired velocity

        //Debug.Log("1 " + distance);
        desiredVelocity = newTarget - transform.position;
        distance = Vector2.Distance(transform.position, newTarget);

        //Debug.Log(distance);
        //Debug.Log(distance);
        // Check the distance to detect whether the character
        // is inside the slowing area
        if (distance < 0.05f)
        {
            Stop();
            return;
        }
        else if (distance < slowingRadius)
        {
            //Debug.Log("3 " + distance);
            // Inside the slowing area
            desiredVelocity = desiredVelocity.normalized;
            desiredVelocity = desiredVelocity * maxVelocity;
            desiredVelocity = desiredVelocity * (distance / slowingRadius);
            //normalize(desiredVelocity) * maxVelocity * (distance / slowingRadius);
        }
        else
        {
            // Outside the slowing area.
            desiredVelocity = desiredVelocity.normalized;
            desiredVelocity = desiredVelocity * maxVelocity;
            //desiredVelocity = normalize(desiredVelocity) * maxVelocity;
        }

        // Set the steering based on this
        steering = desiredVelocity - rigidbody.velocity;
        rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity + steering, maxSpeed);
    }

    public Vector3 Wander()
    {
        // Calculate the circle center
        Vector3 circleCenter = Vector3.zero;
        circleCenter = rigidbody.velocity;
        circleCenter.Normalize();
        circleCenter.Scale(circleDistance);

        // Calculate the displacement force
        Vector3 displacement;
        displacement = new Vector3(0, -1, 0);
        displacement.Scale(circleRadius);

        // Randomly change the vector direction
        // by making it change its current angle
        displacement = setAngle(displacement, wanderAngle);

        // Change wanderAngle just a bit, so it
        // won't have the same value in the
        // next game frame.
        wanderAngle += UnityEngine.Random.Range(-1, 1) * 0.3f; //ANGLE_CHANGE - ANGLE_CHANGE * .5;

        // Finally calculate and return the wander force
        Vector3 wanderForce;
        wanderForce = circleCenter + displacement;
        return wanderForce;
    }

    private Vector3 setAngle(Vector3 vector, double value)
    {
        double len = vector.magnitude;
        vector.x = (float)Math.Cos(value) * (float)len;
        vector.y = (float)Math.Sin(value) * (float)len;
        return vector;
    }

    public Vector3 Pursue(GameObject newTarget)
    {
        Vector3 distance = newTarget.transform.position - transform.position;
        float time = 3;//distance.magnitude / maxVelocity.magnitude;
        Vector3 futurePosition = newTarget.transform.position + (Vector3)(newTarget.GetComponent<Rigidbody2D>().velocity * time);
        steering = Seek(futurePosition);

        steering = Vector3.ClampMagnitude(steering, maxForce);
        steering = steering / rigidbody.mass;
        return Vector3.ClampMagnitude(rigidbody.velocity + steering, maxSpeed);
    }

    public Vector3 Evade(GameObject newTarget)
    {
        Vector3 distance = newTarget.transform.position - transform.position;
        float updatesAhead = 3;
        Vector3 futurePosition = newTarget.transform.position + (Vector3)(newTarget.GetComponent<Rigidbody2D>().velocity * updatesAhead);
        steering = Flee(futurePosition);

        steering = Vector3.ClampMagnitude(steering, maxForce);
        steering = steering / rigidbody.mass;
        return Vector3.ClampMagnitude(rigidbody.velocity + steering, maxSpeed);
    }

    public Vector3 collisionAvoidance()
    {
        //float dynamic_length = rigidbody.velocity.magnitude / maxVelocity.magnitude;
        //Debug.Log("dl " + dynamic_length);
        //ahead = transform.position + (Vector3)rigidbody.velocity.normalized * dynamic_length;
        ahead = transform.position + (Vector3)rigidbody.velocity.normalized * MAX_SEE_AHEAD;
        ahead2 = transform.position + (Vector3)rigidbody.velocity.normalized * MAX_SEE_AHEAD * 0.5f;


        GameObject mostThreatening = findMostThreateningObstacle();
        Vector3 avoidance = new Vector3(0, 0, 0);
 
        if (mostThreatening != null) {
            avoidance.x = ahead.x - mostThreatening.transform.position.x;
            avoidance.y = ahead.y - mostThreatening.transform.position.y;
 
            avoidance.Normalize();
            avoidance.Scale(MAX_AVOID_FORCE);
        } else {
            avoidance.Scale(Vector3.zero); // nullify the avoidance force
        }
 
        return avoidance;
    }

    public bool lineIntersectsCircle(Vector3 ahead, Vector3 ahead2, Vector3 obstaclePos)
    {
        // the property "center" of the obstacle is a Vector3D.
        return (Vector2.Distance(obstaclePos, ahead) <= 1f
                || Vector2.Distance(obstaclePos, ahead2) <= 1f);
    }

    public GameObject findMostThreateningObstacle()
    {
        GameObject mostThreatening = null;
 
        for (int i = 0; i < listOfObstacles.Length; i++) {
            GameObject obstacle = listOfObstacles[i];
            bool collision = lineIntersectsCircle(ahead, ahead2, obstacle.transform.position);
 
            // "position" is the character's current position
            if (collision && (mostThreatening == null ||
                            Vector2.Distance(transform.position, obstacle.transform.position) < 
                            Vector2.Distance(transform.position, mostThreatening.transform.position)))
            {
                mostThreatening = obstacle;
            }
        }
        return mostThreatening;
    }

    public void CalculateSteering()
    {
        steering = Vector3.ClampMagnitude(steering, maxForce);
        steering = steering / rigidbody.mass;
        rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity + steering, maxSpeed);
    }

    public void Stop()
    {
        steering = Vector2.zero;
        rigidbody.velocity = Vector3.zero;
    }
}
