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

    public Vector2 targetPosition;  // Destination position
    public float switchIntervalMin = 10f;  // Minimum time before switching behavior
    public float switchIntervalMax = 20f;  // Maximum time before switching behavior

    public bool moveToTarget = false;  // Flag to determine the current behavior
    private float switchTime;
    public bool targetReached = false;
    public float pauseDuration = 5f;      // Duration of the pause
    public float pauseForDeduction = 1f;

    private Vector2 startingPosition;  // Initial position of the enemy

    //public Food food;
    public float score;
    public float startingScore = 1000;
    public float scoreDeduction = 0.001f;
    public bool scoreToDeduct;
    public bool scoreStable;
    public int deductionsMade;

    void Start()
    {

        startingPosition = new Vector2(0, 3); // Save the initial x position

        switchTime = Time.time + Random.Range(switchIntervalMin, switchIntervalMax);

        score = startingScore;

        scoreToDeduct = false;

        scoreStable = true;

        deductionsMade = 0;
    }

    void Update()
    {

        if (Time.time >= switchTime)
        {
            // Switch behavior
            moveToTarget = true;
            //switchTime = Time.time + Random.Range(switchIntervalMin, switchIntervalMax);

            if (moveToTarget)
            {
                StartCoroutine(PauseBeforeMoving());
            }

            if (targetReached && scoreStable)
            {
                scoreStable = false;

                /*for (int i = 0; i < 5; i++)
                {

                    Debug.Log("Pause started");

                    StartCoroutine(PauseBeforeDeducting());

                }*/

                Debug.Log("Pause started");

                StartCoroutine(PauseBeforeDeducting());

            }

        }

        if (moveToTarget)
        {
            MoveToDestination();
        }
        else
        {
            MoveBackAndForth();
        }

        /*if (deductingScore)
        {

            Debug.Log("Pause started");

            StartCoroutine(PauseBeforeDeducting());

            deductingScore = false;

        }*/

    }

    void MoveToDestination()
    {

        if (targetReached == false)
        {

            // Move towards the destination position
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, attackSpeed * Time.deltaTime);

        }

        // Check if the enemy has reached the destination
        if ((Vector2)transform.position == targetPosition)
        {
            // Run specific code once the enemy reaches the destination
            //Debug.Log("Enemy has reached the target!");
            // Add your custom code here
            targetReached = true;

            moveToTarget = false;

            //deductingScore = true;

            // Run specific code once the enemy reaches the destination
            StartCoroutine(PauseBeforeMoving());
        }

    }

    IEnumerator PauseBeforeMoving()
    {
        //Debug.Log("pause initialized");
        // Pause for the specified duration
        yield return new WaitForSeconds(pauseDuration);


        // Continue with the next movement
        //Debug.Log("pause finished");

        MoveBack();

    }

    IEnumerator PauseBeforeDeducting()
    {

        yield return new WaitForSeconds(pauseForDeduction);

        Debug.Log("Deduction started");
        
        DeductScore();

    }

    public void MoveBack()
    {

        //scoreStable = true;

        deductionsMade = 0;

        if (targetReached == true)
        {

            transform.position = Vector2.MoveTowards(transform.position, startingPosition, retreatSpeed * Time.deltaTime);

            //Debug.Log("returning");

        }

        if ((Vector2)transform.position == startingPosition)
        {

            //scoreToDeduct = true;

            //FoodTaken();

            Debug.Log("Enemy has returned!");

            targetReached = false;

            moveToTarget = false;

            scoreStable = true;

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

    public void DeductScore()
    {
        //deductingScore = false;

        /*for (int i = 0; i <= 5; i++)
        {

            if (deductingScore)
            {

                Debug.Log("deducting score");

                score = score - scoreDeduction;

            }


            //Debug.Log("deducting score");

            Debug.Log(i);

            score = score - scoreDeduction;

        }*/


        score = score - scoreDeduction;
    }

    /*public void FoodTaken()
    {

        if (scoreToDeduct == true)
        {

            score = score - scoreDeduction;

            scoreToDeduct = false;

        }

        if (score < 0)
        {

            score = startingScore;

        }

        Debug.Log("Food taken!");

    }*/

}
