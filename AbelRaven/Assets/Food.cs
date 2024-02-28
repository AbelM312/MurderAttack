using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    public float foodLeft;
    public float fullFood = 3;
    
    // Start is called before the first frame update
    void Start()
    {

        foodLeft = fullFood;

    }

    public void FoodTaken()
    {

        foodLeft = foodLeft-1;

        if (foodLeft < 0)
        {

            foodLeft = fullFood;

        }

        Debug.Log("Food taken!");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
