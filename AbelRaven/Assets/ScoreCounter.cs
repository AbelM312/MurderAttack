using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{

    public float score;
    public float startingScore = 1000f;
    public float scoreDeduction = 10f;
    // Start is called before the first frame update
    void Start()
    {

        score = startingScore;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float ScoreDeduction()
    {

        Debug.Log("Deducting...");

        score = score - scoreDeduction;

        return score;

    }

}
