using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CrowMovement : MonoBehaviour
{
    private float speed;        // Speed of the enemy
    public float range = 5f;        // Range of movement
    public float attackSpeed = 5f;
    public float retreatSpeed = 5f;

    public Transform target;
    public Transform target1;
    public Transform target2;
    public Vector2 targetPosition1;  // Destination position
    public Vector2 targetPosition2;
    public float switchIntervalMin = 10f;  // Minimum time before switching behavior
    public float switchIntervalMax = 20f;  // Maximum time before switching behavior

    public bool moveToTarget = false;  // Flag to determine the current behavior
    private float switchTime;
    public bool targetReached = false;
    public bool targetChoosen;
    public float pauseDuration = 5f;      // Duration of the pause
    public float pauseForDeduction = 1f;

    public Vector2 returnPosition;  // Initial position of the enemy
    public Transform returnY;
    public Vector2 spawnAreaSize = new Vector2(10f, 1f);

    //public Food food;
    public bool scoreToDeduct;
    public bool scoreStable;
    public int deductionsMade;

    public ScoreCounter scoreCounter;

    void Start()
    {

        speed = Random.Range(0.455f, 0.715f);

        returnPosition = new Vector3(Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f), returnY.position.y, 0f);

        targetPosition1 = new Vector2(target1.position.x, target1.position.y);

        targetPosition2 = new Vector2(target2.position.x, target2.position.y);

        switchTime = Time.time + Random.Range(switchIntervalMin, switchIntervalMax);

        targetChoosen = false;

        scoreToDeduct = false;

        scoreStable = true;

        deductionsMade = 0;

        scoreCounter = new ScoreCounter();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);
        // You can perform any other actions based on the collision here
    }

    void ChooseTarget()
    {



    }

    void MoveToDestination()
    {

        if (targetReached == false)
        {
            if (targetChoosen == false)
            {

                target = Random.Range(0, 2) == 0 ? target1 : target2;

            }

            // Move towards the chosen target position
            Vector2 direction = (target.position - transform.position).normalized;
            transform.Translate(direction * attackSpeed * Time.deltaTime);

            // Move towards the destination position
            //transform.position = Vector2.MoveTowards(transform.position, targetPosition1, attackSpeed * Time.deltaTime

            targetChoosen = true;

        }

        // Check if the enemy has reached the destination
        if ((Vector2)transform.position == targetPosition1)
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

        if ((Vector2)transform.position == targetPosition2)
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
        
        scoreCounter.ScoreDeduction();

        Debug.Log("Deduction finished");

    }

    public void MoveBack()
    {

        //scoreStable = true;

        deductionsMade = 0;

        if (targetReached == true)
        {

            transform.position = Vector2.MoveTowards(transform.position, returnPosition, retreatSpeed * Time.deltaTime);

            //Debug.Log("returning");

        }

        if ((Vector2)transform.position == returnPosition)
        {

            //scoreToDeduct = true;

            //FoodTaken();

            Debug.Log("Enemy has returned!");

            targetReached = false;

            targetChoosen = false;

            moveToTarget = false;

            scoreStable = true;

            switchTime = Time.time + Random.Range(switchIntervalMin, switchIntervalMax);

        }

    }

    void MoveBackAndForth()
    {
        // Calculate the new position based on the sine function
        float newPosition = returnY.position.x + Mathf.Sin(Time.time * speed) * range;

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
