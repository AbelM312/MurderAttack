using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CrowMovement : MonoBehaviour
{
    public float speed = 5f;        // Speed of the enemy
    public float range = 5f;        // Range of movement
    public float attackSpeed = 5f;
    public float retreatSpeed = 5f;

    public Vector2 destination = new Vector2(10f, 0f);  // Destination position
    public float switchIntervalMin = 10f;  // Minimum time before switching behavior
    public float switchIntervalMax = 20f;  // Maximum time before switching behavior

    private bool moveToDestination = false;  // Flag to determine the current behavior
    private float switchTime;
    public bool destinationReached = false;
    public float pauseDuration = 1f;      // Duration of the pause

    private Vector2 startingPosition;  // Initial position of the enemy

    void Start()
    {
        startingPosition = new Vector2 (0, 3); // Save the initial x position

        switchTime = Time.time + Random.Range(switchIntervalMin, switchIntervalMax);
    }

    void Update()
    {
        if (Time.time >= switchTime)
        {
            // Switch behavior
            moveToDestination = true;
            //switchTime = Time.time + Random.Range(switchIntervalMin, switchIntervalMax);

            if (moveToDestination)
            {
                StartCoroutine(PauseBeforeMoving());
            }

        }

        if (moveToDestination)
        {
            MoveToDestination();
        }
        else
        {
            MoveBackAndForth();
        }
    }

    void MoveToDestination()
    {
        
        if(destinationReached == false)
        {

            // Move towards the destination position
            transform.position = Vector2.MoveTowards(transform.position, destination, attackSpeed * Time.deltaTime);

        }

        // Check if the enemy has reached the destination
        if ((Vector2)transform.position == destination)
        {
            // Run specific code once the enemy reaches the destination
            Debug.Log("Enemy has reached the destination!");
            // Add your custom code here
            destinationReached = true;

            // Run specific code once the enemy reaches the destination
            StartCoroutine(PauseBeforeMoving());
        }

    }

    IEnumerator PauseBeforeMoving()
    {
        Debug.Log("pause initialized");
        // Pause for the specified duration
        yield return new WaitForSeconds(pauseDuration);


        // Continue with the next movement
        Debug.Log("pause finished");

        MoveBack();

    }

    void MoveBack()
    {

        if (destinationReached == true)
        {

            transform.position = Vector2.MoveTowards(transform.position, startingPosition, retreatSpeed * Time.deltaTime);

            Debug.Log("returning");

        }

        if ((Vector2)transform.position == startingPosition)
        {

            Debug.Log("Enemy has returned!");

            destinationReached = false;

            moveToDestination = false;

            switchTime = Time.time + Random.Range(switchIntervalMin, switchIntervalMax);

        }

    }

    void MoveBackAndForth()
    {
        // Calculate the new position based on the sine function
        float newPosition = startingPosition.x + Mathf.Sin(Time.time * speed) * range;

        // Update the enemy's position
        transform.position = new Vector2(newPosition, transform.position.y);
    }
}
