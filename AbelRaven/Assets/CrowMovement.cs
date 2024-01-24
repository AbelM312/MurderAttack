using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowMovement : MonoBehaviour
{
    public float speed = 5f;        // Speed of the enemy
    public float range = 5f;        // Range of movement

    private float startingPosition;  // Initial position of the enemy

    void Start()
    {
        startingPosition = transform.position.x; // Save the initial x position
    }

    void Update()
    {
        MoveBackAndForth();
    }

    void MoveBackAndForth()
    {
        // Calculate the new position based on the sine function
        float newPosition = startingPosition + Mathf.Sin(Time.time * speed) * range;

        // Update the enemy's position
        transform.position = new Vector2(newPosition, transform.position.y);
    }
}
